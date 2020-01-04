using Microsoft.AspNetCore.Hosting;

namespace Player.WebUI.Common
{
    public static class HostingEnvironmentExtensions
    {
        public static bool IsDocker(this IWebHostEnvironment env)
        {
            return env.EnvironmentName == "Docker";
        }
    }
}
