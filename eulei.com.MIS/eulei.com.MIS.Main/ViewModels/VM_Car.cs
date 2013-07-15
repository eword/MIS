using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eulei.com.MIS.Main.Models;
using eulei.com.MIS.Main.Commands;
using System.Windows.Input;
using System.Windows;
namespace eulei.com.MIS.Main.ViewModels
{
    public class VM_Car
    {
        public List<Car> cars { get; set; }
        public VM_Car()
        {
            //构造函数中初始化家庭成员列表  
            cars = new CarPark().InitCars();
        }
        RelayCommand addItem = null;
        public ICommand AddItem
        {
            get
            {
                if (addItem == null)
                    addItem = new RelayCommand((p) => OnAddItem(p), (p) => CanAddItem(p));
                return addItem;
            }
        }
        void OnAddItem(object p)
        {
            MessageBox.Show("添加成功");
        }
        bool CanAddItem(object p)
        {
            return true;
        }

    }
}
