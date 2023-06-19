using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Turbo.az__Ado.Net.DataAccess.Abstractions;
using Turbo.az__Ado.Net.Entities;

namespace Turbo.az__Ado.Net.DataAccess.Concrete
{
    public class EFColorRepository : IColorRepository
    {
        private TurboContext _context;

        public EFColorRepository()
        {
            _context = new TurboContext();
        }
        public void AddData(CarColor data)
        {
            _context.Entry(data).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeleteData(CarColor data)
        {
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public ObservableCollection<CarColor> GetAll()
        {
            var result = from b in _context.Colors
                         select b;

            return new ObservableCollection<CarColor>(result);
        }

        public CarColor GetData(int id)
        {
            var result = _context.Colors.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void UpdateData(CarColor data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
