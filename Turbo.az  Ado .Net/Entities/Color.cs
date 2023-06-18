using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az__Ado.Net.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
