using System;
using AppStudio.Uwp;

namespace AppStudio.ViewModels
{
    public class PrivacyViewModel : ObservableBase
    {
        public Uri Url
        {
            get
            {
                return new Uri(UrlText, UriKind.RelativeOrAbsolute);
            }
        }
        public string UrlText
        {
            get
            {
                return "https://appstudio.windows.com/home/appprivacyterms";
            }
        }
    }
}

