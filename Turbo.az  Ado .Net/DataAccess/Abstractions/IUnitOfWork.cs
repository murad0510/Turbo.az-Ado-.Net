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
        IBrandRepository IBrandRepository { get; }
        ICityRepository ICityRepository { get; }
        IFuelRepository IFuelRepository { get; }
        IModelRepository IModelRepository { get;  }
        IStatusRepository IStatusRepository { get; }
        IColorRepository IColorRepository { get; }
        ICarRepository ICarRepository { get; }
    }
}
