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

namespace Turbo.az__Ado.Net.Domain.ViewModels
{
    public class MainUserControlViewModel : BaseViewModel
    {
        public RelayCommand CarClick { get; set; }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


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
            set { color = value; }
        }

        private IUnitOfWork unitOfWork;

        MainUserControl MainUserControl;
        MainUserControlViewModel MainUserControlViewMode;

        public MainUserControlViewModel()
        {
            unitOfWork = new EFUnitOfWork();
            CarClick = new RelayCommand((obj) =>
            {
                App.wrapPanel.Children.Clear();

                var modelCar = unitOfWork.carRepository.GetData(Id).ModelId;

                var brandCar = unitOfWork.modelRepository.GetData(modelCar);

                var brandc=unitOfWork.brandRepository.GetData(brandCar.BrandId);

                CarUserControl carUserControl = new CarUserControl();
                CarUserControlViewModel carUserControlView = new CarUserControlViewModel();

                carUserControlView.CarImagePath = CarImage;
                carUserControlView.City = City;
                carUserControlView.Model = Model;
                carUserControlView.Price = Price;
                carUserControlView.Color = Color;

                carUserControl.DataContext = carUserControlView;

                App.wrapPanel.Children.Add(carUserControl);

                var count = unitOfWork.carRepository.GetAll().Count;

                for (int i = 1; i < count; i++)
                {
                    var model = unitOfWork.carRepository.GetAll()[i].ModelId;

                    var brand = unitOfWork.modelRepository.GetData(model);
                    if (brand.BrandId == brandc.Id)
                    {
                        MainUserControl = new MainUserControl();
                        MainUserControlViewMode = new MainUserControlViewModel();

                        MainUserControlViewMode.Price = unitOfWork.carRepository.GetData(i).Price;

                        MainUserControlViewMode.CarImage = unitOfWork.carRepository.GetData(i).CarImage;

                        MainUserControlViewMode.Production = unitOfWork.carRepository.GetData(i).Year;

                        var city = unitOfWork.carRepository.GetData(i).City;

                        MainUserControlViewMode.City = city.Name;

                        MainUserControlViewMode.Id = unitOfWork.carRepository.GetData(i).Id;

                        MainUserControlViewMode.Model = brand.Name;

                        MainUserControl.DataContext = MainUserControlViewMode;

                        var colorId = unitOfWork.carRepository.GetData(i).ColorId;
                        var color = unitOfWork.colorRepository.GetData(colorId).ColorName;

                        MainUserControlViewMode.Color = color;

                        App.wrapPanel.Children.Add(MainUserControl);
                    }
                }
            });
        }

    }
}
