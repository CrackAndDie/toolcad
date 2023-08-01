using Abdrakov.Engine.Extensions;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using toolcad23.Interfaces;
using toolcad23.Views;

namespace toolcad23.Modules
{
    internal class MainPageModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var region = containerProvider.Resolve<IRegionManager>();
            // the view to display on start up
            region.RegisterViewWithRegion(InternalRegions.MAIN_PAGE_REGION, typeof(InfoPageView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<IInfoView, InfoPageView>();
            containerRegistry.RegisterForNavigation<IDeliveryView, DeliveryPageView>();
            containerRegistry.RegisterForNavigation<IRetrieveView, RetrievePageView>();
        }
    }
}
