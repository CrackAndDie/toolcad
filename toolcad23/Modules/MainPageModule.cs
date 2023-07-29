using Abdrakov.CommonWPF.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            containerRegistry.RegisterForNavigation<InfoPageView>();
            containerRegistry.RegisterForNavigation<DeliveryPageView>();
            containerRegistry.RegisterForNavigation<RetrievePageView>();
        }
    }
}
