using api.Data;
using api.Interfaces;
using api.Repositories;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DotNetEnv;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// โหลดค่าจากไฟล์ .env
DotNetEnv.Env.Load();
// สร้าง Configuration เพื่อใช้ตัวแปรสภาพแวดล้อม
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

// แทนที่ค่าตัวแปรสภาพแวดล้อมใน Connection String
string connectionString = configuration["ConnectionStrings:DefaultConnection"].Replace("${DB_SERVER}", Environment.GetEnvironmentVariable("DB_SERVER"))
    .Replace("${DB_DATABASE}", Environment.GetEnvironmentVariable("DB_DATABASE"))
    .Replace("${DB_USER}", Environment.GetEnvironmentVariable("DB_USER"))
    .Replace("${DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll",
//         builder =>
//         {
//             builder.AllowAnyOrigin()
//                    .AllowAnyHeader()
//                    .AllowAnyMethod();
//                 //    .AllowCredentials();
//         });
// });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // เปลี่ยนเป็นโดเมนของ Next.js ของคุณ
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});
// builder.Services.AddCors(options =>
// {
//     // options.AddPolicy("AllowLocalhost",
//     options.AddPolicy("AllowAll",
//         builder =>
//         {
//             // builder.WithOrigins("http://127.0.0.1:5500" )
//             builder.WithOrigins()
//                    .AllowAnyHeader()
//                    .AllowAnyMethod()
//                    .AllowCredentials();
//         });
// });

// Add Authentication
builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);
builder.Services.AddDbContext<AppDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// // Configure Database Contexts for SQL Server
// var connectionString1 = builder.Configuration.GetConnectionString("DefaultConnection");
// // var connectionString2 = builder.Configuration.GetConnectionString("PeRequestConnection");

// builder.Services.AddDbContext<AppDbContext>(options =>
// {
//     options.UseSqlServer(connectionString1);
// });

// builder.Services.AddDbContext<PeRequestDBContext>(options =>
// {
//     options.UseSqlServer(connectionString2);
// });
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmployee, EmployeeRepository>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseHttpsRedirection();
// app.UseCors("AllowLocalhost");

// app.UseCors("AllowAll");
app.UseCors("AllowSpecificOrigin"); // ใช้ CORS Policy ที่ได้กำหนดไว้
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();