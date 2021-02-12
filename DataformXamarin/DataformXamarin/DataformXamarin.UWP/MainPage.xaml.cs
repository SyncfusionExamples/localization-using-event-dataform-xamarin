using Syncfusion.XForms.UWP.DataForm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DataformXamarin.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fr");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("fr");

            CultureInfo.CurrentCulture = new CultureInfo("fr");
            CultureInfo.CurrentUICulture = new CultureInfo("fr");

            SfDataFormRenderer.Init();
            LoadApplication(new DataformXamarin.App());
        }
    }
}
