namespace Flyweight
{
    public class TreeType
    {
        public string? Name { get;private set; }
        public string? color { get; private set; }
        public string? Texture { get; private set; }

        public TreeType(string? Name,string? color,string? Texture)
        {
            this.Name = Name;
            this.Texture = Texture;
            this.color = color;
        }

        public void Draw(int x,int y)
        {
            Console.WriteLine($"Drawing Tree of Type : {Name} at {x} , {y} with Color: {color} and Texture as {Texture}");
        }
    }

    public class TreeFactory
    {
        private static Dictionary<string, TreeType> treeTypes = new Dictionary<string, TreeType>();
        public static TreeType GetTreeType(string? name, string? color, string? texture)
        {
            string? key = $"{name}-{color}-{texture}";
            if (!treeTypes.ContainsKey(key))
            {
                treeTypes[key] = new TreeType(name, color, texture);
            }
            return treeTypes[key];
        }
    }

    public class Tree
    {
        private int x;
        private int y;
        private TreeType type;
        public Tree(int x,int y,TreeType type)
        {
            this.y = y;
            this.x = x;
            this.type = type;
        }

        public void Draw()
        {
            type.Draw(x,y);
        }
    }

    public class Forest
    {
        private List<Tree> _tree = new List<Tree>();
        public void PlantTree(int x, int y, string? name, string? color, string? texture)
        {
            TreeType type = TreeFactory.GetTreeType(name, color, texture);
            Tree tree = new Tree(x, y, type);
            _tree.Add(tree);
        }

        public void Draw()
        {
            foreach (Tree t in _tree)
            {
                t.Draw();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           Forest forest = new Forest();
            forest.PlantTree(2, 2, "Baniyan", "Green", "Double");
            forest.PlantTree(4, 5, "Oak", "Dark Green", "Single");
            forest.PlantTree(6, 2, "Neem", "Faint Green", "Smooth");
            forest.PlantTree(8, 8, "Pine", "Baby Green", "No");
            forest.PlantTree(1, 9, "Neem", "Solid Green", "Normal");
            forest.Draw();
        }
    }
}
