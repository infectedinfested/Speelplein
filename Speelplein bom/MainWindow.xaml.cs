using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Speelplein_bom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _timer;
        TimeSpan _time;
        BitmapImage locked = new BitmapImage();
        BitmapImage unlocked = new BitmapImage();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        bool bom = false;
        public MainWindow()
        {
            InitializeComponent();
            _time = TimeSpan.FromHours(1);
            locked.BeginInit();
            locked.UriSource = new Uri("C:/Resource/lock.png");
            locked.EndInit();
            unlocked.BeginInit();
            unlocked.UriSource = new Uri("C:/Resource/unlock.png");
            unlocked.EndInit();
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                TxtBomb.Text = _time.ToString("c");
                _time = _time.Add(TimeSpan.FromSeconds(-1));
                if (_time <= TimeSpan.Zero)
                {
                    _timer.Stop();
                    Alarm();
                } 
            }, Application.Current.Dispatcher);
            _timer.Stop();
            Question1.Visibility = Visibility.Visible;
            Question2.Visibility = Visibility.Hidden;
            Question3.Visibility = Visibility.Hidden;
            Question4.Visibility = Visibility.Hidden;
            Question5.Visibility = Visibility.Hidden;
            ImgLock1.Source = locked;
            ImgLock2.Source = locked;
            ImgLock3.Source = locked;
            ImgLock4.Source = locked;
            ImgLock5.Source = locked;
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            BtnStart.Visibility = Visibility.Hidden;
            _timer.Start();
            bom = true;
        }
        private void MainWindow_Closing(Object sender,CancelEventArgs e)
        {
            if (bom)
            {
                e.Cancel = true;
                _time = _time.Add(TimeSpan.FromSeconds(-60));
            }
            
        }

        private void Alarm()
        {
            Console.Beep(5000, 1000);
            Thread.Sleep(1000);
            Console.Beep(5000, 1000);
            Thread.Sleep(1000);
            Console.Beep(5000, 1000);
            Thread.Sleep(1000);
            Console.Beep(5000, 1000);
            Thread.Sleep(1000);
            Console.Beep(5000, 1000);
            Thread.Sleep(1000);
            Console.Beep(5000, 1000);
            Thread.Sleep(1000);
            Console.Beep(5000, 1000);
            Thread.Sleep(1000);
            Console.Beep(5000, 1000);
            Thread.Sleep(1000);
            Console.Beep(5000, 1000);
            Thread.Sleep(1000);
            Console.Beep(5000, 1000);
        }
        private void BtnTest_Click1(object sender, RoutedEventArgs e)
        {
            Question1.Visibility = Visibility.Hidden;
            Question2.Visibility = Visibility.Visible;
            ImgLock1.Source = unlocked;
        }

        private void ResetLock(object sender, RoutedEventArgs e)
        {
            Question1.Visibility = Visibility.Hidden;
            Question2.Visibility = Visibility.Hidden;
            Question3.Visibility = Visibility.Hidden;
            Question4.Visibility = Visibility.Hidden;
            Question5.Visibility = Visibility.Hidden;
            ImgLock1.Source = locked;
            ImgLock2.Source = locked;
            ImgLock3.Source = locked;
            ImgLock4.Source = locked;
            ImgLock5.Source = locked;
            TxtCode.Text = "";
            TxtQ3Vr1.Text = "";
            TxtQ3Vr2.Text = "";
            TxtQ3Vr3.Text = "";
            TxtQ3Vr4.Text = "";
            TxtQ4.Text = "";
            TxtQ5.Text = "";
            Timer();
        }
        private void ResetLock()
        {
            Question1.Visibility = Visibility.Hidden;
            Question2.Visibility = Visibility.Hidden;
            Question3.Visibility = Visibility.Hidden;
            Question4.Visibility = Visibility.Hidden;
            Question5.Visibility = Visibility.Hidden;
            ImgLock1.Source = locked;
            ImgLock2.Source = locked;
            ImgLock3.Source = locked;
            ImgLock4.Source = locked;
            ImgLock5.Source = locked;
            TxtCode.Text = "";
            TxtQ3Vr1.Text = "";
            TxtQ3Vr2.Text = "";
            TxtQ3Vr3.Text = "";
            TxtQ3Vr4.Text = "";
            TxtQ4.Text = "";
            TxtQ5.Text = "";
            Timer();
        }


        private void BtnUnlock_Click(object sender, RoutedEventArgs e)
        {
            if (TxtCode.Text.Equals("9752"))
            {
                Question2.Visibility = Visibility.Hidden;
                Question3.Visibility = Visibility.Visible;
                ImgLock2.Source = unlocked;
            }
            else
            {
                ResetLock();
            }
        }

        private void Timer()
        {
            LockMessageToggle();

            
            dispatcherTimer.Start();

        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Question1.Visibility = Visibility.Visible;
            LockMessageToggle();
            dispatcherTimer.Stop();
        }
        public void LockMessageToggle()
        {
            if (LockMessage.Visibility == Visibility.Hidden)
            {
                LockMessage.Visibility = Visibility.Visible;
            }else
            {
                LockMessage.Visibility = Visibility.Hidden;
            }
        }

        private void BtnQuestion3_Click(object sender, RoutedEventArgs e)
        {
            if(TxtQ3Vr1.Text.Equals("d") && TxtQ3Vr2.Text.Equals("d") && TxtQ3Vr3.Text.Equals("d") && TxtQ3Vr4.Text.Equals("dt"))
            {
                Question3.Visibility = Visibility.Hidden;
                Question4.Visibility = Visibility.Visible;
                ImgLock3.Source = unlocked;
            }
            else
            {
                ResetLock();
            }
        }

        private void BtnQuestion4_Click(object sender, RoutedEventArgs e)
        {
            if (TxtQ4.Text.Equals("1"))
            {
                Question4.Visibility = Visibility.Hidden;
                Question5.Visibility = Visibility.Visible;
                ImgLock4.Source = unlocked;
            }
            else
            {
                ResetLock();
            }
        }

        private void BtnQuestion5_Click(object sender, RoutedEventArgs e)
        {
            //1 - 7 - 3 - 4 - 6 - 7 - 3 - 2 - 1 - 4 - 7 - 6 - Charlie - 3 - 2 - 7 - 8 - 9 - 7 - 7 - 7 - 6 - 4 - 3 - Tango - 7 - 3 - 2 - Victor - 7 - 3 - 1 - 1 - 7 - 8 - 8 - 8 - 4 - 7 - 3 - 2 - 4 - 7 - 6 - 7 - 8 - 9 - 7 - 6 - 4 - 3 - 7 - 6-- >

            if (TxtQ5.Text.Equals("1,7,3,4,6,7,3,2,1,4,7,6,C,3,2,7,8,9,7,7,7,6,4,3,T,7,3,2,V,7,3,1,1,7,8,8,8,4,7,3,2,4,7,6,7,8,9,6,4,7,6"))
            {
                Question5.Visibility = Visibility.Hidden;
                ImgLock5.Source = unlocked;
                _timer.Stop();
                TxtDisarmed.Visibility = Visibility.Visible;
                bom = false;
            }
            else
            {
                ResetLock();
            }
        }


        private void MainWindow_Resize(object sender, SizeChangedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
    }
}
