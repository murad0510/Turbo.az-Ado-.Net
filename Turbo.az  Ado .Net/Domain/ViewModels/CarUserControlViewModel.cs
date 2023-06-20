using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az__Ado.Net.Commands;
using Turbo.az__Ado.Net.DataAccess.Abstractions;
using Turbo.az__Ado.Net.DataAccess.Concrete;
using Turbo.az__Ado.Net.Domain.Views.UserControls;

namespace Turbo.az__Ado.Net.Domain.ViewModels
{
    public class CarUserControlViewModel : BaseViewModel
    {
        public RelayCommand BackButton { get; set; }

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

        private IUnitOfWork unitOfWork;

        MainUserControl MainUserControl;
        MainUserControlViewModel MainUserControlViewModel;

        public CarUserControlViewModel()
        {
            BackButton = new RelayCommand((obj) =>
            {
                App.wrapPanel.Children.Clear();

                unitOfWork = new EFUnitOfWork();

                var GetAllCount = unitOfWork.carRepository.GetAll().Count;

                for (int i = 1; i < GetAllCount; i++)
                {
                    MainUserControl = new MainUserControl();
                    MainUserControlViewModel = new MainUserControlViewModel();
                    var model = unitOfWork.carRepository.GetAll()[i].ModelId;

                    var brand = unitOfWork.modelRepository.GetData(model);

                    MainUserControlViewModel.Price = unitOfWork.carRepository.GetData(i).Price;

                    MainUserControlViewModel.CarImage = unitOfWork.carRepository.GetData(i).CarImage;

                    MainUserControlViewModel.Production = unitOfWork.carRepository.GetData(i).Year;

                    var city = unitOfWork.carRepository.GetData(i).City;

                    MainUserControlViewModel.City = city.Name;

                    MainUserControlViewModel.Model = brand.Name;

                    MainUserControl.DataContext = MainUserControlViewModel;

                    var colorId = unitOfWork.carRepository.GetData(i).ColorId;
                    var color = unitOfWork.colorRepository.GetData(colorId).ColorName;

                    MainUserControlViewModel.Color = color;

                    App.wrapPanel.Children.Add(MainUserControl);
                }
            });
        }
    }
}
