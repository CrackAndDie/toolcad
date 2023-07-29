﻿using Abdrakov.CommonWPF.Views;
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