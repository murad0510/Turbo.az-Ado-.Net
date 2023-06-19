using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Turbo.az__Ado.Net.DataAccess.Abstractions;
using Turbo.az__Ado.Net.DataAccess.Concrete;
using Turbo.az__Ado.Net.Entities;

namespace Turbo.az__Ado.Net
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;
        public App()
        {
            DB = new EFUnitOfWork();

            if (DB.cityRepository.GetAll().Count == 0)
            {
                DB.cityRepository.AddData(new City { Name = "Baku" });
                DB.cityRepository.AddData(new City { Name = "London" });
                DB.cityRepository.AddData(new City { Name = "Antalya" });
                DB.cityRepository.AddData(new City { Name = "Koln" });
            }

            if (DB.brandRepository.GetAll().Count == 0)
            {
                DB.brandRepository.AddData(new Brand { Name = "BMW" });
                DB.brandRepository.AddData(new Brand { Name = "Mescedes" });
                DB.brandRepository.AddData(new Brand { Name = "Lada" });
                DB.brandRepository.AddData(new Brand { Name = "Ferrari" });
                DB.brandRepository.AddData(new Brand { Name = "Rolls-Royce" });
                DB.brandRepository.AddData(new Brand { Name = "Bentley" });
                DB.brandRepository.AddData(new Brand { Name = "Porsche" });
                DB.brandRepository.AddData(new Brand { Name = "Tesla" });
            }


            if (DB.modelRepository.GetAll().Count == 0)
            {
                DB.modelRepository.AddData(new Model { Name = "IX", BrandId = 1 });
                DB.modelRepository.AddData(new Model { Name = "I8", BrandId = 1 });
                DB.modelRepository.AddData(new Model { Name = "I7", BrandId = 1 });
                DB.modelRepository.AddData(new Model { Name = "I4", BrandId = 1 });
                DB.modelRepository.AddData(new Model { Name = "I3", BrandId = 1 });

                DB.modelRepository.AddData(new Model { Name = "Benz S Class 400", BrandId = 2 });
                DB.modelRepository.AddData(new Model { Name = "GLS 63 AMG", BrandId = 2 });
                DB.modelRepository.AddData(new Model { Name = "GL Brabus Widestar", BrandId = 2 });
                DB.modelRepository.AddData(new Model { Name = "S 63 AMG", BrandId = 2 });

                DB.modelRepository.AddData(new Model { Name = "XRAY", BrandId = 3 });
                DB.modelRepository.AddData(new Model { Name = "Vesta SW Cross", BrandId = 3 });
                DB.modelRepository.AddData(new Model { Name = "Vesta SW", BrandId = 3 });
                DB.modelRepository.AddData(new Model { Name = "Largus", BrandId = 3 });
                DB.modelRepository.AddData(new Model { Name = "Priora", BrandId = 3 });

                DB.modelRepository.AddData(new Model { Name = "Ferrari Purosangue", BrandId = 4 });
                DB.modelRepository.AddData(new Model { Name = "Ferrari F8 Tributo", BrandId = 4 });
                DB.modelRepository.AddData(new Model { Name = "458 Spyder", BrandId = 4 });
                DB.modelRepository.AddData(new Model { Name = "Ferrari Roma", BrandId = 4 });
                DB.modelRepository.AddData(new Model { Name = "Ferrari 812", BrandId = 4 });

                DB.modelRepository.AddData(new Model { Name = "Rolls Royce Dawn", BrandId = 5 });
                DB.modelRepository.AddData(new Model { Name = "Rolls-Royce Cullinan", BrandId = 5 });
                DB.modelRepository.AddData(new Model { Name = "Rolls Royce Wraith", BrandId = 5 });
                DB.modelRepository.AddData(new Model { Name = "Rolls-Royce Ghost", BrandId = 5 });
                DB.modelRepository.AddData(new Model { Name = "Rolls-Royce Phantom", BrandId = 5 });

                DB.modelRepository.AddData(new Model { Name = "Bentley Continental", BrandId = 6 });
                DB.modelRepository.AddData(new Model { Name = "Bentley Flying Spur", BrandId = 6 });
                DB.modelRepository.AddData(new Model { Name = "Bentley Bentayga", BrandId = 6 });
                DB.modelRepository.AddData(new Model { Name = "Bentley Bentayga EWB", BrandId = 6 });

                DB.modelRepository.AddData(new Model { Name = "Porsche 911", BrandId = 7 });
                DB.modelRepository.AddData(new Model { Name = "Porsche Macan", BrandId = 7 });
                DB.modelRepository.AddData(new Model { Name = "Porsche Panamera", BrandId = 7 });
                DB.modelRepository.AddData(new Model { Name = "Porsche 718", BrandId = 7 });
                DB.modelRepository.AddData(new Model { Name = "Porsche Cayenne Coupe", BrandId = 7 });

                DB.modelRepository.AddData(new Model { Name = "Model S", BrandId = 8 });
                DB.modelRepository.AddData(new Model { Name = "Model 3", BrandId = 8 });
                DB.modelRepository.AddData(new Model { Name = "Model Y", BrandId = 8 });
            }
            if (DB.fuelRepository.GetAll().Count == 0)
            {
                DB.fuelRepository.AddData(new FuelType { Name = "Gasoline" });
                DB.fuelRepository.AddData(new FuelType { Name = "Gas" });
                DB.fuelRepository.AddData(new FuelType { Name = "Diesel" });
                DB.fuelRepository.AddData(new FuelType { Name = "Electron" });
                DB.fuelRepository.AddData(new FuelType { Name = "Hybrid" });
            }

            if (DB.cityRepository.GetAll().Count == 0)
            {
                DB.colorRepository.AddData(new CarColor { ColorName = "White" });
                DB.colorRepository.AddData(new CarColor { ColorName = "Black" });
                DB.colorRepository.AddData(new CarColor { ColorName = "Red" });
                DB.colorRepository.AddData(new CarColor { ColorName = "Green" });
                DB.colorRepository.AddData(new CarColor { ColorName = "Gray" });

            }

            if (DB.carRepository.GetAll().Count == 0)
            {
                //mercedes
                DB.carRepository.AddData(new Car { CityId = 1, ColorId = 1, ModelId = 6, Engine = "2.8", Km = 0.0, Price = 567.000M, Year = new DateTime(2020, 1, 1), CarImage = "https://cdni.autocarindia.com/Utils/ImageResizer.ashx?n=https://cdni.autocarindia.com/Reviews/20210630113205_S-class-static.jpg&c=0", FuelTypeId = 1, IsNew = true });
                DB.carRepository.AddData(new Car { CityId = 1, ColorId = 2, ModelId = 7, Engine = "3.0", Km = 0.0, Price = 148.000M, Year = new DateTime(2017, 1, 1), CarImage = "https://turbo.azstatic.com/uploads/full/2022%2F09%2F01%2F14%2F18%2F17%2F71f08c4f-aabf-4113-bc24-63af7134d5a8%2F56854_ptv6AjDCrrVXjMNJg1jejw.jpg", FuelTypeId = 1, IsNew = true });
                DB.carRepository.AddData(new Car { CityId = 1, ColorId = 1, ModelId = 8, Engine = "2.0", Km = 0.0, Price = 38.000M, Year = new DateTime(2019, 1, 1), CarImage = "https://www.motortrend.com/uploads/f/52840685.jpg?fit=around%7C874:546.25", FuelTypeId = 1, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 3, ModelId = 9, Engine = "2.0", Km = 0.0, Price = 67.000M, Year = new DateTime(2020, 1, 1), CarImage = "https://kolesa-uploads.ru/-/07929c67-a1fa-4e2e-a50b-aa9a6ea650b6/mercedes-amg-s63e-front2-mini.jpg.webp", FuelTypeId = 1, IsNew = false });

                //bmw
                DB.carRepository.AddData(new Car { CityId = 4, ColorId = 5, ModelId = 1, Engine = "3.0", Km = 0.0, Price = 99.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://soyacincau.com/wp-content/uploads/2023/01/01.-The-New-BMW-iX-xDrive50-Sport.jpg", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 1, ModelId = 2, Engine = "3.0", Km = 0.0, Price = 92.000M, Year = new DateTime(2023, 1, 1), CarImage = "https://cdni.autocarindia.com/Utils/ImageResizer.ashx?n=https://cdni.autocarindia.com/ExtraImages/20140501044626_bmw-i8-first-00122.jpg&w=726&h=482&q=75&c=1", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 2, ModelId = 3, Engine = "3.0", Km = 0.0, Price = 200.000M, Year = new DateTime(2023, 1, 1), CarImage = "https://cdn.motor1.com/images/mgl/8APgLe/s3/2023-bmw-i7.webp", FuelTypeId = 1, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 1, ModelId = 4, Engine = "3.0", Km = 0.0, Price = 300.000M, Year = new DateTime(2023, 1, 1), CarImage = "https://images.netdirector.co.uk/gforces-auto/image/upload/w_804,h_603,q_auto,c_fill,f_auto,fl_lossy/auto-client/f40d7a33227f3717a3dcdaf6522f7c2d/powerful_and_smooth.jpg", FuelTypeId = 1, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 1, ModelId = 5, Engine = "3.0", Km = 0.0, Price = 60.000M, Year = new DateTime(2023, 1, 1), CarImage = "https://assets-eu-01.kc-usercontent.com/3b3d460e-c5ae-0195-6b86-3ac7fb9d52db/d38e0995-bb9d-4d74-92e2-321ad60be776/BMW%20i3%20%289%29.jpg?width=1200&fm=jpg&auto=format", FuelTypeId = 1, IsNew = false });

                //LADA
                DB.carRepository.AddData(new Car { CityId = 4, ColorId = 5, ModelId = 1, Engine = "3.0", Km = 0.0, Price = 99.500M, Year = new DateTime(2023, 1, 1), CarImage = "            https://cdnstatic.rg.ru/crop910x607/uploads/images/193/89/13/XRAY_Instinct_2.jpg", FuelTypeId = 4, IsNew = false });


            }



        }
    }
}
