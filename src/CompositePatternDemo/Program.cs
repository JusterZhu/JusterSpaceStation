namespace CompositePatternDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var leaf1 = new Leaf();
            var leaf2 = new Leaf();
            var composite1 = new Composite();
            composite1.Add(leaf1);
            composite1.Add(leaf2);

            var leaf3 = new Leaf();
            var composite2 = new Composite();
            composite2.Add(composite1);
            composite2.Add(leaf3);

            composite2.Operation(); // 调用树形结构的操作方法
            Console.Read();
        }
    }
}
