using ActionHistoryApp.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient",
        builder =>
        {
            builder.WithOrigins("https://localhost:5001", 
                "http://localhost:5000",
                "https://localhost:7269",
                "http://localhost:5033")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});

// Настройка Entity Framework Core с SQL Server
builder.Services.AddDbContext<BlazingActionsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BlazingActionsContext>();

    // Только проверяем, что можем подключиться
    var canConnect = dbContext.Database.CanConnect();
    if (!canConnect)
    {
        // Логируем ошибку, но не прерываем запуск
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError("Не удалось подключиться к базе данных");
    }
    else
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Подключение к базе данных успешно");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();
app.UseCors("AllowBlazorClient");
app.UseAuthorization();
app.MapControllers();

app.Run();