using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace suvlasnici
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
                    webBuilder.UseStartup<Startup>();
                });



        [Authorize]
        public class PrivacyModel : PageModel
        {
            private readonly ILogger<PrivacyModel> _logger;

            public PrivacyModel(ILogger<PrivacyModel> logger)
            {
                _logger = logger;
            }

            public void OnGet()
            {
            }
        }
    }
}
    
    

