using Reservoom.Exceptions;
using Reservoom.Models;
using Reservoom.Stores;
using Reservoom.ViewModels;
using Reservoom.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Reservoom.DbContexts;
using Reservoom.Services.ReservationProviders;
using Reservoom.Services.ReservationCreators;
using Reservoom.Services.ReservationConflictValidators;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Reservoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host =  Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {                    
                    string ConnectionString = hostContext.Configuration.GetConnectionString("Default")!;

                    services.AddSingleton(new ReservoomDbContextFactory(ConnectionString));
                    services.AddSingleton<IReservationProvider, DatabaseReservationProvider>();
                    services.AddSingleton<IReservationCreator, DatabaseReservationCreator>();
                    services.AddSingleton<IReservationConflictValidator, DatabaseReservationConflictValidator>();

                    services.AddTransient<ReservationBook>();
                    services.AddSingleton<Hotel>((s) => new Hotel("Cielo Hotel", s.GetRequiredService<ReservationBook>()));

                    services.AddSingleton<NavigationService<ReservationListingViewModel>>();

                    services.AddTransient((s) => CreateReservationListingViewModel(s));
                    services.AddSingleton<Func<ReservationListingViewModel>>((s) => () => s.GetRequiredService<ReservationListingViewModel>());
                    services.AddSingleton<NavigationService<ReservationListingViewModel>>();

                    services.AddTransient<MakeReservationViewModel>();
                    services.AddSingleton<Func<MakeReservationViewModel>>((s) => () => s.GetRequiredService<MakeReservationViewModel>());
                    services.AddSingleton<NavigationService<MakeReservationViewModel>>();

                    services.AddSingleton<HotelStore>();
                    services.AddSingleton<NavigationStore>();

                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        private ReservationListingViewModel CreateReservationListingViewModel(IServiceProvider services)
        {
            return ReservationListingViewModel.LoadViewModel(
                services.GetRequiredService<HotelStore>(),
                services.GetRequiredService<NavigationService<MakeReservationViewModel>>()
                );

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            ReservoomDbContextFactory reservoomDbContextFactory = _host.Services.GetRequiredService<ReservoomDbContextFactory>();

            using (ReservoomDbContext dbContext = reservoomDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            NavigationService<ReservationListingViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<ReservationListingViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
