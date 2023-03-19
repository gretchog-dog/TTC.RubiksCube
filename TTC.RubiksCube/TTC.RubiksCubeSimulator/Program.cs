using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TTC.RubiksCubeSimulator.Display;
using TTC.RubiksCubeSimulator.Manipulate;
using TTC.RubiksCubeSimulator.Rotate;

namespace TTC.RubiksCubeSimulator
{
    internal class RubiksCubeSimulator
    {
        public static Task Main()
        {
            using var host = CreateHostBuilder().Build();

            var scope = host.Services.CreateScope();
            var app = scope.ServiceProvider.GetService<ICubeManipulator>();

            app.Greet();

            return host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                    services
                    .AddSingleton<ICubeLayoutHandler, CubeLayoutHandler>()
                    .AddSingleton<ICubeRotator, CubeRotator>()
                    .AddSingleton<ICubeManipulator, CubeManipulator>()
                );
        }
    }
}