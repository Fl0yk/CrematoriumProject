using Crematorium.Application.Abstractions;
using Crematorium.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crematorium.UI.Fabrics
{
    public static class ServicesFabric
    {
        public static IServiceProvider Services { get; set; }

        public static User? CurrentUser { get; set; }

        public static object GetPage(Type typeOfPage)
        {
            if (Services is null)
                throw new ArgumentNullException(nameof(Services));

            object? page = Services.GetService(typeOfPage);
            if (page is null)
                throw new Exception("Not found Page");

            return page;
        }
    }
}
