using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using TaskApp.Models;
using Xamarin.Forms;

namespace TaskApp.ViewModels
{
    public class AddNewItemPageViewModel : ViewModelBase
    {
        INavigationService navigationService;
        private TodoItem item;

        public AddNewItemPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService) : base(navigationService, pageDialogService, deviceService)
        {
            Item = new TodoItem();
            this.navigationService = navigationService;
            this.SaveCommand = new DelegateCommand(async () => { await this.SaveCommandAction(); });
            this.CancelCommand = new DelegateCommand(async () => { await this.CancelCommandAction(); });
        }

        public TodoItem Item
        {
            get { return this.item; }
            set { this.SetProperty(ref this.item, value); }
        }


        public ICommand SaveCommand { get; set; }

        private async Task SaveCommandAction()
        {

            App.Database.SaveTaskAsync(Item);
            await navigationService.GoBackAsync();
        }

        public ICommand CancelCommand { get; set; }

        private async Task CancelCommandAction()
        {
            await navigationService.GoBackAsync();
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public int SelectedID { get; set; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters == null || !parameters.ContainsKey("Id"))
            {
                return;
            }
            else
            {
            }

            if (parameters.ContainsKey("Id"))
            {
                int id = (int)parameters["Id"];
                SelectedID = id;

                LoadSelectedData();
            }
        }

        private async Task LoadSelectedData()
        {
            var response = await App.Database.GetItemAsync(SelectedID);
            Item = new TodoItem()
            {
                Task = response.Task,
                Description = response.Description,
                Done = response.Done,
                Id =response.Id
            };
        }
    }
}