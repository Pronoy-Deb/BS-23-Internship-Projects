using Product_Management_Application.Data;
using Microsoft.EntityFrameworkCore;
using Product_Management_Application.Repository;

var builder = WebApplication.CreateBuilder(args);
//Register the repository
builder.Services.AddScoped(typeof(IProductRepository<>), typeof(Repository<>));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews()
    .AddViewOptions(options => {
        options.HtmlHelperOptions.ClientValidationEnabled = true;
    });

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
