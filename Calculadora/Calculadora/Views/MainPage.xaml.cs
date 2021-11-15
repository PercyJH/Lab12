using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Calculadora.ViewModels;

namespace Calculadora.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }
    }
}