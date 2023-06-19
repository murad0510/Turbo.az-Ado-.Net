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
    public class EFModelRepository : IModelRepository
    {
        private TurboContext _context;

        public EFModelRepository()
        {
            _context = new TurboContext();
        }
        public void AddData(Model data)
        {
            _context.Entry(data).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeleteData(Model data)
        {
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public ObservableCollection<Model> GetAll()
        {
            var result = from b in _context.Models
                         select b;

            return new ObservableCollection<Model>(result);
        }

        public Model GetData(int id)
        {
            var result = _context.Models.FirstOrDefault(b => b.Id == id);

            return result;
        }

        public void UpdateData(Model data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
