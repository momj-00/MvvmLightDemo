using MvvmLightDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmLightDemo.ViewModels
{
    public class MainViewModel
    {
        //TODO(02) ViewModel中声明对应的Model
        //页面中数据的绑定对象
        public MainModel MainModel { get; set; }
        //集合控件的绑定对象
        //ObservableCollection 集合子项变动通知 : 增减
        //1.子项中的属性变化 [1],KeyWord = "New Value" ; 变化 由通知来处理 PropertyChanged
        //2.增加一个子项,或上出一个子项  变化由集合对象来处理
        public ObservableCollection<MainModel> Datas { get; set; } = new ObservableCollection<MainModel>();
        public ICommand BtnCommand { get; set; }
        public MainViewModel()
        {
            //Model对象中Command的初始化
            MainModel = new MainModel()
            {
                BtnCommand = new Command()
                {
                    DoExecute = obj =>
                    {
                        //执行业务过程
                        this.Search(obj.ToString());
                    }
                }
            };
            //当前对象的Command初始化
            BtnCommand = new Command()
            {
                //obj = CommandParameter
                DoExecute = obj =>
                {
                    Datas.Remove(obj as MainModel);
                    //Datas.Remove(对象);
                    //Datas.RemoveAt(Index索引)
                }
            };

            //集合数据初始化;数据库
            Datas.Add(new MainModel()
            {
                KeyWord = "AAA",
                BtnCommand = new Command()
                {
                    DoExecute = obj => this.Search("AAA")
                }
            });
            Datas.Add(new MainModel() { KeyWord = "BBB", BtnCommand = new Command { DoExecute = DoBtnCommand } });
            Datas.Add(new MainModel() { KeyWord = "CCC", BtnCommand = new Command { DoExecute = DoBtnCommand } });
            Datas.Add(new MainModel() { KeyWord = "DDD", BtnCommand = new Command { DoExecute = DoBtnCommand } });
        }
        //从数据库查找相关关键词的数据
        //获取关键词
        //执行查找
        public void Search(string keyWord) //Search搜索
        {
            //页面 -> 数据模型中 ,正常
            //数据模型 -> 页面 不正常
            string kw = MainModel.KeyWord; //没有实际,目前与View无关
            //查找处理
            MainModel.KeyWord = keyWord;
        }
        private void DoBtnCommand(object? obj)
        {

        }
    }
    public class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }
        public void Execute(object? parameter)
        {
            //Command执行的时候,触发此方法
            DoExecute?.Invoke(parameter);
        }
        public Action<object?> DoExecute { get; set; }
    }
}
