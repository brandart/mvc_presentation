using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.Model;

namespace V02_MVC.Object
{
    class Bill: ObservableObject
    {
        private int _idBill;
        public int IdBill
        {
            get
            {
                return _idBill
;
            }
            set
            {
                if(_idBill != value)
                {
                    _idBill = value;
                    RaisePropertyChanged("IdBill");
                }
            }
        }

        private DateTime _date;

        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                if(_date != value)
                {
                    _date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        private double _discount;
        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                if(_discount != value)
                {
                    _discount = value;
                    RaisePropertyChanged("Discount");
                }
            }
        }

        private Car _car;
        public Car Car
        {
            get
            {
                return _car;
            }
            set
            {
                _car = value;
                RaisePropertyChanged("Car");
            }
        }
        public bool IsFilled
        {
            get
            {
                if(Customer != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private Customer _customer;
        public Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
                RaisePropertyChanged("Customer");
            }
        }

        public object GetObject()
        {
            var root = new
            {
                date = Date,
                discount = Discount,
                customer = new
                {
                    idCustomer = Customer.IdCustomer
                },
                car = new
                {
                    idCar = Car.IdCar
                }
            };
            return root;
        }
    }
}
