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
using System.Windows.Controls;
using static System.Net.WebRequestMethods;

namespace Turbo.az__Ado.Net
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;
        public static WrapPanel wrapPanel;
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

            if (DB.colorRepository.GetAll().Count == 0)
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
                DB.carRepository.AddData(new Car { CityId = 1, ColorId = 1, ModelId = 6, Engine = "2.8", Km = 0.0, Price = 567.000M, Year = new DateTime(2020, 1, 1), FuelTypeId = 1, IsNew = true, CarImage = "https://www.topgear.com/sites/default/files/2021/10/Large-39276-S-ClassSaloon.jpg?w=892&h=502" });
                DB.carRepository.AddData(new Car { CityId = 1, ColorId = 2, ModelId = 7, Engine = "3.0", Km = 0.0, Price = 148.000M, Year = new DateTime(2017, 1, 1), CarImage = "https://turbo.azstatic.com/uploads/full/2022%2F09%2F01%2F14%2F18%2F17%2F71f08c4f-aabf-4113-bc24-63af7134d5a8%2F56854_ptv6AjDCrrVXjMNJg1jejw.jpg", FuelTypeId = 1, IsNew = true });
                DB.carRepository.AddData(new Car { CityId = 1, ColorId = 1, ModelId = 8, Engine = "2.0", Km = 0.0, Price = 38.000M, Year = new DateTime(2019, 1, 1), CarImage = "https://www.motortrend.com/uploads/f/52840685.jpg?fit=around%7C874:546.25", FuelTypeId = 1, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 3, ModelId = 9, Engine = "2.0", Km = 0.0, Price = 67.000M, Year = new DateTime(2020, 1, 1), CarImage = "https://www.carandbike.com/_next/image?url=https%3A%2F%2Fimages.carandbike.com%2Fcms%2Farticles%2F3204456%2Farticles%2F3204491%2FMercedes_AMG_S_class_2022_12_06_T09_08_17_696_Z_ac77065ec2.jpg&w=828&q=75", FuelTypeId = 1, IsNew = false });

                //bmw
                DB.carRepository.AddData(new Car { CityId = 4, ColorId = 5, ModelId = 1, Engine = "5.0", Km = 0.0, Price = 99.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://soyacincau.com/wp-content/uploads/2023/01/01.-The-New-BMW-iX-xDrive50-Sport.jpg", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 1, ModelId = 2, Engine = "3.0", Km = 0.0, Price = 92.000M, Year = new DateTime(2023, 1, 1), CarImage = "https://cdni.autocarindia.com/Utils/ImageResizer.ashx?n=https://cdni.autocarindia.com/ExtraImages/20140501044626_bmw-i8-first-00122.jpg&w=726&h=482&q=75&c=1", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 2, ModelId = 3, Engine = "2.0", Km = 0.0, Price = 200.000M, Year = new DateTime(2023, 1, 1), CarImage = "https://technote.az/upload/bmw-i4-edrive35-adli-yeni-elektromobilini-teqdim-edib---qiymeti82.jpg", FuelTypeId = 1, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 1, ModelId = 4, Engine = "3.0", Km = 0.0, Price = 300.000M, Year = new DateTime(2023, 1, 1), CarImage = "https://images.netdirector.co.uk/gforces-auto/image/upload/w_804,h_603,q_auto,c_fill,f_auto,fl_lossy/auto-client/f40d7a33227f3717a3dcdaf6522f7c2d/powerful_and_smooth.jpg", FuelTypeId = 1, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 1, ModelId = 5, Engine = "7.0", Km = 0.0, Price = 60.000M, Year = new DateTime(2023, 1, 1), CarImage = "https://assets-eu-01.kc-usercontent.com/3b3d460e-c5ae-0195-6b86-3ac7fb9d52db/d38e0995-bb9d-4d74-92e2-321ad60be776/BMW%20i3%20%289%29.jpg?width=1200&fm=jpg&auto=format", FuelTypeId = 1, IsNew = false });

                //lada
                DB.carRepository.AddData(new Car { CityId = 3, ColorId = 5, ModelId = 10, Engine = "3.0", Km = 0.0, Price = 200.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://cdnstatic.rg.ru/crop910x607/uploads/images/193/89/13/XRAY_Instinct_2.jpg", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 1, ColorId = 1, ModelId = 11, Engine = "4.0", Km = 0.0, Price = 199.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://motor.ru/thumb/908x0/filters:quality(75):no_upscale()/imgs/2022/12/19/08/5719745/8810b116809165a0c2595daa9075ddcb1d848338.jpg", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 2, ColorId = 5, ModelId = 12, Engine = "3.0", Km = 0.0, Price = 399.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://turbo.azstatic.com/uploads/full/2020%2F06%2F19%2F11%2F46%2F33%2F5a55a264-11d1-46a1-9349-f9fc12f0717b%2F2412_BlzuYkBR_w1iEpFwrqLbMA.jpg", FuelTypeId = 4, IsNew = false });

                //ferrari
                DB.carRepository.AddData(new Car { CityId = 1, ColorId = 5, ModelId = 13, Engine = "4.0", Km = 0.0, Price = 209.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://squir.com/media/catalog/product/cache/4709fd52db70e8ed3553f7ffe9d447ff/f/e/ferrari_purosangue_2023_0000.jpg", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 2, ColorId = 1, ModelId = 14, Engine = "3.0", Km = 0.0, Price = 500.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://m.atcdn.co.uk/vms/media/3be3196042ec47b69a12ff7ceb29c22e.jpg", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 4, ColorId = 3, ModelId = 15, Engine = "5.0", Km = 0.0, Price = 700.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://www.driving.co.uk/wp-content/uploads/sites/5/2014/04/458.jpg", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 4, ColorId = 5, ModelId = 16, Engine = "2.6", Km = 0.0, Price = 900.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://www.motortrend.com/uploads/2023/04/2023-Ferrari-Roma-exterior-8.jpg?fit=around%7C875:492.1875", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 4, ColorId = 5, ModelId = 17, Engine = "3.0", Km = 0.0, Price = 800.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://www.mansory.com/sites/default/files/styles/1170_x_full_box_image/public/2022-10/Saleh%20-%20ABE6CF10-1B1F-4C74-960F-888F7FC89B4C.JPG?itok=eVDZceAK", FuelTypeId = 4, IsNew = false });

                //Rolls Royce
                DB.carRepository.AddData(new Car { CityId = 4, ColorId = 2, ModelId = 18, Engine = "6.0", Km = 0.0, Price = 1800.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://www.cnet.com/a/img/resize/cbd1491e95314f4e6e4429a0a6b10715971ccd4d/hub/2020/08/13/c8fe14c5-182a-4a3d-94b8-d404b935dbc3/rolls-royce-wraith-2020-09236.jpg?auto=webp&width=1200", FuelTypeId = 4, IsNew = false });
                DB.carRepository.AddData(new Car { CityId = 4, ColorId = 2, ModelId = 19, Engine = "6.0", Km = 0.0, Price = 1400.500M, Year = new DateTime(2023, 1, 1), CarImage = "https://www.cnet.com/a/img/resize/0fe84e1cc51e805fa3d497764e465cf1820ab973/hub/2020/03/11/81c30311-e2ac-475a-9312-f4c59c31eaf7/2020-rolls-royce-cullinan-black-badge-007.jpg?auto=webp&width=1200", FuelTypeId = 4, IsNew = false });

            }
        }
    }
}
