using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService
{
    public class InvoiceItem
    {
        public InvoiceItem()
        {
            Id = 0;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
