using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Ipa.DependancyServices;

namespace Ipa
{
    public partial class LoadingPage : ContentPage
    {
     
        public LoadingPage()

        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}
