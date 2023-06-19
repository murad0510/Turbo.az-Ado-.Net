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
    public class EFStatusRepository : IStatusRepository
    {
        private TurboContext _context;

        public EFStatusRepository()
        {
            _context = new TurboContext();
        }
        public void AddData(Status data)
        {
            _context.Entry(data).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeleteData(Status data)
        {
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public ObservableCollection<Status> GetAll()
        {
            var result = from b in _context.Status
                         select b;

            return new ObservableCollection<Status>(result);
        }

        public Status GetData(int id)
        {
            var result = _context.Status.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void UpdateData(Status data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
