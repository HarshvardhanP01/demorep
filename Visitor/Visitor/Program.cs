namespace Visitor
{
    public interface IElement
    {
        void accept(IVisitor visitor);
    }

    public interface IVisitor
    {
        void Visit(Report report);
        void Visit(Invoice invoice);
    }

    public class Report : IElement
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        
        public void accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Invoice : IElement
    {
        public string? InvoiceNumber{ get; set; }
        public double Amount { get; set; }
        public void accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class PrintVisitor : IVisitor
    {
        public void Visit(Report report)
        {
            Console.WriteLine($"Printing Report : {report.Title} \n Content: {report.Content}");
        }

        public void Visit(Invoice invoice)
        {
            Console.WriteLine($"Printing Invoice: {invoice.InvoiceNumber} \n Amount: {invoice.Amount}");
        }
    }

    public class ExportVisitor : IVisitor
    {
        public void Visit(Report report)
        {
            Console.WriteLine($"Exporting Report to PDF : {report.Title}");
        }

        public void Visit(Invoice invoice)
        {
            Console.WriteLine($"Exporting Invoice to PDF : {invoice.InvoiceNumber}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IElement> docs = new List<IElement>()
           {
               new Report()
               {
                   Title="TimeSheet",
                   Content="Info. about work you have done."
               },
               new Invoice()
               {
                   InvoiceNumber="OI-2024-25/001",
                   Amount=50919
               }
           };

            IVisitor p = new PrintVisitor();
            IVisitor e = new ExportVisitor();
            foreach (IElement doc in docs)
            {
                doc.accept(p);
                Console.WriteLine();
            }
            Console.WriteLine();

            foreach (IElement doc in docs)
            {
                doc.accept(e);
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }
}
