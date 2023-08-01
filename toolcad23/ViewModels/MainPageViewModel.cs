using Abdrakov.Engine.MVVM;
using Abdrakov.Engine.Extensions;
using Prism.Regions;
using toolcad23.Interfaces;
using toolcad23.Views;

namespace toolcad23.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private int selectedTabIndex;
        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set { SetProperty(ref selectedTabIndex, value); OnTabSelectionChanged(value); }
        }

        public MainPageViewModel()
        {

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
