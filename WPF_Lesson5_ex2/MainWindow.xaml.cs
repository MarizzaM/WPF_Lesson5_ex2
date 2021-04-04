using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Lesson5_ex2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(() =>
            {
                while (true)
                {
                    SafeInvoker.SafeInvoke(this, ChangeColor);
                    Thread.Sleep(100);
                }
            });

        }
        private void ChangeColor()
        {
            Random random = new Random();

            List<SolidColorBrush> brushes = new List<SolidColorBrush>();
            brushes.Add(Brushes.AliceBlue);
            brushes.Add(Brushes.MediumSpringGreen);
            brushes.Add(Brushes.Violet);
            brushes.Add(Brushes.HotPink);
            brushes.Add(Brushes.Fuchsia);
            brushes.Add(Brushes.Gold);
            brushes.Add(Brushes.YellowGreen);
            brushes.Add(Brushes.DarkViolet);
            brushes.Add(Brushes.LightPink);
            brushes.Add(Brushes.BurlyWood);

            brdr1.BorderBrush = brushes[random.Next(10)];
            brdr2.BorderBrush = brushes[random.Next(10)];
            brdr3.BorderBrush = brushes[random.Next(10)];
        }

        private void SafeInvoke(Action work)
        {
            if (Dispatcher.CheckAccess())
            {
                work.Invoke();
                return;
            }
            this.Dispatcher.BeginInvoke(work);
        }
    }
}
