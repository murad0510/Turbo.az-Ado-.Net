using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Turbo.az__Ado.Net.Commands;
using Turbo.az__Ado.Net.DataAccess.Abstractions;

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

        public string ModelAndBrand
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


        public MainUserControlViewModel()
        {
            CarClick = new RelayCommand((obj) =>
            {
                MessageBox.Show("s");
            });
        }

    }
}
