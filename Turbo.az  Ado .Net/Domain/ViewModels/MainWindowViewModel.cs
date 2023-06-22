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

            MainUserControlViewModel.FuelType = fuelType;

            MainUserControlViewModel.Engine = car.Engine;

            MainUserControlViewModel.IsNew = car.IsNew;

            var colorId = unitOfWork.carRepository.GetData(index).ColorId;
            var color = unitOfWork.colorRepository.GetData(colorId).ColorName;

            MainUserControlViewModel.Color = color;

            App.wrapPanel.Children.Add(MainUserControl);
        }

        public void PlaceTheData()
        {
            unitOfWork = new EFUnitOfWork();

            Brands = new ObservableCollection<Brand>();

            var BrandsCount = unitOfWork.brandRepository.GetAll();

            Brands.Clear();
            Brand brand = new Brand();
            brand.Name = "None";

            Brands.Add(brand);

            for (int i = 0; i < BrandsCount.Count; i++)
            {
                Brands.Add(BrandsCount[i]);
            }


            Models = new ObservableCollection<Model>();

            var ModelGetAll = unitOfWork.modelRepository.GetAll();

            SelectionChanged = new RelayCommand((obj) =>
            {
                if (Brand.Name != "None")
                {
                    IsEnabledModel = true;
                    Models.Clear();

                    Model model = new Model();
                    model.Name = "None";

                    Models.Add(model);

                    for (int i = 0; i < ModelGetAll.Count; i++)
                    {
                        if (ModelGetAll[i].BrandId == Brand.Id)
                        {
                            Models.Add(ModelGetAll[i]);
                        }
                    }
                }
                else
                {
                    Model = Models[0];
                    IsEnabledModel = false;
                }
            });

            Colors = new ObservableCollection<CarColor>();

            var colors = unitOfWork.colorRepository.GetAll();
            Colors.Clear();

            CarColor color = new CarColor();
            color.ColorName = "None";

            Colors.Add(color);

            for (int i = 0; i < colors.Count; i++)
            {
                Colors.Add(colors[i]);
            }

            FuelTypes = new ObservableCollection<FuelType>();

            var FuelTypeGetAll = unitOfWork.fuelRepository.GetAll();

            FuelType fuelType = new FuelType();
            fuelType.Name = "None";

            FuelTypes.Add(fuelType);

            for (int i = 0; i < FuelTypeGetAll.Count; i++)
            {
                FuelTypes.Add(FuelTypeGetAll[i]);
            }

            var GetAllCar = unitOfWork.carRepository.GetAll();

            for (int i = 0; i < GetAllCar.Count; i++)
            {
                AddUserControlInWrap(GetAllCar[i].Id);
            }

        }

        public MainWindowViewModel()
        {
            unitOfWork = new EFUnitOfWork();

            PlaceTheData();

            Show = new RelayCommand((obj) =>
            {
                var GetAllCars = unitOfWork.carRepository.GetAll();

                if (Brand != null)
                {
                    App.wrapPanel.Children.Clear();

                    if (Brand.Name != "None")
                    {
                        ObservableCollection<Car> cars = new ObservableCollection<Car>();

                        for (int i = 0; i < GetAllCars.Count; i++)
                        {
                            var car = unitOfWork.carRepository.GetData(GetAllCars[i].Id);

                            var modelId = car.ModelId;

                            var brandId = unitOfWork.modelRepository.GetData(modelId).BrandId;

                            if (brandId == Brand.Id)
                            {
                                AddUserControlInWrap(GetAllCars[i].Id);
                                cars.Add(GetAllCars[i]);
                            }
                        }
                        GetAllCars = cars;
                    }
                    else
                    {
                        for (int i = 0; i < GetAllCars.Count; i++)
                        {
                            AddUserControlInWrap(GetAllCars[i].Id);
                        }
                    }
                }
                if (Model != null)
                {
                    App.wrapPanel.Children.Clear();

                    if (Model.Name != "None")
                    {
                        ObservableCollection<Car> getcars = new ObservableCollection<Car>();
                        for (int i = 0; i < GetAllCars.Count; i++)
                        {
                            var car = GetAllCars[i];

                            if (car.ModelId == Model.Id)
                            {
                                AddUserControlInWrap(car.Id);
                                getcars.Add(GetAllCars[i]);
                            }
                        }
                        GetAllCars = getcars;
                    }
                    else
                    {
                        for (int i = 0; i < GetAllCars.Count; i++)
                        {
                            AddUserControlInWrap(GetAllCars[i].Id);
                        }
                    }
                }
                if (Color != null)
                {
                    App.wrapPanel.Children.Clear();
                    if (Color.ColorName != "None")
                    {
                        ObservableCollection<Car> getcars = new ObservableCollection<Car>();
                        if (GetAllCars.Count != 0)
                        {
                            for (int i = 0; i < GetAllCars.Count; i++)
                            {
                                var car = GetAllCars[i];

                                if (car.ColorId == Color.Id)
                                {
                                    AddUserControlInWrap(car.Id);
                                    getcars.Add(GetAllCars[i]);
                                }
                            }
                            GetAllCars = getcars;
                        }
                        else
                        {
                            for (int i = 0; i < GetAllCars.Count; i++)
                            {
                                var car = GetAllCars[i];

                                if (car.ColorId == Color.Id)
                                {
                                    AddUserControlInWrap(car.Id);
                                    getcars.Add(GetAllCars[i]);
                                }
                            }
                            GetAllCars = getcars;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < GetAllCars.Count; i++)
                        {
                            AddUserControlInWrap(GetAllCars[i].Id);
                        }
                    }
                }
                if (FuelType != null)
                {
                    App.wrapPanel.Children.Clear();
                    if (FuelType.Name != "None")
                    {
                        ObservableCollection<Car> getcars = new ObservableCollection<Car>();
                        if (GetAllCars.Count != 0)
                        {
                            for (int i = 0; i < GetAllCars.Count; i++)
                            {
                                var car = GetAllCars[i];

                                if (car.FuelTypeId == FuelType.Id)
                                {
                                    AddUserControlInWrap(car.Id);
                                    getcars.Add(GetAllCars[i]);
                                }
                            }
                            GetAllCars = getcars;
                        }
                        else
                        {
                            for (int i = 0; i < GetAllCars.Count; i++)
                            {
                                var car = GetAllCars[i];

                                if (car.FuelTypeId == FuelType.Id)
                                {
                                    AddUserControlInWrap(car.Id);
                                    getcars.Add(GetAllCars[i]);
                                }
                            }
                            GetAllCars = getcars;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < GetAllCars.Count; i++)
                        {
                            AddUserControlInWrap(GetAllCars[i].Id);
                        }
                    }
                }
            });
        }
    }
}
