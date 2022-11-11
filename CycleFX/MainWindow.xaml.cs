using Common;
using Notification.Wpf;
using Notification.Wpf.Classes;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CycleFX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();

            Fx newfx = Fetcher.getnext();
            ShowNotification(newfx);
            newfx.apply();
            Task.Run(async () => await Lib.MinimizeSignalRGB());
            this.Close();
        }

        void ShowNotification(Fx fx)
        {
            var notificationManager = new NotificationManager();

            var content = new NotificationContent
            {
                Title = fx.Title,
                Message = fx.cmd,
                Type = NotificationType.None,
                CloseOnClick = true, // Set true if u want close message when left mouse button click on message (base = true)

                Background = new SolidColorBrush(Colors.Black),
                Foreground = new SolidColorBrush(Colors.White),
            };

            if (File.Exists(fx.Imgpath))
            {
                content.Image = new NotificationImage()
                {
                    Source = new BitmapImage(new Uri(fx.Imgpath)),
                    Position = ImagePosition.Top
                };
            }
            notificationManager.Show(content);
        }
    }
}