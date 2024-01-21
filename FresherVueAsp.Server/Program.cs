var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("https://localhost:5173")
            .AllowCredentials();
    });
    options.AddPolicy("ProductionPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("https://fresher-vue-asp.vercel.app")
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
// app.UseDefaultFiles();
// app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("DevelopmentPolicy");
}
else
{
    app.UseCors("ProductionPolicy");
}

app.UseAuthorization();
app.MapControllers();
// app.MapFallbackToFile("/index.html");

app.Run();