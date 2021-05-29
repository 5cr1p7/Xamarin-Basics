using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin_Basics
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<string> users = new ObservableCollection<string> { };
        Dictionary<string, string> usersPhones = new Dictionary<string, string>();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (userName.Text.Length != 0)
                {
                    if (!usersPhones.ContainsKey(userName.Text))
                    {
                        userInfo.Text = "Hello, " + userName.Text + "\nPhone: " + userPhone.Text;
                        users.Add(userName.Text);
                        usersList.ItemsSource = users;
                        usersPhones.Add(userName.Text, userPhone.Text); // last change
                    }
                    else
                    {
                        DisplayAlert("Ошибка", "Такое имя уже есть!", "ОК");
                    }
                }
                else
                {
                    DisplayAlert("Ошибка", "Пустое поле имени", "ОК");
                }
                
            }
            catch (Exception exc) {
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            userPhone.Text = users.ElementAt(0);
        }

        private void usersList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert(usersList.SelectedItem.ToString(), "Номер: " + usersPhones[usersList.SelectedItem.ToString()], "ОК");
        }
    }
}
