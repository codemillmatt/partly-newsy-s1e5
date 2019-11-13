using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PartlyNewsy.Core.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutShellPage : Shell
    {
        public FlyoutShellPage()
        {
            InitializeComponent();
        }
    }
}