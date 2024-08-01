namespace Composite
{
    public interface IComponent
    {
        void Display(int Depth);
        int Size { get; }
    }

    public class File : IComponent
    {
        private string? _name;
        private int _size;

        public File(string? _name,int _size)
        {
            this._name = _name;
            this._size = _size;
        }

        public int Size => _size;

        public void Display(int Depth)
        {
            Console.WriteLine(new String('-',Depth)+ _name);
        }
    }

    public class Directory : IComponent
    {
        private string? _name;
        private List<IComponent> _components;

        public Directory(string? _name)
        {
            this._name= _name;
            _components=new List<IComponent>();
        }

        public void Add(IComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IComponent component)
        {
            _components.Remove(component);
        }
        public int Size
        {
            get
            {
                int size = 0;
                foreach (IComponent component in _components) 
                { 
                size += component.Size;
                }
                return size;
            }
        }
        public void Display(int Depth)
        {
            Console.WriteLine(new String('-', Depth) + _name);
            foreach (IComponent component in _components)
            {
                component.Display(Depth+2);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IComponent file1 = new File("File1.txt", 10);
            IComponent file2 = new File("File2.txt", 20);
            IComponent file3 = new File("File3.txt", 30);

            Directory dir1 = new Directory("Dir1");
            dir1.Add(file3);

            Directory dir2 = new Directory("Dir2");
            dir2.Add(file2);
            dir2.Add(file1);
            dir2.Add(dir1);

            Directory root = new Directory("Root");
            //root.Add(dir1);
           root.Add(dir2);

            root.Display(1);

            Console.WriteLine($"Total Size is {root.Size} kb");

        }
    }
}
