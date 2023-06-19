using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az__Ado.Net.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public string Engine { get; set; }
        public double Km { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }
        public string CarImage { get; set; }
        public int FuelTypeId { get; set; }
        public bool IsNew { get; set; }


        public virtual Model Model { get; set; }
        public virtual City City { get; set; }
        public virtual CarColor Color { get; set; }
        public virtual FuelType FuelType { get; set; }

    }
}
