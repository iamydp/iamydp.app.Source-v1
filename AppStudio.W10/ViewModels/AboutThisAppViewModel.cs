using System;
using System.Windows.Input;

using Windows.ApplicationModel;
using Windows.UI.Xaml.Media.Imaging;

using AppStudio.Uwp;
using AppStudio.Uwp.Commands;

namespace AppStudio.ViewModels
{
    public class AboutThisAppViewModel : PageViewModelBase
    {
		public AboutThisAppViewModel()
        {
            this.AppName = "Mr.loading";
            this.Title = "NavigationPaneAbout".StringResource();
            this.Publisher = "iamydp";
            this.AppVersion = string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            this.AboutText = "一个为Mr.loading设计的基于rss的uwp配套应用";
            this.AppLogo = new BitmapImage(new Uri("ms-appx:///Assets/ApplicationLogo.png"));
            this.Privacy = "https://www.iamydp.cn/app.html";
            this.WasLibs = "https://github.com/wasteam/waslibs";
        }

		public string AppName { get; set; }
        public string Publisher { get; set; }
        public string AppVersion { get; set; }
        public string AboutText { get; set; }
        public string Privacy { get; set; }
        public string WasLibs { get; set; }
        public BitmapImage AppLogo { get; set; }

		private bool _isMoreInfoVisible;
        public bool IsMoreInfoVisible
        {
            get { return _isMoreInfoVisible; }
            set { SetProperty(ref _isMoreInfoVisible, value); }
        }

        private ICommand _viewMoreInfoCommand;
        public ICommand ViewMoreInfoCommand
        {
            get
            {
                if (_viewMoreInfoCommand == null)
                {
                    _viewMoreInfoCommand = new RelayCommand(() => { IsMoreInfoVisible = !IsMoreInfoVisible; });
                }
                return _viewMoreInfoCommand;
            }
        }
    }
}

