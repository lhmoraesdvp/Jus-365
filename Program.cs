using Jus_365.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Adicionar o filtro para p�ginas de erro do desenvolvedor (opcional)
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configurar o Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Adicionar controladores e views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Log para depura��o: Verifique se a connection string est� sendo carregada corretamente
Console.WriteLine($"Connection String: {connectionString}");

// Configura��o do pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    // Exibir o ponto de migra��o se estiver no ambiente de desenvolvimento
    app.UseMigrationsEndPoint();
}
else
{
    // Configura��o de produ��o
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Adicionar autentica��o
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
