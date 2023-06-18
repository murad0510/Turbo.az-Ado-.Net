using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Turbo.az__Ado.Net.DataAccess.Abstractions;

namespace Turbo.az__Ado.Net.DataAccess.Concrete
{
    public class ColorRepository : IColorRepository
    {
        private TurboContext _context;

        public ColorRepository()
        {
            _context = new TurboContext();
        }
        public void AddData(Color data)
        {
            _context.Entry(data).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeleteData(Color data)
        {
            _context.Entry(data).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public ObservableCollection<Color> GetAll()
        {
            throw new NotImplementedException();
        }

        public Color GetData(int id)
        {
            //var result = _context.Colors.FirstOrDefault(b => b.Id == id);

            //return result;
            throw new NotImplementedException();

        }

        public void UpdateData(Color data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
