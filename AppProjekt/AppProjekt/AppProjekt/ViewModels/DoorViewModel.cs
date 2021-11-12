using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppProjekt.ViewModels
{
    public class DoorViewModel : BaseViewModel
    {
        private string entryContent;

        public string EntryContent
        {
            get => entryContent;
            set => SetProperty(ref entryContent, value);
        }

        public DoorViewModel()
        {

        }

        private Command sendToDoor;
        public ICommand SendToDoor => sendToDoor ??= new Command(PerformSendToDoor);

        private async void PerformSendToDoor()
        {
            await _service.PostOpenDoorAsync(Convert.ToInt32(entryContent));
            await _service.PostOpenDoorAsync(0);
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
