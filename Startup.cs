using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Bot.Builder.Integration;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace botbuilder_integration_regression
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ICredentialProvider credentialProvider = new SimpleCredentialProvider(
                appId: "{{YOUR BOT APP ID HERE}}",
                password: "{{YOUR BOT PASSWORD}}"
            );

            // services.AddSingleton<IConfiguration>(this.configuration);

            services.AddBot<Bot>(options => {
                options.CredentialProvider = credentialProvider;
                options.Paths = new BotFrameworkPaths
                {
                    BasePath = "",
                    MessagesPath = ""  
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseBotFramework();
        }
    }
}
