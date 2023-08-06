using Abdrakov.Engine.MVVM;
using Abdrakov.Engine.Extensions;
using Prism.Regions;
using toolcad23.Interfaces;
using toolcad23.Views;
using System.Collections.ObjectModel;
using Abdrakov.Engine.Localization;
using Abdrakov.Engine.Localization.Extensions;
using System.Linq;
using System.Globalization;
using Abdrakov.Styles.Interfaces;
using Prism.Ioc;

namespace toolcad23.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Language> Languages => LocalizationManager.Languages;

        private int selectedTabIndex;
        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set { SetProperty(ref selectedTabIndex, value); OnTabSelectionChanged(value); }
        }

        private Language _selectedLanguage;
        public Language SelectedLanguage
        {
            get { return _selectedLanguage; }
            set { SetProperty(ref _selectedLanguage, value); OnLanguageSelectionChanged(value); }
        }

        private bool _isDarkModeEnabled;
        public bool IsDarkModeEnabled
        {
            get { return _isDarkModeEnabled; }
            set { SetProperty(ref _isDarkModeEnabled, value); OnDarkModeChanged(value); }
        }

        public override void OnViewReady()
        {
            base.OnViewReady();
            SetDefaults();
        }

        private void SetDefaults()
        {
            SelectedLanguage = Languages.FirstOrDefault();
            IsDarkModeEnabled = Container.Resolve<IAbdrakovThemeService>().IsDark;
        }

        private void OnDarkModeChanged(bool isDark)
        {
            Container.Resolve<IAbdrakovThemeService>().ApplyBase(isDark);
        }

        private void OnLanguageSelectionChanged(Language language)
        {
            LocalizationManager.CurrentLanguage = CultureInfo.GetCultureInfo(language.Name.ToLower());
        }

        private void OnTabSelectionChanged(int index)
        {
            switch (index)
            {
                case 0:
                {
                    RegionManager.RequestNavigate<IInfoView>(InternalRegions.MAIN_PAGE_REGION);
                    break;
                }
                case 1:
                {
                    RegionManager.RequestNavigate<IRetrieveView>(InternalRegions.MAIN_PAGE_REGION);
                    break;
                }
                case 2:
                {
                    RegionManager.RequestNavigate<IDeliveryView>(InternalRegions.MAIN_PAGE_REGION);
                    break;
                }
            }
        }
    }
}
