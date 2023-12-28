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

    public async Task<Book?> CreateAsync(Book book)
    {
        var client = _httpClientFactory.CreateClient("BookAPI");
        var bookData = new FormUrlEncodedContent(new Dictionary<string, string>()
        {
            ["Id"] = $"{book.Id}",
            ["Title"] = $"{book.Title}",
            ["Edition"] = $"{book.Edition}",
            ["PublicationYear"] = $"{book.PublicationYear}"
        });
        var result = await client.PostAsync("create", bookData);
        if (result.IsSuccessStatusCode)
        {
            return book;
        }
        return null;
    }

    public async Task DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient("BookAPI");
        var result = await client.DeleteAsync($"delete/{id}");
        if (!result.IsSuccessStatusCode) 
        { 
            //TODO put something here
        }
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

    public async Task<Book?> ReadAsync(int id)
    {
        var client = _httpClientFactory.CreateClient("BookAPI");
        Book? book = null;
        var response = await client.GetAsync($"one/{id}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            book = JsonSerializer.Deserialize<Book>(json, serializeOptions);
        }
        return book;
    }

    public async Task UpdateAsync(int oldID, Book book)
    {
        var client = _httpClientFactory.CreateClient("BookAPI");
        var bookData = new FormUrlEncodedContent(new Dictionary<string, string>()
        {
            ["Id"] = $"{book.Id}",
            ["Title"] = $"{book.Title}",
            ["Edition"] = $"{book.Edition}",
            ["PublicationYear"] = $"{book.PublicationYear}"
        });
        var result = await client.PutAsync("update", bookData);
        if (!result.IsSuccessStatusCode)
        {
            // TODO put something here
        }
    }
}
