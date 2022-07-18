using MvvmLightDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MvvmLightDemo.Views
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = new WinViewModel();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragDrop.DoDragDrop(this, "Rectangle", DragDropEffects.Copy);

        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(typeof(string)).ToString();
            if (data == "Rectangle")
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = 50;
                rectangle.Height = 100;
                rectangle.Fill = Brushes.Red;

                var point = e.GetPosition((IInputElement)sender);
              
                Canvas.SetLeft(rectangle,point.X);
                Canvas.SetTop(rectangle,point.Y);
                (sender as Canvas).Children.Add(rectangle);
            }
        }
    }
}
