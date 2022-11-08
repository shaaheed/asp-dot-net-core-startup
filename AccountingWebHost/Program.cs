namespace AccountingWebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureLogging(opt =>
                    {
                        opt.SetMinimumLevel(LogLevel.Debug);
                        opt.AddConsole();
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}