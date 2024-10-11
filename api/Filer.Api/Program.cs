using Filer.Api.Configurations;
using Filer.Api.Mappers;
using Filer.Application.Interfaces;
using Filer.Application.Services;
using Filer.DataAccess;
using Filer.DataAccess.Interfaces;
using Filer.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigurePostgresqlDatabase(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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
app.UseAuthorization();

app.MapControllers();
app.ConfigureExceptionHandler();
app.Run();
