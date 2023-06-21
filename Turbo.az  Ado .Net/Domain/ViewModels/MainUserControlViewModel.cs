using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Turbo.az__Ado.Net.Commands;
using Turbo.az__Ado.Net.DataAccess.Abstractions;
using Turbo.az__Ado.Net.DataAccess.Concrete;
using Turbo.az__Ado.Net.Domain.Views.UserControls;
using Turbo.az__Ado.Net.Entities;

namespace Turbo.az__Ado.Net.Domain.ViewModels
{
    public class MainUserControlViewModel : BaseViewModel
    {
        public RelayCommand CarClick { get; set; }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        //private Car car;

        //public Car Car
        //{
        //    get { return car; }
        //    set { car = value; OnPropertyChanged(); }
        //}



        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }

        private string modelAndBrand;

        public string Model
        {
            get { return modelAndBrand; }
            set { modelAndBrand = value; OnPropertyChanged(); }
        }

        private DateTime production;

        public DateTime Production
        {
            get { return production; }
            set { production = value; OnPropertyChanged(); }
        }

        private string carImage;

        public string CarImage
        {
            get { return carImage; }
            set { carImage = value; OnPropertyChanged(); }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(); }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; OnPropertyChanged(); }
        }

        private double km;

        public double Km
        {
            get { return km; }
            set { km = value; OnPropertyChanged(); }
        }

        private string fuelType;

        public string FuelType
        {
            get { return fuelType; }
            set { fuelType = value; OnPropertyChanged(); }
        }

        private bool isNew;

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; OnPropertyChanged(); }
        }

        private string engine;

        public string Engine
        {
            get { return engine; }
            set { engine = value; OnPropertyChanged(); }
        }

        private IUnitOfWork unitOfWork;

        public MainUserControlViewModel()
        {
            unitOfWork = new EFUnitOfWork();
            CarClick = new RelayCommand((obj) =>
            {
                App.wrapPanel.Children.Clear();

                CarUserControl carUserControl = new CarUserControl();
                CarUserControlViewModel carUserControlView = new CarUserControlViewModel();

                carUserControlView.CarImagePath = CarImage;
                carUserControlView.City = City;
                carUserControlView.Model = Model;
                carUserControlView.Price = Price;
                carUserControlView.Color = Color;
                carUserControlView.Km = Km;
                carUserControlView.Production = Production;
                carUserControlView.Engine = Engine;
                carUserControlView.FuelType = FuelType;
                carUserControlView.Id = Id;

                if (IsNew)
                {
                    carUserControlView.NewOrOld = "Yes";
                }
                else
                {
                    carUserControlView.NewOrOld = "No";
                }

                carUserControl.DataContext = carUserControlView;

                App.wrapPanel.Children.Add(carUserControl);

            });
        }

    }
}
