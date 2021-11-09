using MVVMTemplate.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMTemplate.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private decimal price;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public decimal Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                Price = item.Price;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }



        private Command deleteItemCommand;

        public ICommand DeleteItemCommand
        {
            get
            {
                if (deleteItemCommand == null)
                {
                    deleteItemCommand = new Command(DeleteItem);
                }

                return deleteItemCommand;
            }
        }

        private void DeleteItem()
        {
            // Messaging send, fungere som mqtt subscribe og sending
            // Beskeden sendes til Adressen "DeleteItem", sådan at alle der subscriber til "DeleteItem" får besked
            // Modtageren af denne besked ligger i AppShell cs filen
            MessagingCenter.Send(this, "DeleteItem");


            // Subsribe fungere ved at typen er den fil beskeden bliver sendt fra, i dette tilfælde er det fra appshell til her
            // der bliver modtaget en bool, og addressen der subscribes til er "ConfirmDelete"
            MessagingCenter.Subscribe<AppShell, bool>(new AppShell(),
                "ConfirmDelete", async (sender, args) =>
                {
                    if (args)
                    {
                        await DataStore.DeleteItemAsync(ItemId);
                        await Shell.Current.GoToAsync("..");
                    }
                });
        }
    }
}
