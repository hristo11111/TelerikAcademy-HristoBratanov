using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsCatalog
{
    public class Producer
    {
        public string ProducerName { get; set; }
        public IEnumerable<CarModel> Models { get; set; }

        public Producer()
        {
            this.Models = new HashSet<CarModel>();
        }

        public int ProducerID { get; set; }
    }
}