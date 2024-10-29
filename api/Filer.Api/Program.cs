using Filer.Api.Configurations;
using Filer.Api.Mappers;
using Filer.Application.Interfaces;
using Filer.Application.Interfaces.Auth;
using Filer.Application.Services;
using Filer.DataAccess.Interfaces;
using Filer.DataAccess.Repository;
using Filer.Infrastructure.Hashers;
using Filer.Infrastructure.JWT;
using Filer.Infrastructure.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.AddJwtAuthorization(builder.Configuration);
builder.Services.AddResponseCaching();
builder.Services.ConfigureControllersOptions();
builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection(nameof(AuthOptions)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigurePostgresqlDatabase(builder.Configuration);
builder.Services.ConfigureApiOptions();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider,JwtProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.AddCorsToApplication(builder.Configuration);
app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.ConfigureExceptionHandler();
app.Run();
