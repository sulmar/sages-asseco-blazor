using BlazorApp.Client.Services;
using BlazorApp.Components;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();


builder.Services.AddScoped<IAccountRepository, FakeAccountRepository>();

builder.Services.AddScoped<IEnumerable<Account>>(_ => new List<Account>
    {
        new Account { Id = 1, Number = "11110000", Balance = 100},
        new Account { Id = 2, Number = "22220000", Balance = 100 },
        new Account { Id = 3, Number = "33330000", Balance = 100, Status = AccountStatus.Closed },
        new Account { Id = 4, Number = "44440000", Balance = 100 },
        new Account { Id = 5, Number = "66660000", Balance = 100, Status = AccountStatus.Locked },
    }
);

builder.Services.AddHttpClient();
builder.Services.AddScoped<AccountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp.Client._Imports).Assembly);

app.MapGet("/api/accounts", (IAccountRepository repository) => repository.GetAll());

app.MapGet("/api/accounts/{id:int}", (IAccountRepository repository, int id) => repository.Get(id));

app.Run();
