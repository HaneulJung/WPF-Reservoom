using Reservoom.Commands;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
		private string _username;
        private int _floorNumber;
        private int _roomNumber;
        private DateTime _startDate = new DateTime(2023, 9, 22);
        private DateTime _endDate = new DateTime(2023, 10, 20);

        public string Username
		{
			get 
			{ 
				return _username; 
			}
			set
			{
				if (_username != value)
				{
					_username = value;
					OnPropertyChanged(nameof(Username));
				}
			}
		}

        public int FloorNumber
        {
            get
            {
                return _floorNumber;
            }
            set
            {
                if (_floorNumber != value)
                {
                    _floorNumber = value;
                    OnPropertyChanged(nameof(FloorNumber));
                }
            }
        }

        public int RoomNumber
		{
			get 
			{ 
				return _roomNumber; 
			}
			set 
			{ 
				if (_roomNumber != value)
				{
                    _roomNumber = value;
					OnPropertyChanged(nameof(RoomNumber));
                }				
			}
		}


		public DateTime StartDate
		{
			get 
			{ 
				return _startDate; 
			}
			set 
			{
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
			}
		}

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeReservationViewModel(Hotel hotel, NavigationService reservationViewNavigationService)
        {
            SubmitCommand = new MakeReservationCommand(this, hotel, reservationViewNavigationService);
            CancelCommand = new NavigateCommand(reservationViewNavigationService);
        }

    }
}
