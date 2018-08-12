using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NorhanXamarinTrainingService.Startup))]

namespace NorhanXamarinTrainingService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}