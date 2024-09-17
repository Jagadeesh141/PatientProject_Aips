using ServiceContracts;
using Services;
using Microsoft.EntityFrameworkCore;
using Entities;

using Entities.IdentityEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "User Management API ", Version = "v1" });
});

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IPatientService, PatientService>();



builder.Services.AddDbContext<PatientsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbServerConnection"));
});


//Enabel Identity in this Project
builder.Services.AddIdentity<User, Role>(Options =>
{
    Options.Password.RequiredLength = 8;
    Options.Password.RequireNonAlphanumeric = false; //special char required
    Options.Password.RequireUppercase = false;
    Options.Password.RequireLowercase = true;
    Options.Password.RequireDigit = false;
    Options.Password.RequiredUniqueChars = 3;



})
    .AddEntityFrameworkStores<PatientsDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<User, Role, PatientsDbContext, Guid>>()
    .AddRoleStore<RoleStore<Role, PatientsDbContext,Guid>>();


builder.Services.AddAuthorization(Options =>
{
    Options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
});

builder.Services.ConfigureApplicationCookie(Options =>
{
    Options.LoginPath = "/Accounts/Login";
});


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Management API V1");
});


if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

}

Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");


app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();



app.Run();
