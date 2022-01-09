namespace EasyConfig.SiteExtension.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

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
    [Route("config")]
    [Route("config.json")]
    [Route("environment")]
    [Route("environment.json")]
    public JsonNode? GetEnvironment()
    {
        Logging.Controllers.Config.GetConfigRequested(this.logger);

        return Serialize(this.easyconfig);
    }

    private static JsonNode? Serialize(IConfiguration config)
    {
        var childs = config.GetChildren();
        var isArray = childs.Any() && childs.All(child => int.TryParse(child.Key, out var number));

        if (isArray)
        {
            var obj = new JsonArray();

            foreach (var child in childs)
            {
                obj.Add(Serialize(child));
            }

            return obj;
        }
        else
        {
            var obj = new JsonObject();

            foreach (var child in childs)
            {
                obj.Add(child.Key, Serialize(child));
            }

            if (obj.Count == 0 && config is IConfigurationSection section)
            {
                return JsonValue.Create(section.Value);
            }

            return obj;
        }
    }
}
