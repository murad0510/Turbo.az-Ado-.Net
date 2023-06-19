using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az__Ado.Net.DataAccess.Abstractions;

namespace Turbo.az__Ado.Net.DataAccess.Concrete
{
    public class EFIUnitOfWork : IUnitOfWork
    {
        public IBrandRepository IBrandRepository => new EFBrandRepository();

        public ICityRepository ICityRepository => new EFCityRepository();

        public IFuelRepository IFuelRepository => new EFFuelTypeRepository();

        public IModelRepository IModelRepository => new EFModelRepository();

        public IStatusRepository IStatusRepository => new EFStatusRepository();

        public IColorRepository IColorRepository => new EFColorRepository();

        public ICarRepository ICarRepository => new EFCarRepository();
    }
}
