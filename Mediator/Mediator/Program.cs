using System.Reflection.Metadata;
using static Mediator.UserX;

namespace Mediator
{
    public abstract class User
    {
        protected IChatMediator _chatMediator;
        protected string? _name;
        public User(string? _name)
        {
            this._name = _name;
        }

        public void SetChatMediator(ChatMediator chatMediator)
        {
            _chatMediator = chatMediator;
        }
        public abstract void SendMessage(string msg);
        public abstract void ReceiveMessage(string msg);
    }


    public class UserX : User
    {
        public UserX(string? name) : base(name) { }

        public override void ReceiveMessage(string msg)
        {
            Console.WriteLine($"{_name} recived message : {msg}");
        }

        public override void SendMessage(string msg)
        {
            Console.WriteLine($"{_name} sent message : {msg}");
            _chatMediator.SendMessage(msg,this);

        }
    }

    public class UserY : User
    {
        public UserY(string? name) : base(name) { }

        public override void ReceiveMessage(string msg)
        {
            Console.WriteLine($"{_name} recived message : {msg}");
        }

        public override void SendMessage(string msg)
        {
            Console.WriteLine($"{_name} sent message : {msg}");
            _chatMediator.SendMessage(msg, this);

        }
    }



    public interface IChatMediator
    {
        void SendMessage(string msg, User user);
        void AddUser(User user);
    }


    public class ChatMediator : IChatMediator
    {
        private readonly List<User> _users;
        public ChatMediator()
        {
            this._users = new List<User>();
        }
        public void AddUser(User user)
        {
            this._users.Add(user);
            user.SetChatMediator(this);
        }

        public void SendMessage(string msg, User sender)
        {
            foreach (var user in _users) 
            { 
                if(user!=sender)
                {
                    user.ReceiveMessage(msg);
                }
                
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           IChatMediator chatMediator = new ChatMediator();
            User userx=new UserX("Minion");
            User usery = new UserY("Shinchan");
            chatMediator.AddUser(userx);
            chatMediator.AddUser(usery);
            userx.SendMessage("Hello");
            usery.SendMessage("Hi");
        }
    }
}
