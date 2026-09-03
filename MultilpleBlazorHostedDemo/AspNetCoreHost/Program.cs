using AspNetCoreHost.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();




app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/BlazorApp1"), app1 => 
{
    app1.UseBlazorFrameworkFiles("/BlazorApp1");
    app1.UseEndpoints(endpoints =>
    {
        endpoints.MapFallbackToFile("/BlazorApp1/{*path:nonfile}",
            "BlazorApp1/index.html");
    });
});

app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/BlazorApp2"), app2 =>
{
    app2.UseBlazorFrameworkFiles("/BlazorApp2");
    app2.UseEndpoints(endpoints =>
    {
        endpoints.MapFallbackToFile("/BlazorApp2/{*path:nonfile}",
            "BlazorApp2/index.html");
    });
});

app.Run();
