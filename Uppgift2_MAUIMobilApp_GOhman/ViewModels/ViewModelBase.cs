using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift2_MAUIMobilApp_GOhman.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty]
        public string title = "";
    }
}
