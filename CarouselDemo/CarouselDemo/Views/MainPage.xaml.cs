
using CarouselDemo.ViewModels;
using Xamarin.Forms;

namespace CarouselDemo.Views
{
    public partial class MainPage
    {
        MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            viewModel = (MainPageViewModel)BindingContext;
        }

        private void carousel_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            // comment this code for 'Add' method
            var email = (Email)e.CurrentItem;
            viewModel.LoadMoreCommand.Execute(email);
        }
    }
}
