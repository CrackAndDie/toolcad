using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace toolcad23.Views.OtherViews.DeliveryViews
{
    public partial class DeliveryControlView : UserControl
    {
        public BitmapImage QRCodeImage
        {
            get { return (BitmapImage)GetValue(QRCodeImageProperty); }
            set { SetValue(QRCodeImageProperty, value); }
        }

        public static readonly DependencyProperty QRCodeImageProperty =
            DependencyProperty.Register("QRCodeImage", typeof(BitmapImage), typeof(DeliveryControlView));

        public string QRCodeText
        {
            get { return (string)GetValue(QRCodeTextProperty); }
            set { SetValue(QRCodeTextProperty, value); }
        }

        public static readonly DependencyProperty QRCodeTextProperty =
            DependencyProperty.Register("QRCodeText", typeof(string), typeof(DeliveryControlView));

        public DeliveryControlView()
        {
            InitializeComponent();
        }
    }
}
