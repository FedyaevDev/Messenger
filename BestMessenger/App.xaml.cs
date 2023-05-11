using BestMessenger.ViewModels;
using BestMessenger.Views;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BestMessenger
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            HubConnection hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:5001/messenger").Build();
            MainWindow window = new MainWindow
            {
                DataContext = MainViewModel.CreateViewModel(new Infrastructure.Services.SignalRService(hubConnection))
            };
            window.Show();
        }
    }
}
