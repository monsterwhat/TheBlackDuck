using System.ComponentModel;
using TheBlackDuck.ViewModels;
using Xamarin.Forms;

namespace TheBlackDuck.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}