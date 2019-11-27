namespace EasyConfig.SiteExtension.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json.Linq;

    [ApiController]
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

        [Route("")]
        [Route("environment")]
        [Route("environment.json")]
        public JToken GetEnvironment()
        {
            this.logger.LogInformation("Get Environment Config called.");

            return this.Serialize(this.easyconfig);
        }

        private JToken Serialize(IConfiguration config)
        {
            var childs = config.GetChildren();
            var isArray = childs.Any() && childs.All(child => int.TryParse(child.Key, out var number));

            if (isArray)
            {
                var obj = new JArray();

                foreach (var child in childs)
                {
                    obj.Add(this.Serialize(child));
                }

                return obj;
            }
            else
            {
                var obj = new JObject();

                foreach (var child in childs)
                {
                    obj.Add(child.Key, this.Serialize(child));
                }

                if (!obj.HasValues && config is IConfigurationSection section)
                {
                    return new JValue(section.Value);
                }

                return obj;
            }
        }
    }
}
