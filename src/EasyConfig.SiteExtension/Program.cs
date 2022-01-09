using EasyConfig.SiteExtension.AppConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEasyConfigAzureKeyVault();

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(
    options => options.JsonSerializerOptions.WriteIndented = true
);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
