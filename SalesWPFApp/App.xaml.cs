using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BusinessObject;
using DataAccess.Repository;
using DataAccess;
using SalesWPFApp.ViewModels;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private ServiceProvider serviceProvider;
        //public App()
        //{
        //    ServiceCollection services = new ServiceCollection();
        //    ConfigureServices(services);
        //    serviceProvider = services.BuildServiceProvider();
        //}
        //private void ConfigureServices(ServiceCollection services)
        //{
        //    services.AddDbContext<Asm1PRNContext>();

        //    services.AddSingleton<WindowLogin>();
        //    services.AddSingleton<MainWindow>();
        //    services.AddSingleton<WindowMembers>();
        //    services.AddSingleton<WindowProducts>();
        //    services.AddSingleton<WindowOrders>();

        //    services.AddSingleton(typeof(IMemberRepository), typeof(MemberRepository));
        //    services.AddSingleton(typeof(IProductRepository), typeof(ProductRepository));
        //    services.AddSingleton(typeof(IOrderRepository), typeof(OrderRepository));
        //    services.AddSingleton(typeof(IOrderDetailRepository), typeof(OrderDetailRepository));

        //}
        //public void OnStartUp(object sender, StartupEventArgs e)
        //{
        //    var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
        //    mainWindow.Show();
        //}


    }
}
