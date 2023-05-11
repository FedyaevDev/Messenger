using BestMessenger.Infrastructure.Services;
using BestMessenger.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestMessenger.Infrastructure.Commands
{
    public class SendMessageCommand : ICommand
    {
        private readonly MainViewModel _viewModel;
        private readonly SignalRService _signalRService;

        public SendMessageCommand(MainViewModel viewModel, SignalRService signalRService)
        {
            _viewModel = viewModel;
            _signalRService = signalRService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                await _signalRService.SendMessage(new Models.Models.Message
                {
                    DateOfSend = DateTime.Now,
                    Text = _viewModel.NewText,
                    Sender = _viewModel.User
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
