using Abdrakov.CommonWPF.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using toolcad23.Views;

namespace toolcad23.Modules
{
    internal class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var region = containerProvider.Resolve<IRegionManager>();
            // the view to display on start up
            region.RegisterViewWithRegion(Regions.MAIN_REGION, typeof(MainPageView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPageView>();
        }
    }
}
