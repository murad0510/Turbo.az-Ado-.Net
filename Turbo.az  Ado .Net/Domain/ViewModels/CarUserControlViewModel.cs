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
    public class CarUserControlViewModel : BaseViewModel
    {
        public RelayCommand BackButton { get; set; }
        public RelayCommand BuyButton { get; set; }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }


        private Car car;

        public Car Car
        {
            get { return car; }
            set { car = value; OnPropertyChanged(); }
        }


        private string carImagePath;

        public string CarImagePath
        {
            get { return carImagePath; }
            set { carImagePath = value; OnPropertyChanged(); }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(); }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged(); }
        }

        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
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

        private DateTime production;

        public DateTime Production
        {
            get { return production; }
            set { production = value; OnPropertyChanged(); }
        }

        private string fuelType;

        public string FuelType
        {
            get { return fuelType; }
            set { fuelType = value; OnPropertyChanged(); }
        }

        private string newOrOld;

        public string NewOrOld
        {
            get { return newOrOld; }
            set { newOrOld = value; OnPropertyChanged(); }
        }

        private string engine;

        public string Engine
        {
            get { return engine; }
            set { engine = value; OnPropertyChanged(); }
        }



        private IUnitOfWork unitOfWork;

        MainUserControl MainUserControl;
        MainUserControlViewModel MainUserControlViewModel;

        public void Refresh()
        {
            var GetAllCar = unitOfWork.carRepository.GetAll();

            for (int i = 1; i < GetAllCar.Count + 1; i++)
            {
                MainUserControl = new MainUserControl();
                MainUserControlViewModel = new MainUserControlViewModel();

                var car = unitOfWork.carRepository.GetData(i);

                var model = car.ModelId;

                var brand = unitOfWork.modelRepository.GetData(model);

                MainUserControlViewModel.Price = car.Price;

                MainUserControlViewModel.CarImage = car.CarImage;

                MainUserControlViewModel.Production = car.Year;

                var fueltype=unitOfWork.fuelRepository.GetData(car.FuelTypeId);

                MainUserControlViewModel.FuelType = fueltype.Name;

                var city = car.City;

                MainUserControlViewModel.City = city.Name;

                MainUserControlViewModel.Model = brand.Name;

                MainUserControlViewModel.Engine = car.Engine;

                var colorId = car.ColorId;

                var color = unitOfWork.colorRepository.GetData(colorId).ColorName;

                MainUserControlViewModel.Color = color;

                MainUserControl.DataContext = MainUserControlViewModel;

                App.wrapPanel.Children.Add(MainUserControl);
            }
        }

        public CarUserControlViewModel()
        {
            unitOfWork = new EFUnitOfWork();

            BackButton = new RelayCommand((obj) =>
            {
                App.wrapPanel.Children.Clear();

                Refresh();

            });

            BuyButton = new RelayCommand((obj) =>
            {
                MessageBox.Show("Buy successfully");

                App.wrapPanel.Children.Clear();

                Refresh();

            });
        }
    }
}
