﻿using Bro2Bro.Mobile.ViewModels;

using System;

using Xamarin.Forms;

namespace Bro2Bro.Mobile.Views {
    public partial class MainPage : ContentPage {
        public MainModel viewModel => (MainModel)BindingContext;

        public MainPage() {
            InitializeComponent();

            BindingContext = new MainModel();
        }

        public async void OnRefresh(object sender, EventArgs e) {
            if (!lvMessages.IsRefreshing) {
                return;
            }

            var result = await viewModel.LoadData();

            SetForm();

            lvMessages.IsRefreshing = false;
        }

        private void SetForm()
        {
            lvMessages.ItemsSource = null;

            lvMessages.ItemsSource = viewModel.Messages;
        }
        protected override async void OnBindingContextChanged() {
            var result = await viewModel.LoadData();

            if (!string.IsNullOrEmpty(result)) {
                await DisplayAlert("Bro2Bro", result, "OK");

                return;
            }

            SetForm();
        }
    }
}