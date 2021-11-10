using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHttpClient
{
    public interface IBackendService
    {
        [Get("/api/items")]
        Task<List<Item>> GetItems();

        [Get("/api/items/{id}")]
        Task<Item> GetItemById(string id);

        [Post("/api/items")]
        Task AddItem([Body] Item item);

        [Put("api/items/{id}")]
        Task UpdateItem(string id, [Body] Item item);

        [Delete("api/items/{id}")]
        Task Delete(string id);
    }
}
