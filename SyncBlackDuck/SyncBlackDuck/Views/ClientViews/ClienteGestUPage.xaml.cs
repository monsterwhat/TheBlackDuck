using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncBlackDuck.Views.ClientViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClienteGestUPage : ContentPage
    {
        public ClienteGestUPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BindingContext = null;
            GC.Collect();
        }
    }
}