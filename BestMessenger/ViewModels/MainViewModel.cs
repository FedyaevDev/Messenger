using BestMessenger.Infrastructure.Commands;
using BestMessenger.Infrastructure.Services;
using Models.Models;
using BestMessenger.Network;
using BestMessenger.Views;
using Models.Models;
using Models.ModelShells;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BestMessenger.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Commands
        public ActionCommand CloseAppCommand => new ActionCommand(x => Application.Current.Shutdown());
        public ActionCommand WindowMinimizeCommand => new ActionCommand(x => Application.Current.MainWindow.WindowState = WindowState.Minimized);
        public ActionCommand WindowMaximizeCommand => new ActionCommand(x => MaximizeCommand());
        public ActionCommand SendMessageCommand => new ActionCommand(x => MessageBox.Show("test"));
        #endregion

        #region Property

        private event Func<User,Task> getLastMessageEvent;

        private string newText;

        public string NewText
        {
            get { return newText; }
            set 
            { 
                newText = value; 
                OnPropertyChanged();
            }
        }

        private ObservableCollection<User> members;

        public ObservableCollection<User> Members
        {
            get { return members; }
            set 
            { 
                members = value;
                OnPropertyChanged();
            }
        }

        private User selectedMember;

        public  User SelectedMember
        {
            get { return selectedMember; }
            set 
            {
                
                selectedMember = value;

                getLastMessageEvent(selectedMember);

                OnPropertyChanged();
            }
        }

        private ObservableCollection<Message> messagesWithSelectedUser;

        public ObservableCollection<Message> MessagesWithSelectedUser
        {
            get { return messagesWithSelectedUser; }
            set 
            { 
                messagesWithSelectedUser = value;
                OnPropertyChanged();
            }
        }


        private readonly UserService _userService;

        private Server _server;
        #endregion

        public ObservableCollection<UserShellForServer> AllChatMembers { get; set; }

        public  MainViewModel()
        {
            _userService = new UserService();
            
            LoadInfo().GetAwaiter();
            UserShellForServer userShellForServer = new UserShellForServer
            {
                FirstName = "F1 test",
                LastName = "L2 test"
            };
            AllChatMembers = new ObservableCollection<UserShellForServer>();


            _server = new Server();
            _server.ConnectedEvent += NewUserConnected;
            _server.ConnectedToServer(userShellForServer);

            getLastMessageEvent += GetLastMessage;
            //new RegistrationWindow().ShowDialog();
        }

        private void NewUserConnected(UserShellForServer user)
        {
            App.Current.Dispatcher.Invoke(() => AllChatMembers.Add(user));
        }

        private async Task GetLastMessage(User user)
        {                                                                   //mainUser.Id
            var res =  (await _userService.GetMessageWithUser(await _userService.GetUser(5), user));
            
            MessagesWithSelectedUser = res;
         

            

            user.LastMessage = res.LastOrDefault()?.Text;
        }

        private async Task LoadInfo()
        {
            var user1 = new User
            {
                FirstName = "user1"
            };
            var user2 = new User
            {
                FirstName = "user2"
            };
            var user3 = new User
            {
                FirstName = "user3"
            };
            var user4 = new User
            {
                FirstName = "user4"
            };
            var user5 = new User
            {
                FirstName = "user5"
            };
            //await _userService.AddNewUser(user1);
            //await _userService.AddNewUser(user2);
            //await _userService.AddNewUser(user3);
            //await _userService.AddNewUser(user4);
            //await _userService.AddNewUser(user5);

            //await _userService.AddNewMember(await _userService.GetUser(8), await _userService.GetUser(9));
            ObservableCollection<User> tempMembers = await _userService.GetAllMembersAtGroup(await _userService.GetUser(8), 4);
           
            foreach (var item in tempMembers)
            {
               //item.Id != mainUser.Id
                await GetLastMessage(item);

            }
            Members = tempMembers;
            #region
            //_userService.AddPhoto();

            //await _userService.SendMessage(new Message
            //{
            //    Sender = await _userService.GetUser(5),
            //    Receiver = await _userService.GetUser(6),
            //    DateOfSend = DateTime.Now,
            //    Text = "Test 6"
            //});
            //string res = "";
            //foreach (var item in await _userService.GetMessageWithUser(await _userService.GetUser(5), await _userService.GetUser(6)))
            //{
            //    res += item.Text + Environment.NewLine;
            //}
            //MessageBox.Show(res);
            //await _userService.AddNewUser(user3);
            ////await _userService.AddNewUser(user2);
            //await _userService.AddNewMember(await _userService.GetUser(5), user3);

            //string res = "";
            //foreach (var item in await _userService.GetAllMembersAtGroup(null, 3))
            //{
            //    res += item.FirstName + Environment.NewLine;
            //}
            //MessageBox.Show(res);
            #endregion
        }

        private void MaximizeCommand()
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
