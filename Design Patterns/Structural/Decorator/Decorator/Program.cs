
namespace Decorator
{
    public interface IMessage
    {
        string GetContent();
    }

    public class TextMessage : IMessage
    {
        private string _message;

        public TextMessage(string _message)
        {
            this._message = _message;
        }

        public string GetContent()
        {
            return _message;
        }
    }

    public abstract class MessageDecorator : IMessage
    {
        protected IMessage _message;

        protected MessageDecorator(IMessage _message)
        {
            this._message= _message;
        }
        public virtual string GetContent()
        {
            return _message.GetContent();
        }
    }

    public class EncryptedMessage : MessageDecorator
    {
        public EncryptedMessage(IMessage _message) : base(_message)
        {

        }

        public override string GetContent()
        {
            return Encrypt(_message.GetContent());
        }

        private string Encrypt(string v)
        {
            char[] charArray=v.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    public class CompressedMessage : MessageDecorator
    {
        public CompressedMessage(IMessage _message) : base(_message)
        {
        }
        public override string GetContent()
        {
            return Compress(_message.GetContent());
        }

        private string Compress(string v)
        {
            return v.Length > 5 ? v.Substring(0, 5) : v;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IMessage message = new TextMessage("Simple Text Message");
            Console.WriteLine($"Original Message : {message.GetContent()}");
            IMessage message1=new EncryptedMessage(message);
            Console.WriteLine($"Encrypted Message : {message1.GetContent()}");
            IMessage message2 = new CompressedMessage(message);
            Console.WriteLine($"Compressed Message : {message2.GetContent()}");
            IMessage message3=new CompressedMessage(message1);
            Console.WriteLine($"Compressed Encrypted Message : {message3.GetContent()}");
        }
    }
}
