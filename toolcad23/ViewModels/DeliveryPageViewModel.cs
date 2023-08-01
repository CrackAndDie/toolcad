using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using toolcad23.Models;
using toolcad23.Models.Helpers;

namespace toolcad23.ViewModels
{
    internal class DeliveryPageViewModel : BindableBase
    {
        private readonly DeliveryPageModel model;
        public ReadOnlyObservableCollection<BitmapImage> QRCodeImages => model.QRCodeImages;
        public ReadOnlyObservableCollection<string> QRCodeTexts => model.QRCodeTexts;

        public int YellowText
        {
            get { return model.YellowText; }
            set { model.YellowText = value; }
        }

        public int WhiteText
        {
            get { return model.WhiteText; }
            set { model.WhiteText = value; }
        }

        public int BlueText
        {
            get { return model.BlueText; }
            set { model.BlueText = value; }
        }

        public int MaxRedText
        {
            get { return model.MaxRedText; }
            set { model.MaxRedText = value; }
        }

        public int MaxGreenText
        {
            get { return model.MaxGreenText; }
            set { model.MaxGreenText = value; }
        }

        #region Commands
        public ICommand RandomizeCommand => model.RandomizeCommand;
        public ICommand SavePictureCommand { get; }
        #endregion

        internal DeliveryPageViewModel()
        {
            model = new DeliveryPageModel();
            model.PropertyChanged += (s, a) => { RaisePropertyChanged(a.PropertyName); };
            model.ProblemRaised += (s, a) =>
            {
                // MessageBoxFactory.Show(a);
            };

            SavePictureCommand = new DelegateCommand<object>((obj) =>
            {
                Functions.CreateBitmapFromVisualAndCopyToClipboard(obj as Visual);
            });
        }
    }
}
