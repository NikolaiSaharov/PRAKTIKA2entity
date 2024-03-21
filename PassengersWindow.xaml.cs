using System.Windows;
using System.Data.Entity;
using System.Linq;
using PRAKTIKA2;
using System.Collections.ObjectModel;
using System;
using System.Windows.Controls;

namespace PRAKTIKA2
{
    public partial class PassengersWindow : Window
    {
        private AVIACASSA2Entities1 dbContext;
        
        public PassengersWindow()
        {
            InitializeComponent();
            dbContext = new AVIACASSA2Entities1();
            LoadPassengers();
        }
        
        private void LoadPassengers()
        {
            dbContext.Passengers.Load();
            passengersDataGrid.ItemsSource = dbContext.Passengers.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ShowPreviousWindow();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            ShowNextWindow();
        }

        private void ShowPreviousWindow()
        {
            
            this.Close();
        }

        private void ShowNextWindow()
        {
            TicketsWindow ticketWindow = new TicketsWindow();
            ticketWindow.Show();
            this.Close();
        }

        private void Dob(object sender, RoutedEventArgs e)
        {
            var passenger = new Passengers
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,
                Phone = Phone.Text
            };

            dbContext.Passengers.Add(passenger);
            dbContext.SaveChanges();
            LoadPassengers();
        }


        private void Izm(object sender, RoutedEventArgs e)
        {
            if (passengersDataGrid.SelectedItem != null)
            {
                var selectedPassenger = (Passengers)passengersDataGrid.SelectedItem;
                var passengerToUpdate = dbContext.Passengers.Find(selectedPassenger);
                if (passengerToUpdate != null)
                {
                    passengerToUpdate.FirstName = FirstNameIzm.Text;
                    passengerToUpdate.LastName = LastNameIzm.Text;
                    passengerToUpdate.Email = EmailIzm.Text;
                    passengerToUpdate.Phone = PhoneIzm.Text;

                    dbContext.SaveChanges();
                    LoadPassengers();
                }
            }
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            if (passengersDataGrid.SelectedItem != null)
            {
                var selectedPassenger = (Passengers)passengersDataGrid.SelectedItem;
                dbContext.Passengers.Remove(selectedPassenger);
                dbContext.SaveChanges();
                LoadPassengers();
            }
        }
        private void passengersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (passengersDataGrid.SelectedItem != null)
            {
                var selectedPassenger = (Passengers)passengersDataGrid.SelectedItem;
                FirstNameIzm.Text = selectedPassenger.FirstName;
                LastNameIzm.Text = selectedPassenger.LastName;
                EmailIzm.Text = selectedPassenger.Email;
                PhoneIzm.Text = selectedPassenger.Phone;
            }
        }
    }
}