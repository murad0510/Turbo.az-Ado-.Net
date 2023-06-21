using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Turbo.az__Ado.Net.Commands;
using Turbo.az__Ado.Net.DataAccess.Abstractions;
using Turbo.az__Ado.Net.DataAccess.Concrete;
using Turbo.az__Ado.Net.Domain.Views.UserControls;
using Turbo.az__Ado.Net.Entities;

namespace Turbo.az__Ado.Net.Domain.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand SelectionChanged { get; set; }

        public RelayCommand Show { get; set; }


        private ObservableCollection<Brand> brands;

        public ObservableCollection<Brand> Brands
        {
            get { return brands; }
            set { brands = value; OnPropertyChanged(); }
        }

        private Brand brand;

        public Brand Brand
        {
            get { return brand; }
            set { brand = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Model> models;

        public ObservableCollection<Model> Models
        {
            get { return models; }
            set { models = value; OnPropertyChanged(); }
        }

        private Model model;

        public Model Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged(); }
        }

        private bool isEnabledModel;

        public bool IsEnabledModel
        {
            get { return isEnabledModel; }
            set { isEnabledModel = value; OnPropertyChanged(); }
        }

        private CarColor color;

        public CarColor Color
        {
            get { return color; }
            set { color = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CarColor> colors;

        public ObservableCollection<CarColor> Colors
        {
            get { return colors; }
            set { colors = value; OnPropertyChanged(); }
        }

        private ObservableCollection<FuelType> fuelTypes;

        public ObservableCollection<FuelType> FuelTypes
        {
            get { return fuelTypes; }
            set { fuelTypes = value; OnPropertyChanged(); }
        }

        private FuelType fuelType;

        public FuelType FuelType
        {
            get { return fuelType; }
            set { fuelType = value; OnPropertyChanged(); }
        }


        private IUnitOfWork unitOfWork;

        MainUserControl MainUserControl;
        MainUserControlViewModel MainUserControlViewModel;

        public void AddUserControlInWrap(int index)
        {
            MainUserControl = new MainUserControl();
            MainUserControlViewModel = new MainUserControlViewModel();

            var car = unitOfWork.carRepository.GetData(index);

            var model = car.ModelId;

            var brand = unitOfWork.modelRepository.GetData(model);

            MainUserControlViewModel.Price = car.Price;

            MainUserControlViewModel.CarImage = car.CarImage;

            MainUserControlViewModel.Production = car.Year;

            var city = car.City;

            MainUserControlViewModel.City = city.Name;


            MainUserControlViewModel.Model = brand.Name;

            MainUserControlViewModel.Km = car.Km;

            MainUserControl.DataContext = MainUserControlViewModel;

            var fuelTypeId = car.FuelTypeId;

            var fuelType = unitOfWork.fuelRepository.GetData(fuelTypeId).Name;

            MainUserControlViewModel.Id = car.Id;

            MainUserControlViewModel.FuelType = fuelType;

            MainUserControlViewModel.Engine = car.Engine;

            MainUserControlViewModel.IsNew = car.IsNew;

            //MainUserControlViewModel.Car = GetAllCar[i];

            var colorId = unitOfWork.carRepository.GetData(index).ColorId;
            var color = unitOfWork.colorRepository.GetData(colorId).ColorName;

            MainUserControlViewModel.Color = color;

            App.wrapPanel.Children.Add(MainUserControl);
        }

        public MainWindowViewModel()
        {
            unitOfWork = new EFUnitOfWork();

            Brands = new ObservableCollection<Brand>();

            var BrandsCount = unitOfWork.brandRepository.GetAll();

            for (int i = 0; i < BrandsCount.Count; i++)
            {
                Brands.Add(BrandsCount[i]);
            }

            Models = new ObservableCollection<Model>();

            var ModelGetAll = unitOfWork.modelRepository.GetAll();

            SelectionChanged = new RelayCommand((obj) =>
            {
                IsEnabledModel = true;
                Models.Clear();
                for (int i = 0; i < ModelGetAll.Count; i++)
                {
                    if (ModelGetAll[i].BrandId == Brand.Id)
                    {
                        Models.Add(ModelGetAll[i]);
                    }
                }
            });

            Colors = new ObservableCollection<CarColor>();

            var colors = unitOfWork.colorRepository.GetAll();

            for (int i = 0; i < colors.Count; i++)
            {
                Colors.Add(colors[i]);
            }

            var GetAllCar = unitOfWork.carRepository.GetAll();

            for (int i = 1; i < GetAllCar.Count + 1; i++)
            {
                AddUserControlInWrap(i);
            }

            FuelTypes = new ObservableCollection<FuelType>();

            var FuelTypeGetAll = unitOfWork.fuelRepository.GetAll();

            for (int i = 0; i < FuelTypeGetAll.Count; i++)
            {
                FuelTypes.Add(FuelTypeGetAll[i]);
            }

            Show = new RelayCommand((obj) =>
            {
                if (Brand != null && Model != null && Color != null && FuelType != null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var modelId = carObj.ModelId;

                        var brandObj = unitOfWork.modelRepository.GetData(modelId).BrandId;

                        var color = unitOfWork.colorRepository.GetData(carObj.ColorId);

                        var fuel = unitOfWork.fuelRepository.GetData(carObj.FuelTypeId);


                        if (brandObj == Brand.Id && modelId == Model.Id && color.Id == Color.Id && fuel.Id == FuelType.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
                else if (Brand != null && FuelType != null && Model == null && Color == null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var modelId = carObj.ModelId;

                        var brandObj = unitOfWork.modelRepository.GetData(modelId).BrandId;

                        var color = unitOfWork.colorRepository.GetData(carObj.ColorId);


                        var fuel = unitOfWork.fuelRepository.GetData(carObj.FuelTypeId);

                        if (brandObj == Brand.Id && fuel.Id == FuelType.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
                else if (Brand != null && Model != null && Color != null && FuelType == null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var modelId = carObj.ModelId;

                        var brandObj = unitOfWork.modelRepository.GetData(modelId).BrandId;

                        var color = unitOfWork.colorRepository.GetData(carObj.ColorId);


                        if (brandObj == Brand.Id && modelId == Model.Id && color.Id == Color.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
                else if (Brand != null && Model != null && FuelType != null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var modelId = carObj.ModelId;

                        var brandObj = unitOfWork.modelRepository.GetData(modelId).BrandId;

                        var fuel = unitOfWork.fuelRepository.GetData(carObj.FuelTypeId);


                        if (brandObj == Brand.Id && modelId == Model.Id && fuel.Id == FuelType.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
                else if (Brand != null && Model != null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var modelId = carObj.ModelId;

                        var brandObj = unitOfWork.modelRepository.GetData(modelId).BrandId;

                        if (brandObj == Brand.Id && modelId == Model.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
                else if (Brand != null && Model == null && Color != null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count + 1; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var modelId = carObj.ModelId;

                        var brandObj = unitOfWork.modelRepository.GetData(modelId).BrandId;

                        var color = unitOfWork.colorRepository.GetData(carObj.ColorId);

                        if (brandObj == Brand.Id && color.Id == Color.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
                else if (Brand != null && Model == null && Color != null && FuelType != null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count + 1; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var modelId = carObj.ModelId;

                        var brandObj = unitOfWork.modelRepository.GetData(modelId).BrandId;

                        var color = unitOfWork.colorRepository.GetData(carObj.ColorId);

                        var fuel = unitOfWork.fuelRepository.GetData(carObj.FuelTypeId);


                        if (brandObj == Brand.Id && color.Id == Color.Id && fuel.Id == FuelType.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
                else if (Brand == null && Color != null && FuelType != null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count + 1; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var color = unitOfWork.colorRepository.GetData(carObj.ColorId);

                        var fuel = unitOfWork.fuelRepository.GetData(carObj.FuelTypeId);


                        if (color.Id == Color.Id && fuel.Id == FuelType.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
                else if (Brand == null && Color == null && FuelType != null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count + 1; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var fuel = unitOfWork.fuelRepository.GetData(carObj.FuelTypeId);


                        if (fuel.Id == FuelType.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
                else if (Brand == null && Color != null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count + 1; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var color = unitOfWork.colorRepository.GetData(carObj.ColorId);

                        if (color.Id == Color.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
                else if (Brand != null && Model == null)
                {
                    var GetAllCars = unitOfWork.carRepository.GetAll();

                    App.wrapPanel.Children.Clear();

                    for (int i = 1; i < GetAllCars.Count; i++)
                    {
                        var carObj = unitOfWork.carRepository.GetData(i);

                        var modelId = carObj.ModelId;

                        var brandObj = unitOfWork.modelRepository.GetData(modelId).BrandId;

                        if (brandObj == Brand.Id)
                        {
                            AddUserControlInWrap(i);
                        }
                    }
                }
            });
        }
    }
}
