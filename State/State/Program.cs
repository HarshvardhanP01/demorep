namespace State
{
    public class Document
    {
        private IDocumentState _state;
        public Document()
        {
            _state = new DraftState();
        }
        public void SetState(IDocumentState state)
        {
            _state = state;
        }

        public void Draft()
        {
            _state.Draft(this);
        }

        public void Review()
        {
            _state.Review(this);
        }

        public void Publish()
        {
            _state.Publish(this);
        }
    }
    public interface IDocumentState
    {
        void Draft(Document document);
        void Review(Document document);
        void Publish(Document document);
    }

    public class DraftState : IDocumentState
    {
        public void Draft(Document document)
        {
            Console.WriteLine("Document is in Draft State.");
        }

        public void Publish(Document document)
        {
            Console.WriteLine("Can't publish as it is in Draf State.");
        }

        public void Review(Document document)
        {
            Console.WriteLine("Changing to Review State.");
            document.SetState(new ReviewState());
        }
    }

    public class ReviewState : IDocumentState
    {
        public void Draft(Document document)
        {
            Console.WriteLine("Changing Document State to Draft State.");
            document.SetState(new DraftState());
        }

        public void Publish(Document document)
        {
            Console.WriteLine("Changing Document State to Publish");
            document.SetState(new PublishState());
        }

        public void Review(Document document)
        {
            Console.WriteLine("Document is in Review State.");
        }
    }

    public class PublishState : IDocumentState
    {
        public void Draft(Document document)
        {
            Console.WriteLine("Can't State to Draft State.");
        }

        public void Publish(Document document)
        {
            Console.WriteLine("Document is in Publish State");
        }

        public void Review(Document document)
        {
            Console.WriteLine("Can't State to Review State.");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();
            document.Draft();
            document.Review();
            document.Publish();
            document.Publish();
            document.Review();
            document.Draft();
        }
    }
}
