using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodGroup.Models {

    public class Resturent {

        public string ID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public int isservicecharge { get; set; }
        public string CostPrice { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
    }

    public class ResturentObject {
        public List<Resturent> Resturent { get; set; }
    }
}
