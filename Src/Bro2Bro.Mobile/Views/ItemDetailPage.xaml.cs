﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Bro2Bro.Mobile.Models;
using Bro2Bro.Mobile.ViewModels;

namespace Bro2Bro.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                BroName = "Item 1",
                Content = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}