using Microsoft.EntityFrameworkCore;
using mvc_f.NovaPasta1;

namespace mvc_f
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Contexto>
                (options => options.UseMySql(
                    "server=localhost;initial catalog=Crud_User;uid=root;pwd=Felix",
                    ServerVersion.Parse("8.0.36-mysql")));
            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
                pattern: "{controller=ClassUsers}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
