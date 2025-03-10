using System.Reflection.Metadata;
using System.Text;
using AdvertiseService.Application.Common.Validators;
using AdvertiseService.Application.Features.Ads.Commands;
using AdvertiseService.Application.Mappings;
using AdvertiseService.Domain.Entities;
using AdvertiseService.Infrastructure;
using AdvertiseService.Infrastructure.Data;
using AdvertiseService.Infrastructure.Identity;
using AdvertiseService.Infrastructure.Services; 
using AdvertiseService.Presentation.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>());

// ثبت سرویس‌ها
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

// ثبت Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole<string>>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 8;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

////تعیین نقش‌ها (Roles)
//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();



builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// ثبت سرویس پس‌زمینه
builder.Services.AddHostedService<ExpiredAdsCleanupService>();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateAdCommandHandler).Assembly));


builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
// JWT Authentication

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

    .AddJwtBearer(options =>

    {

        options.TokenValidationParameters = new TokenValidationParameters

        {

            ValidateIssuer = true,

            ValidateAudience = true,

            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],

            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))

        };

    });

// Swagger

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>

{
    
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "سرویس آگهی", Version = "v1"});



    // اضافه کردن پشتیبانی برای احراز هویت JwtBearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = ""
        
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });




});

// ثبت JwtService در DI container
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<JwtSettings>();
//builder.Services.AddScoped<IOptions<JwtSettings>>();
builder.Services.AddScoped<AuthService>();



///authorize

//builder.Services.AddAuthentication("Bearer")
//    .AddJwtBearer("Bearer", options =>
//    {
//       // options.Authority = "https://your-auth-server";
//        options.Audience = "api";
//    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("role", "Admin");
    });
});










var app = builder.Build();




// اجرای Seed Data
using (var scope = app.Services.CreateScope())
{
    await SeedData.Initialize(scope.ServiceProvider);
}



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
// Configure the HTTP request pipeline

if (app.Environment.IsDevelopment())

{

    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "سرویس آگهی");
        c.RoutePrefix = string.Empty;
    });

}


app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Ads}/{action=Create}/{id?}");
});
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: " {controller=Ads}/{action=Create}");
//});

// میدلورها
//app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
//app.UseMiddleware<ExceptionHandlingMiddleware>();

//app.MapDefaultControllerRoute();

app.Run();
