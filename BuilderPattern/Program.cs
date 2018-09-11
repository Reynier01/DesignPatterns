using BuilderPattern.Builders;
using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // HTML Builder
            Console.WriteLine("## Html Builder ##");
            HtmlBuilder htmlBuilder = new HtmlBuilder("ul");
            htmlBuilder.AddChild("il", "Reynier");
            Console.WriteLine(htmlBuilder);
            htmlBuilder.Clear();

            htmlBuilder.AddChildFluent("il", "Reynier")
                       .AddChildFluent("il", "Anneri");
            Console.WriteLine(htmlBuilder);
            Console.ReadLine();

            // PO Builder (Classic)
            Console.WriteLine("## Classic PO Builder ##");
            PurchaseOrderBuilder purchaseOrderBuilder = new CarPurchaseOrderBuilder();
            PurchaseOrderDirector purchaseOrderDirector = new PurchaseOrderDirector();
            purchaseOrderDirector.Construct(purchaseOrderBuilder);
            Console.WriteLine(purchaseOrderBuilder.PO.LineItems[0].ProductName);
            Console.ReadLine();

            // PO Builder (Fluent)
            Console.WriteLine("## Fluent PO Builder ##");
            IFluentPOBuilder fluentPOBuilder = new FluentPOBuilder();
            fluentPOBuilder.WithPONumber("Test")
                .WithLineItems(new List<LineItem> { new LineItem { ProductName = "TestProduct" } })
                .ForVendor(new Vendor() { Name = "My Vendor" });

            Console.WriteLine(fluentPOBuilder.purchaseOrder.LineItems[0].ProductName);
            Console.ReadLine();
        }
    }
}
