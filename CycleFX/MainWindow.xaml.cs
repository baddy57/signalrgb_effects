using Notification.Wpf;
using Notification.Wpf.Classes;
using System;
using System.Diagnostics;
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
            newfx.apply();

            var notificationManager = new NotificationManager();
            var content = new NotificationContent
            {
                Title = newfx.Title,
                Message = newfx.cmd,
                Type = NotificationType.None,
                CloseOnClick = true, // Set true if u want close message when left mouse button click on message (base = true)

                Background = new SolidColorBrush(Colors.Black),
                Foreground = new SolidColorBrush(Colors.White),

                Image = new NotificationImage()
                {
                    Source = new BitmapImage(new Uri(newfx.Imgpath)),
                    Position = ImagePosition.Top
                }
            };
            notificationManager.Show(content);
            this.Close();
        }
    }
}