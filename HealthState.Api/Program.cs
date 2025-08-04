using Serilog;

namespace HealthState

{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((ctx, lc) => lc.WriteTo.File(ctx.Configuration["logPath"],
                       fileSizeLimitBytes: 1_000_000,
                       rollOnFileSizeLimit: true,
                       shared: true,
                       flushToDiskInterval: TimeSpan.FromSeconds(1)))
            .UseSerilog((ctx, lc) => lc.WriteTo.Console())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

}
