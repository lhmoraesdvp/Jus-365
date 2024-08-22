using Jus_365.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Adicionar o filtro para páginas de erro do desenvolvedor (opcional)
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configurar o Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Adicionar controladores e views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Log para depuração: Verifique se a connection string está sendo carregada corretamente
Console.WriteLine($"Connection String: {connectionString}");

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    // Exibir o ponto de migração se estiver no ambiente de desenvolvimento
    app.UseMigrationsEndPoint();
}
else
{
    // Configuração de produção
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Adicionar autenticação
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
