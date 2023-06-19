using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az__Ado.Net.DataAccess.Concrete;

namespace Turbo.az__Ado.Net.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        IBrandRepository brandRepository { get; }
        ICityRepository cityRepository { get; }
        IFuelRepository fuelRepository { get; }
        IModelRepository modelRepository { get;  }
        IColorRepository colorRepository { get; }
        ICarRepository carRepository { get; }
    }
}
