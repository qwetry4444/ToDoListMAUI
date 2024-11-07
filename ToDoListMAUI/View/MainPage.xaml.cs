using ToDoListMAUI.ViewModel;

namespace ToDoListMAUI
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            BindingContext = viewModel;
        }
    }
}
