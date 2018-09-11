using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern.Builders
{
    public abstract class PurchaseOrderBuilder
    {
        public string PONumber { get; set; }
        public Vendor Vendor { get; set; }
        public List<LineItem> LineItems { get; set; }
        public PurchaseOrder PO { get; protected set; }
        public abstract void AddLineItems();
        public abstract void AddVendor();
    }

    public class CarPurchaseOrderBuilder : PurchaseOrderBuilder
    {
        public CarPurchaseOrderBuilder()
        {
            PO = new PurchaseOrder();
        }
        public override void AddLineItems()
        {
            PO.LineItems = new List<LineItem>
            {
                new LineItem
                {
                    LineItemId = 1,
                    Price = 89.00,
                    ProductName = "Porche",
                    Quantity = 1
                }
            };
        }

        public override void AddVendor()
        {
            PO.Vendor = new Vendor
            {
                Address = "RSA",
                Name = "Porchse",
                VendorId = 1
            };
        }
    }

    public class PurchaseOrderDirector
    {
        public void Construct(PurchaseOrderBuilder purchaseOrderBuilder)
        {
            purchaseOrderBuilder.AddLineItems();
            purchaseOrderBuilder.AddVendor();
        }
    }


    public interface IFluentPOBuilder
    {
        PurchaseOrder purchaseOrder { get; }
        IFluentPOBuilder WithPONumber(string poNumber);
        IFluentPOBuilder ForVendor(Vendor vendor);
        IFluentPOBuilder WithLineItems(List<LineItem> lineItems);
    }

    public class FluentPOBuilder : IFluentPOBuilder
    {
        public FluentPOBuilder()
        {
            purchaseOrder = new PurchaseOrder();
        }
        public PurchaseOrder purchaseOrder { get; private set; }

        public IFluentPOBuilder ForVendor(Vendor vendor)
        {
            purchaseOrder.Vendor = vendor;
            return this;
        }

        public IFluentPOBuilder WithLineItems(List<LineItem> lineItems)
        {
            purchaseOrder.LineItems = lineItems;
            return this;
        }

        public IFluentPOBuilder WithPONumber(string poNumber)
        {
            purchaseOrder.PONumber = poNumber;
            return this;
        }
    }
}
