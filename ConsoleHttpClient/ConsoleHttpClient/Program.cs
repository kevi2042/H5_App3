using Refit;
using System;


namespace ConsoleHttpClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // Her oprettes et objekt af IBackendService-typen
            var repos = RestService.For<IBackendService>("https://localhost:5001");

            Item newItem = new Item { Text = "New Item", Description = "My New Item" };
            await repos.AddItem(newItem);

            var items = await repos.GetItems();
            foreach (Item item in items)
            {
                Console.WriteLine($"Text: {item.Text} - Description: {item.Description}");
            }

            Item singleItem = await repos.GetItemById(items[5].Id);
            Console.WriteLine($"\nSingle Item: {singleItem.Text} - Description: {singleItem.Description}");
             
            singleItem.Description = "This is a new Description";
            await repos.UpdateItem("5", singleItem);
            singleItem = await repos.GetItemById(items[5].Id);
            Console.WriteLine($"\nUpdated Single Item: {singleItem.Text} - Description: {singleItem.Description}");

            Console.ReadLine();
        }
    }
}
