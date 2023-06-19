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
    public class EFCarRepository : ICarRepository
    {
        private TurboContext _context;

        public EFCarRepository()
        {
            _context = new TurboContext();
        }
        public void AddData(Car data)
        {
            _context.Entry(data).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeleteData(Car data)
        {
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public ObservableCollection<Car> GetAll()
        {
            var result = from b in _context.Cars
                         select b;

            return new ObservableCollection<Car>(result);
        }

        public Car GetData(int id)
        {
            var result = _context.Cars.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void UpdateData(Car data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
