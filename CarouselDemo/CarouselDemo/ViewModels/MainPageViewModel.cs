using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CarouselDemo.ViewModels
{
    public class Email : BindableBase
    {
        private int id;
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        private string subject;
        public string Subject 
        { 
            get => subject; 
            set => SetProperty(ref subject, value); 
        }
        private string html;
        public string Html
        {
            get => html;
            set => SetProperty(ref html, value);
        }
    }

    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand<Email> LoadMoreCommand { get; set; }
        public DelegateCommand AddCommand { get; set; }

        private ObservableCollection<Email> emails;
        public ObservableCollection<Email> Emails
        {
            get => emails;
            set => SetProperty(ref emails, value);
        }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Main Page";
            AddCommand = new DelegateCommand(Add);
            LoadMoreCommand = new DelegateCommand<Email>(LoadMore);

            Emails = new ObservableCollection<Email>
            {
                emailList[0]
            };
        }

        private void LoadMore(Email email)
        {
            var index = emailList.IndexOf(email);
            index++;
            if (index < emailList.Count)
                Emails.Add(emailList[index]);
        }

        private void Add()
        {
            LoadMore(emails[emails.Count-1]);
        }

        private List<Email> emailList = new List<Email>()
        {
            new Email() { Id = 1, Subject = "Email1", Html = "<!DOCTYPE html><html><head><title> Email 1 Title </title></head><body>The content of the Email 1.</body></html>" },
            new Email() { Id = 2, Subject = "Email2", Html = "<!DOCTYPE html><html><head><title> Email 2 Title </title></head><body>The content of the Email 2.</body></html>" },
            new Email() { Id = 3, Subject = "Email3", Html = "<!DOCTYPE html><html><head><title> Email 3 Title </title></head><body>The content of the Email 3.</body></html>" },
            new Email() { Id = 4, Subject = "Email4", Html = "<!DOCTYPE html><html><head><title> Email 4 Title </title></head><body>The content of the Email 4.</body></html>" },
            new Email() { Id = 5, Subject = "Email5", Html = "<!DOCTYPE html><html><head><title> Email 5 Title </title></head><body>The content of the Email 5.</body></html>" },
        };
    }
}
