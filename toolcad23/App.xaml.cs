using Abdrakov.CommonWPF.Views;
using Abdrakov.Engine.Interfaces;
using Abdrakov.Engine.Interfaces.Presentation;
using Abdrakov.Engine.Localization;
using Abdrakov.Engine.Localization.Extensions;
using Abdrakov.Engine.MVVM;
using Abdrakov.Engine.Utils.Settings;
using Abdrakov.Styles;
using Abdrakov.Styles.Interfaces;
using Abdrakov.Styles.Other;
using Abdrakov.Styles.Services;
using Prism.Ioc;
using Prism.Modularity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using toolcad23.Modules;
using toolcad23.Views;

namespace toolcad23
{
    public partial class App : AbdrakovApplication
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureApplicationVisual();

            Thread.CurrentThread.Name = "MainThread";
            LocalizationManager.InitializeExternal(Assembly.GetExecutingAssembly(), new ObservableCollection<Language>()
            {
                new Language() { Name = "EN" },
                new Language() { Name = "RU" },
            });
            base.OnStartup(e);
        }

        protected override Window CreateShell()
        {
            var viewModelService = Container.Resolve<IViewModelResolverService>();
            viewModelService.RegisterViewModelAssembly(Assembly.GetExecutingAssembly());

            return base.CreateShell();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            base.RegisterTypes(containerRegistry);

            containerRegistry.RegisterSingleton<IPreviewWindow, PreviewWindowView>();

            containerRegistry.RegisterInstance(new BaseWindowSettings()
            {
                ProductName = "toolcad 23",
                LogoImage = "pack://application:,,,/toolcad23;component/Resources/logo_tc23.png",
                SmoothAppear = true,
            });
            containerRegistry.RegisterSingleton<IBaseWindow, MainWindowView>();

            containerRegistry.RegisterSingleton<IAbdrakovThemeService, AbdrakovThemeService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<MainModule>();
            moduleCatalog.AddModule<MainPageModule>();
        }

        private static readonly Color _secondary = Color.FromRgb(131, 113, 189);

        private void ConfigureApplicationVisual()
        {
            Resources.MergedDictionaries.Add(new AbdrakovBundledTheme()
            {
                IsDarkMode = true,
                ExtendedColors = new Dictionary<string, ColorPair>()
                {
                    { "TextForeground", new ColorPair(Colors.AliceBlue, Colors.Black) },
                    { "WindowStatus", new ColorPair(_secondary, _secondary) },
                    { "Window", new ColorPair(Color.FromRgb(64, 64, 64), Color.FromRgb(254, 254, 254)) },

                    { "Primary", new ColorPair(Color.FromRgb(44, 44, 44), Color.FromRgb(234, 234, 234)) },
                    { "Secondary", new ColorPair(_secondary, _secondary) },
                }
            }.SetTheme());
        }
    }
}
