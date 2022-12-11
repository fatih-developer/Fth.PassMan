using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Mongo.Repositories;
using DataAccess.Concrete.Mongo.Settings;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDB")
);
builder.Services.AddSingleton<IMongoDatabase>(options =>
{
    var settings = builder.Configuration.GetSection("MongoDB").Get<MongoDbSettings>();
    var client = new MongoClient(settings.ConnectionUri);
    return client.GetDatabase(settings.DatabaseName);
});
builder.Services.AddSingleton<IPasswordRepository, PasswordRepository>();
builder.Services.AddSingleton<IPasswordService, PasswordManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
