namespace RxNETDemo
{
    using System;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            IObservable<StockPrice> stockPrices = GetRealTimeStockPrices();

            IDisposable subscription = stockPrices
                .Where(price => price.Value > 100)
                .Subscribe(
                    price => Console.WriteLine($"High stock price detected: {price.Symbol} at {price.Value}"),
                    ex => Console.WriteLine($"OnError: {ex.Message}"),
                    () => Console.WriteLine("OnCompleted"));

            Console.Read( );

            // 在某个时刻，你可能想取消订阅
            subscription.Dispose();
        }

        class StockPrice
        {
            public string Symbol { get; set; }
            public double Value { get; set; }
        }

       static  IObservable<StockPrice> GetRealTimeStockPrices()
        {
            // 创建一个 Subject
            var subject = new Subject<StockPrice>();

            // 在后台线程上生成模拟数据
            Task.Run(() =>
            {
                var random = new Random();
                while (true)
                {
                    var price = new StockPrice
                    {
                        Symbol = "MSFT",
                        Value = 90 + (random.NextDouble() * 20)
                    };

                    // 向 Subject 发送新的价格
                    subject.OnNext(price);

                    // 暂停一段时间以模拟实时数据
                    Thread.Sleep(1000);
                }
            });

            // 返回 Observable
            return subject.AsObservable();
        }

    }

}
