using System.Windows;
using System.Data.Entity;
using static PRAKTIKA2.PassengersWindow;
using System.Linq;
using System;

namespace PRAKTIKA2
{
    public partial class TicketsWindow : Window
    {
        private AVIACASSA2Entities1 dbContext;

        public TicketsWindow()
        {
            InitializeComponent();
            dbContext = new AVIACASSA2Entities1();
            LoadTickets();
        }

        private void LoadTickets()
        {
            dbContext.Tickets.Load();
            ticketsDataGrid.ItemsSource = dbContext.Tickets.ToList();
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
            PassengersWindow passWindow = new PassengersWindow();
            passWindow.Show();
            this.Close();
        }

        private void ShowNextWindow()
        {
            
            this.Close();
        }

        private void Izm(object sender, RoutedEventArgs e)
        {
            if (ticketsDataGrid.SelectedItem != null)
            {
                var selectedTicket = (Tickets)ticketsDataGrid.SelectedItem;
                selectedTicket.SeatNumber = SeatNumberIzm.Text;
                selectedTicket.Class = ClassIzm.Text;
                if (decimal.TryParse(PriceIzm.Text, out decimal price))
                {
                    selectedTicket.Price = price;
                }
                else
                {
                    MessageBox.Show("Введите целое число для деняк");
                    return; 
                }

                dbContext.SaveChanges();
                LoadTickets();
            }
        }

        private void Dob(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(Price.Text, out decimal price))
            {
                var newTicket = new Tickets
                {
                    SeatNumber = SeatNumber.Text,
                    Class = Class.Text,
                    Price = price
                };

                dbContext.Tickets.Add(newTicket);
                dbContext.SaveChanges();
                LoadTickets();
            }
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            if (ticketsDataGrid.SelectedItem != null)
            {
                var selectedTicket = (Tickets)ticketsDataGrid.SelectedItem;
                dbContext.Tickets.Remove(selectedTicket);
                dbContext.SaveChanges();
                LoadTickets(); 
            }
        }

        private void ticketsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ticketsDataGrid.SelectedItem != null)
            {
                var selectedTicket = (Tickets)ticketsDataGrid.SelectedItem;
                SeatNumberIzm.Text = selectedTicket.SeatNumber;
                ClassIzm.Text = selectedTicket.Class;
                PriceIzm.Text = selectedTicket.Price.ToString();
            }
        }
    }
}