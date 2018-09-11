using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class PurchaseOrder
    {
        public string PONumber { get; set; }
        public Vendor Vendor { get; set; }
        public List<LineItem> LineItems { get; set; }

    }

    public class Vendor
    {
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class LineItem
    {
        public int LineItemId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

}
