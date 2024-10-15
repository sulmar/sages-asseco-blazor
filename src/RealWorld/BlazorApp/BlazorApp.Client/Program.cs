using BlazorApp.Client.Pages;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

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

await builder.Build().RunAsync();
