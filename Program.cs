using FichaCompras.Business;
using FichaCompras.Data;
using FichaCompras.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Banco de dados em mem�ria
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("FichaComprasDb"));

// Inje��o de depend�ncia
builder.Services.AddScoped<SolicitacaoRepository>();
builder.Services.AddScoped<SolicitacaoService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Solicitacao}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Se n�o houver registros, insere alguns de teste
    if (!db.Solicitacoes.Any())
    {
        db.Solicitacoes.AddRange(
            new Solicitacao { Material = "Papel A4", Quantidade = 10, DataSolicitacao = DateTime.Now, Status = "Pendente" },
            new Solicitacao { Material = "Canetas", Quantidade = 20, DataSolicitacao = DateTime.Now, Status = "Pendente" },
            new Solicitacao { Material = "Grampeadores", Quantidade = 5, DataSolicitacao = DateTime.Now, Status = "Pendente" }
        );
        db.SaveChanges();
    }
}

app.Run();