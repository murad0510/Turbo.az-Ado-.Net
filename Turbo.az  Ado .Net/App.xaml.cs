using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Turbo.az__Ado.Net.DataAccess.Abstractions;
using Turbo.az__Ado.Net.DataAccess.Concrete;
using Turbo.az__Ado.Net.Entities;

namespace Turbo.az__Ado.Net
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;
        public App()
        {
            DB = new EFIUnitOfWork();

            var status1 = new Status
            {
                IsNew = true,
            };

            var status2 = new Status
            { 
                IsNew = false,
            };

            //var city1 = new City
            //{
            //     Name=""
            //};

        }
    }
}
