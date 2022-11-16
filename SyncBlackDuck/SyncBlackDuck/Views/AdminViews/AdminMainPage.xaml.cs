<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

=======
﻿using SyncBlackDuck.ViewModel;
using SyncBlackDuck.ViewModel.cAdminViewModel;
using Syncfusion.SfDataGrid.XForms;
using System;
>>>>>>> 83800c75de0d329474ac5128b2ca3a67fa77f28e
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncBlackDuck.Views.AdminViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminMainPage : ContentPage
    {
        public AdminMainPage()
        {
            InitializeComponent();
            BindingContext = new AdminViewModel(Navigation);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BindingContext = null;
            GC.Collect();
        }
    }
}