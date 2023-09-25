using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class ReservationListingViewModel : ViewModelBase
    {
        private readonly HotelStore _hotelStore;
        
        private readonly ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> Reservations => _reservations;

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; 
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage)); 
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(_errorMessage);


        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
        }


        public ICommand LoadReservationCommand { get; }
        public ICommand MakeReservationCommand { get; }

        public ReservationListingViewModel(HotelStore hotelStore, NavigationService<MakeReservationViewModel> makeReservationNavigationService)
        {
            _hotelStore = hotelStore;
            _reservations = new ObservableCollection<ReservationViewModel>();

            LoadReservationCommand = new LoadReservationCommand(this, hotelStore);
            MakeReservationCommand = new NavigateCommand<MakeReservationViewModel>(makeReservationNavigationService);

            _hotelStore.ReservationMade += OnReservationMade;
        }

        public override void Dispose()
        {
            _hotelStore.ReservationMade -= OnReservationMade;
            base.Dispose();
        }

        private void OnReservationMade(Reservation reservation)
        {
            ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
            _reservations.Add(reservationViewModel);
        }

        public static ReservationListingViewModel LoadViewModel(HotelStore hotelStore, NavigationService<MakeReservationViewModel> makeReservationService)
        {
            ReservationListingViewModel viewModel = new ReservationListingViewModel(hotelStore, makeReservationService);

            viewModel.LoadReservationCommand.Execute(null);

            return viewModel;
        }

        public void UpdateReservations(IEnumerable<Reservation> reservations)
        {
            _reservations.Clear();

            foreach (var reservation in reservations)
            {
                ReservationViewModel reservationViewModel = new ReservationViewModel(reservation);
                _reservations.Add(reservationViewModel);
            }
        }
    }
}
