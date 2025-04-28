using GerenciamentoDePessoas.Data;
using GerenciamentoDePessoas.Models;
using GerenciamentoDePessoas.Repository;
using GerenciamentoDePessoas.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePessoas
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddDbContext<GerenciamentoDePessoasContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

            builder.Services.AddDbContext<GerenciamentoDePessoasContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPadrao")));

            builder.Services
              .AddDefaultIdentity<Usuario>(options =>
              options.SignIn.RequireConfirmedAccount = false)
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<GerenciamentoDePessoasContext>();
            // Add services to the container.


            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IPessoaService, PessoaService>();
            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();

            var app = builder.Build();

            // Chama o método para criar o admin
            //await CriarUsuarioAdminAsync(app);

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

            //Console.WriteLine("String de conexão: " +
            //builder.Configuration.GetConnectionString("DefaultConnection"));

            app.MapRazorPages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.Run();
            //async Task CriarUsuarioAdminAsync(WebApplication app)
            //{
            //    using var scope = app.Services.CreateScope();
            //    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();
            //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //    string adminEmail = "admin@email.com";
            //    string adminPassword = "Admin123!";

            //    if (await roleManager.FindByNameAsync("Administrador") == null)
            //    {
            //        await roleManager.CreateAsync(new IdentityRole("Administrador"));
            //    }

            //    if (await userManager.FindByEmailAsync(adminEmail) == null)
            //    {
            //        var user = new Usuario
            //        {
            //            UserName = adminEmail,
            //            Email = adminEmail,
            //            EmailConfirmed = true,
            //            CPF = "12345678900", // Exemplo de CPF

            //        };

            //        var result = await userManager.CreateAsync(user, adminPassword);
            //        if (result.Succeeded)
            //        {
            //            await userManager.AddToRoleAsync(user, "Administrador");
            //        }
            //    }
            //}
        }

    }
}
