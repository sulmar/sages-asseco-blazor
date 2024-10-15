using Domain.Abstractions;
using Infrastructure;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IAccountRepository, FakeAccountRepository>();

await builder.Build().RunAsync();
