namespace ObserverPatternDemo
{
    using System;
    using System.Collections.Generic;

    // 定义观察者接口
    public interface IObserver<T>
    {
        void Update(T data);
    }

    // 定义被观察者接口
    public interface IObservable<T>
    {
        void Attach(IObserver<T> observer);
        void Detach(IObserver<T> observer);
        void Notify(T data);
    }

    // 实现被观察者
    public class Subject<T> : IObservable<T>
    {
        private List<IObserver<T>> observers = new List<IObserver<T>>();

        public void Attach(IObserver<T> observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver<T> observer)
        {
            observers.Remove(observer);
        }

        public void Notify(T data)
        {
            foreach (var observer in observers)
            {
                observer.Update(data);
            }
        }
    }

    // 实现观察者
    public class ConcreteObserver<T> : IObserver<T>
    {
        private string name;

        public ConcreteObserver(string name)
        {
            this.name = name;
        }

        public void Update(T data)
        {
            Console.WriteLine($"{name} 收到数据: {data}");
        }
    }

    class Program
    {
        static void Main()
        {
            Subject<int> subject = new Subject<int>();
            var observer1 = new ConcreteObserver<int>("Observer 1");
            var observer2 = new ConcreteObserver<int>("Observer 2");

            subject.Attach(observer1);
            subject.Attach(observer2);

            subject.Notify(42);

            subject.Detach(observer1);

            subject.Notify(99);
        }
    }

    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Subject subject = new Subject();

    //        // 创建两个观察者，每个观察者只关注自己想要的数据
    //        IObserver observer1 = new SpecificObserver("A");
    //        IObserver observer2 = new SpecificObserver("B");

    //        // 订阅观察者
    //        subject.DataChanged += observer1.Update;
    //        subject.DataChanged += observer2.Update;

    //        // 模拟数据变化
    //        subject.NotifyObservers("A");
    //        subject.NotifyObservers("B");
    //        subject.NotifyObservers("C"); // 观察者不会处理此数据

    //        Console.ReadLine();
    //    }
    //}
}
