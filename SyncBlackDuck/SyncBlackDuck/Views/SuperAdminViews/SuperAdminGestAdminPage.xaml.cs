﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SyncBlackDuck.Views.SuperAdminViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuperAdminGestAdmin : ContentPage
    {
        public SuperAdminGestAdmin()
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