using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLightDemo.Models
{
    public class MainModel : INotifyPropertyChanged
    {
        //TODO(继承INotifyPropertyChanged,属性中Set,PropertyChanged)
        //所有需要绑定到页面的都必须是属性
        //根据交互需求,创建相关属性
        //public string KeyWord { get; set; } = "Hello";
        private string keyWord = "Hello";

        public string KeyWord
        {
            get { return keyWord; }
            set
            {
                keyWord = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("KeyWord"));
            }
        }


        public ICommand BtnCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
