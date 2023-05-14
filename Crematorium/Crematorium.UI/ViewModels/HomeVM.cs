using CommunityToolkit.Mvvm.ComponentModel;
using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.UI.ViewModels
{
    public partial class HomeVM : ObservableValidator
    {
        private IHelpersService<RitualUrn> _urnService; 

        public ObservableCollection<RitualUrn> RitualUrns { get; set; }

        public HomeVM(IHelpersService<RitualUrn> urnService)
        {
            _urnService = urnService;
            RitualUrns = new ObservableCollection<RitualUrn>(_urnService.GetAllAsync().Result);
        }

        public void UpdateCollections()
        {
            RitualUrns.Clear();
            foreach (var urn in _urnService.GetAllAsync().Result)
            {
                RitualUrns.Add(urn);
            }
        }
    }
}
