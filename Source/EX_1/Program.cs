using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EX_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services
                        .AddSingleton<ICheck, AgeChecker>()
                        .AddSingleton<ICheck, GenderChecker>()
                        .AddSingleton<IPersonProcessor, PersonProcessor>())
                .Build();
        
            TestDI(host.Services);
        }
        public static void TestDI(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
        
            var personProcessor = provider.GetRequiredService<IPersonProcessor>();
            var Jack = new Person() { Name = "Jack", Age = 32, Gender = Gender.Man };
            var Jill = new Person() { Name = "Jill", Age = 17, Gender = Gender.Female };
        
            personProcessor.RunChecks(Jack);
            personProcessor.RunChecks(Jill);
        }
    }
}