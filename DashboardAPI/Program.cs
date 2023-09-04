using DashboardAPI;
using DashboardAPI.Dto;

var builder = WebApplication.CreateBuilder(args);

DBKeys.AllowDomains = builder.Configuration.GetSection("AuthenticationKeys")["AllowDomains"];
DBKeys.Appkey = builder.Configuration.GetSection("AuthenticationKeys")["appkey"];
DBKeys.SecretKey = builder.Configuration.GetSection("AuthenticationKeys")["secretKey"];


// Add services to the container.
var services = builder.Services;
services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins(DBKeys.AllowDomains.Split(",").ToArray())
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();


// Configure the HTTP request pipeline.
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseRouting();

app.UseAuthorization();

app.UseCors();

app.UseCors("AllowOrigin");
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

// custom jwt auth middleware
app.UseMiddleware<AuthenticationMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
