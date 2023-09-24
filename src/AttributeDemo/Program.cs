namespace AttributeDemo
{
    internal class Program
    {
 
        public class MyCustomAttribute : Attribute
        {
            public string Description { get; }

            public MyCustomAttribute(string description)
            {
                Description = description;
            }
        }

        [MyCustom("This is a custom attribute")]
        public class MyClass
        {
            // 类的定义
        }

        static void Main(string[] args)
        {
            MyCustomAttribute attribute = (MyCustomAttribute)Attribute.GetCustomAttribute(typeof(MyClass), typeof(MyCustomAttribute));

            if (attribute != null)
            {
                Console.WriteLine($"Description: {attribute.Description}");
            }
            Console.Read();
        }
    }
}
