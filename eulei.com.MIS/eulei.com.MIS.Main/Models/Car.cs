using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eulei.com.MIS.Main.Models
{
    public class Car
    {
        public string CarNo
        {
            get;
            set;
        }
        public string Owner
        {
            get;
            set;
        }
    }
    public class CarPark
    {
        private List<Car> _cars;
        public List<Car> InitCars()
        {
            _cars = new List<Car>(){
       new Car{CarNo="001",Owner="孟"},
       new Car{CarNo="002",Owner="帅"},
       new Car{CarNo="003",Owner="林"},
       new Car{CarNo="004",Owner="明"}
       };
            return _cars;
        }

    }
}
