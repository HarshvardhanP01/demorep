namespace ClientApp
{
    using MyLibrary;


    class der:BaseClass
    {
        public void Dis()
        {
            Console.WriteLine(PublicMember);
            Console.WriteLine(ProtectedInternal);
             //Console.WriteLine(PrivateMember);
              Console.WriteLine(ProtectedMember);
           // Console.WriteLine(InternalMember);
            Console.WriteLine(ProtectedInternal);
             //Console.WriteLine(PrivateProtected);
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            BaseClass obj = new BaseClass();
            /* Console.WriteLine(obj.PublicMember);
             Console.WriteLine(obj.ProtectedInternal);
             // Console.WriteLine(obj.PrivateMember);
             //  Console.WriteLine(obj.ProtectedMember);
             Console.WriteLine(obj.InternalMember);
             Console.WriteLine(obj.ProtectedInternal);*/
            // Console.WriteLine(obj.PrivateProtected);
            obj.Display();
           
        }
    }
}
