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
        }
    }
}
