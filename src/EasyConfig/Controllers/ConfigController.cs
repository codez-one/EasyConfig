namespace EasyConfig.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route(".config")]
    public class ConfigController : ControllerBase
    {
        private readonly ILogger<ConfigController> logger;
        private readonly IConfigurationSection easyconfig;

        public ConfigController(
            IConfiguration configuration,
            ILogger<ConfigController> logger
        )
        {
            this.easyconfig = configuration.GetSection("EASYCONFIG");
            this.logger = logger;
        }

        [HttpGet("environment")]
        [HttpGet("environment.json")]
        public IEnumerable<IConfigurationSection> GetEnvironment()
        {
            this.logger.LogInformation("Get Environment Config called.");

            return this.easyconfig.GetChildren();
        }

        // public JToken Serialize(IConfiguration config)
        // {
        //     var obj = new JObject();
        //     foreach (var child in config.GetChildren())
        //     {
        //         obj.Add(child.Key, this.Serialize(child));
        //     }

        //     if (!obj.HasValues && config is IConfigurationSection section)
        //     {
        //         return new JValue(section.Value);
        //     }

        //     return obj;
        // }
    }
}
