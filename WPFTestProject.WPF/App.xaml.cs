using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace AssignmentJSONPlaceholder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        protected void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
            
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            WPFTestProject.Svc.ServiceRegistration.RegisterServices(services);
        }
    }    
}

