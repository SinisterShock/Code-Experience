using System.Runtime.CompilerServices;
using System.Text.Json;
using TBLW05ConsumeWebAPI.Models.Entities;

namespace TBLW05ConsumeWebAPI.Services;

public class WebAPIBookRepository : IBookrepository
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WebAPIBookRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ICollection<Book>> ReadAllAsync()
    {
        var client = _httpClientFactory.CreateClient("BookAPI");
        List<Book> books = null;

        var response = await client.GetAsync("all");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            books = JsonSerializer.Deserialize<List<Book>>(json, serializeOptions);
        }

        books ??= new List<Book>(); // if books is null, create an empty list

        return books;
    }
}
