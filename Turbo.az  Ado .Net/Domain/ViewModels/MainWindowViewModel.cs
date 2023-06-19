using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az__Ado.Net.DataAccess.Abstractions;
using Turbo.az__Ado.Net.DataAccess.Concrete;
using Turbo.az__Ado.Net.Domain.Views.UserControls;

namespace Turbo.az__Ado.Net.Domain.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IUnitOfWork unitOfWork;

        MainUserControl MainUserControl;
        MainUserControlViewModel MainUserControlViewModel;

        public MainWindowViewModel()
        {
            unitOfWork = new EFUnitOfWork();



            for (int i = 0; i < unitOfWork.carRepository.GetAll().Count; i++)
            {
                MainUserControl = new MainUserControl();
                MainUserControlViewModel = new MainUserControlViewModel();
                var model = unitOfWork.carRepository.GetAll()[i].ModelId;

                var brand = unitOfWork.brandRepository.GetData(model);

                MainUserControlViewModel.Price = unitOfWork.carRepository.GetAll()[i].Price;
                MainUserControlViewModel.CarImage = unitOfWork.carRepository.GetAll()[i].CarImage;

                MainUserControlViewModel.ModelAndBrand = brand.Name;

                MainUserControl.DataContext = MainUserControlViewModel;

                App.wrapPanel.Children.Add(MainUserControl);
            }
        }
    }
}
