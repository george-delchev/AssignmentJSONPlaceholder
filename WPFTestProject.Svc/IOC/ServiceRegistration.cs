using WPFTestProject.Svc.Managers.Posts;
using Microsoft.Extensions.DependencyInjection;
using WPFTestProject.DataAccess.Repository.Posts;

namespace WPFTestProject.Svc
{
    public class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddHttpClient();
            
            //repository
            services.AddTransient<IPostsDataAccessRepository, CPostsAPIDataAccessRepository>();
            services.AddTransient<IPostsManager, CPostsManager>();

            //mappings
            services.AddAutoMapper(cfg => cfg.AddMaps("WPFTestProject.Svc"));
            //managers+            
        }
    }
}
