namespace ChainOfResponsibility
{
    public class SupportRequest
    {
        public string? Description { get; set; }
        public int DifficultyLevel { get; set; }

        public SupportRequest(string? description, int difficultyLevel)
        {
            Description = description;
            DifficultyLevel = difficultyLevel;
        }
    }

    public abstract class SupportHandler
    {
        protected SupportHandler nextHandler;
        public void SetNextHandler(SupportHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }

        public abstract void HandleRequest(SupportRequest request);
    }

    public class BasicSupport : SupportHandler
    {
        public override void HandleRequest(SupportRequest request)
        {
            if(request.DifficultyLevel==1)
            {
                Console.WriteLine($"Basic Level Support : Handling request {request.Description}");
            }
            else if(nextHandler!=null)
            {
                nextHandler.HandleRequest(request);
            }
        }
    }

    public class AdvanceSupport : SupportHandler
    {
        public override void HandleRequest(SupportRequest request)
        {
            if (request.DifficultyLevel == 3)
            {
                Console.WriteLine($"Advance Level Support : Handling request {request.Description}");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleRequest(request);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           SupportHandler bhandler = new BasicSupport();
            SupportHandler aHandler = new AdvanceSupport();
            bhandler.SetNextHandler(aHandler);
            SupportRequest req1 = new SupportRequest("Login Failed",1);
            bhandler.HandleRequest(req1);
            req1.DifficultyLevel = 3;
            bhandler.HandleRequest(req1);
            req1.DifficultyLevel = 1;
            aHandler.HandleRequest(req1);
            req1.DifficultyLevel = 3;
            aHandler.HandleRequest(req1);
        }
    }
}
