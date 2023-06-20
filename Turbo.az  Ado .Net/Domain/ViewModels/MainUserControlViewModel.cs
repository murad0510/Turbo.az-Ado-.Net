using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Turbo.az__Ado.Net.Commands;
using Turbo.az__Ado.Net.DataAccess.Abstractions;
using Turbo.az__Ado.Net.Domain.Views.UserControls;

namespace Turbo.az__Ado.Net.Domain.ViewModels
{
    public class MainUserControlViewModel : BaseViewModel
    {
        public RelayCommand CarClick { get; set; }

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


        public MainUserControlViewModel()
        {
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

                carUserControl.DataContext = carUserControlView;

                App.wrapPanel.Children.Add(carUserControl);
            });
        }

    }
}
