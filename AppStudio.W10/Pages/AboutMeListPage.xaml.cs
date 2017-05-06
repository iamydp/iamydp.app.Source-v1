//---------------------------------------------------------------------------
//
// <copyright file="AboutMeListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>1/7/2017 9:28:12 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Html;
using AppStudio.Sections;
using AppStudio.ViewModels;
using AppStudio.Uwp;

namespace AppStudio.Pages
{
    public sealed partial class AboutMeListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }

        private DataTransferManager _dataTransferManager;

		#region	HtmlContent
		public string HtmlContent
        {
            get { return (string)GetValue(HtmlContentProperty); }
            set { SetValue(HtmlContentProperty, value); }
        }

		public static readonly DependencyProperty HtmlContentProperty = DependencyProperty.Register("HtmlContent", typeof(string), typeof(AboutMeListPage), new PropertyMetadata(string.Empty));
		#endregion
        public AboutMeListPage()
        {
			ViewModel = ViewModelFactory.NewList(new AboutMeSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("ad8199d1-f060-4824-9cb3-f155056f0ca4");
			ShellPage.Current.ShellControl.SetCommandBar(commandBar);
			if (e.NavigationMode == NavigationMode.New)
            {			
				await this.ViewModel.LoadDataAsync();
                this.ScrollToTop();
			}			
			
			if (ViewModel.Items != null && ViewModel.Items.Count > 0)
			{
                HtmlContent = ViewModel.Items[0].Content;
            }			
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;		
            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            ViewModel.ShareContent(args.Request);
        }
    }
}
