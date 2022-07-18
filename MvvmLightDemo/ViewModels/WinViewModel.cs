using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MvvmLightDemo.ViewModels
{
    public class WinViewModel
    {
        public ICommand MouseLeftCommand { get; set; }
        public ICommand DropCommand { get; set; }
        public ICommand DragEnterCommand { get; set; }
        public ICommand DragLeaveCommand { get; set; }
        private Canvas canvas;
        public WinViewModel()
        {
            MouseLeftCommand = new Command()
            {
                DoExecute = obj =>
                {
                    DragDrop.DoDragDrop((DependencyObject)obj, "Rectangle", DragDropEffects.Copy);
                }
            };
            DropCommand = new Command()
            {
                DoExecute = obj =>
                {
                    //DragEventArgs 
                    var e = obj as DragEventArgs;
                    var data = e.Data.GetData(typeof(string)).ToString();
                    if (data == "Rectangle")
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Width = 50;
                        rectangle.Height = 100;
                        rectangle.Fill = Brushes.Red;

                        var point = e.GetPosition(canvas);

                        Canvas.SetLeft(rectangle, point.X);
                        Canvas.SetTop(rectangle, point.Y);
                        canvas.Children.Add(rectangle);
                        canvas = null;
                    }
                }
            };
            DragEnterCommand = new Command()
            {
                DoExecute = obj =>
                {
                    //Canvas 
                    canvas = obj as Canvas;
                }
            };
            DragLeaveCommand = new Command()
            {
                DoExecute = obj =>
                {
                   
                }
            };
        }
    }
}
