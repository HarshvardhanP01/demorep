namespace MyLibrary
{
    public class BaseClass
    {
        public string PublicMember = "Public";
        private string PrivateMember = "Private";
        protected string ProtectedMember = "Protected";
        internal string InternalMember = "Internal";
        protected internal string ProtectedInternal = "Protected Internal";
        private protected string PrivateProtected = "Private Protected";

        public void Display()
        {
            Console.WriteLine(PublicMember);
            Console.WriteLine(PrivateMember);
            Console.WriteLine(ProtectedMember);
            Console.WriteLine(InternalMember);
            Console.WriteLine(ProtectedInternal);
            Console.WriteLine(PrivateProtected);
        }

    }


    public class DerivedClass : BaseClass
    {
        public void DisplayBaseClass()
        {
            Console.WriteLine(PublicMember);
         //   Console.WriteLine(PrivateMember);
            Console.WriteLine(ProtectedMember);
            Console.WriteLine(InternalMember);
            Console.WriteLine(ProtectedInternal);
            Console.WriteLine(PrivateProtected);


            BaseClass obj= new BaseClass();
            Console.WriteLine(obj.PublicMember);
            Console.WriteLine(obj.ProtectedInternal);
            // Console.WriteLine(obj.PrivateMember);
          //  Console.WriteLine(obj.ProtectedMember);
            Console.WriteLine(obj.InternalMember);
            Console.WriteLine(obj.ProtectedInternal);
           // Console.WriteLine(obj.PrivateProtected);
        }
    }

    internal class InternalClass
    {
        public void DisplayBaseClass()
        {
            BaseClass obj = new BaseClass();
            Console.WriteLine(obj.PublicMember);
            Console.WriteLine(obj.ProtectedInternal);
            // Console.WriteLine(obj.PrivateMember);
            //  Console.WriteLine(obj.ProtectedMember);
            Console.WriteLine(obj.InternalMember);
            Console.WriteLine(obj.ProtectedInternal);
            // Console.WriteLine(obj.PrivateProtected);
        }
    }
}
