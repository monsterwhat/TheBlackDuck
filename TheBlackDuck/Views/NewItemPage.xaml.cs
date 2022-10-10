using System;
using System.Collections.Generic;
using System.ComponentModel;
using TheBlackDuck.Models;
using TheBlackDuck.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheBlackDuck.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}