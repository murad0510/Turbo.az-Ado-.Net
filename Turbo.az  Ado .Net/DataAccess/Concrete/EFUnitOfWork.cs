using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az__Ado.Net.DataAccess.Abstractions;

namespace Turbo.az__Ado.Net.DataAccess.Concrete
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public IBrandRepository brandRepository => new EFBrandRepository();

        public ICityRepository cityRepository => new EFCityRepository();

        public IFuelRepository fuelRepository => new EFFuelTypeRepository();

        public IModelRepository modelRepository => new EFModelRepository();

        public IColorRepository colorRepository => new EFColorRepository();

        public ICarRepository carRepository => new EFCarRepository();
    }
}
