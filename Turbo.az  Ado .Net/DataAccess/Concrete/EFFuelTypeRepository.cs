using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbo.az__Ado.Net.DataAccess.Abstractions;
using Turbo.az__Ado.Net.Entities;

namespace Turbo.az__Ado.Net.DataAccess.Concrete
{
    public class EFFuelTypeRepository : IFuelRepository
    {

        private TurboContext _context;

        public EFFuelTypeRepository()
        {
            _context = new TurboContext();
        }
        public void AddData(FuelType data)
        {
            _context.Entry(data).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeleteData(FuelType data)
        {
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public ObservableCollection<FuelType> GetAll()
        {
            var result = from b in _context.FuelTypes
                         select b;

            return new ObservableCollection<FuelType>(result);
        }

        public FuelType GetData(int id)
        {
            var result = _context.FuelTypes.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void UpdateData(FuelType data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
