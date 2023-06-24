
namespace MyGC.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
    /*        if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }*/

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/", () => 
            {
                var barry = GenerateAndSelectABarry();

                GC.Collect(); 

                return barry 
                + Environment.NewLine
                + GC.GetTotalMemory(false) / 1024 / 1024 + "MB manged memory"
                + Environment.NewLine
                + Environment.WorkingSet / 1024 / 1024 + "MB total used";
            });

            app.Run();
        }

        static string GenerateAndSelectABarry() 
        {
            var barryGenerator = new BarryGenerator();
            var barrys = barryGenerator.GenerateBarrys();
            return barrys[new Random().Next(barrys.Count)];
        }
    }

    public class BarryGenerator 
    {
        public List<string>  GenerateBarrys() 
        {
            return Enumerable.Range(0, 10000000)
                .Select(i=> "Barry" + Guid.NewGuid().ToString()).ToList();
        }
    }
}