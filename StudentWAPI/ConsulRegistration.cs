using Consul;

namespace StudentWAPI
{
    public static class ConsulRegistration
    {
        public static IServiceCollection ConfigureConsul(this IServiceCollection services)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = "http://localhost:8500";
                consulConfig.Address = new Uri(address);
            }));

            return services;
        }
        public static IApplicationBuilder RegisterWithConsul(this IApplicationBuilder app)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();

            var uri = new Uri("http://localhost:5001");
            var registration = new AgentServiceRegistration()
            {
                ID = $"StudentService",
                Name = $"StudentService",
                Address = $"{uri.Host}",
                Port = uri.Port,
                Tags = new[] { "Student Service", "Student" }
            };
            consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            consulClient.Agent.ServiceRegister(registration).Wait();

            return app;


        }
    }
}
