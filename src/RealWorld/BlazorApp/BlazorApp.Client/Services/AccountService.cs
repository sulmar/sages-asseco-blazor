using Domain.Models;
using System.Net.Http.Json;

namespace BlazorApp.Client.Services;

public class AccountService
{
    private readonly HttpClient _client;

    public AccountService(HttpClient client)
    {
        _client = client;
    }

    public Task<IEnumerable<Account>> GetAllAsync()
    {
        return _client.GetFromJsonAsync<IEnumerable<Account>>("api/accounts")!;
    }
}
