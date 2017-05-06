//---------------------------------------------------------------------------
//
// <copyright file="MyBlogListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>1/7/2017 9:28:12 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.Rss;
using AppStudio.Sections;
using AppStudio.ViewModels;
using AppStudio.Uwp;

namespace AppStudio.Pages
{
    public sealed partial class MyBlogListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public MyBlogListPage()
        {
			ViewModel = ViewModelFactory.NewList(new MyBlogSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("7e7f41e1-cf32-465a-9c7f-b09b45ce083b");
			ShellPage.Current.ShellControl.SetCommandBar(commandBar);
			if (e.NavigationMode == NavigationMode.New)
            {			
				await this.ViewModel.LoadDataAsync();
                this.ScrollToTop();
			}			
            base.OnNavigatedTo(e);
        }

    }
}
