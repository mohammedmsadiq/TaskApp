using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using TaskApp.Models;
using TaskApp.Resources;

namespace TaskApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        INavigationService navigationService;
        List<TodoItem> items;
        public List<TodoItem> Items
        {
            set { SetProperty(ref items, value); }
            get { return items; }
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            this.AddTaskCommand = new DelegateCommand(async () => { await this.AddTaskCommandAction(); });


            this.navigationService = navigationService;
            Title = "My Task";
            this.LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var r = await App.Database.GetAllTaskAsync();
            Items = new List<TodoItem>(r);
        }

        public ICommand AddTaskCommand { get; set; }

        private async Task AddTaskCommandAction()
        {
            await navigationService.NavigateAsync("AddNewItemPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand<TodoItem> QuestionSelectedCommand => new DelegateCommand<TodoItem>(async (I) => await OnQuestionItemSelectedCommand(I));

        private async Task OnQuestionItemSelectedCommand(TodoItem item)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("Id", item.Id);
            await this.navigationService.NavigateAsync("AddNewItemPage", navigationParams, false, false);
        }



        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            this.LoadDataAsync();

            switch (parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    // TODO: Handle any tasks that should occur only when navigated back to
                    break;
                case NavigationMode.New:
                    // TODO: Handle any tasks that should occur only when navigated to for the first time
                    break;
            }

            // TODO: Handle any tasks that should be done every time OnNavigatedTo is triggered
        }
    }
}