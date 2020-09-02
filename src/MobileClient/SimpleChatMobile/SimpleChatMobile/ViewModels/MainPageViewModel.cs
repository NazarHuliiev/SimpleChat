using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;
using Microsoft.AspNetCore.SignalR.Client;
using SimpleChatMobile.Models;
using Xamarin.Forms;

namespace SimpleChatMobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            _connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:5001/hubs/chat", options =>
                    {
                        options.HttpMessageHandlerFactory = factory => new HttpClientHandler
                        {
                            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
                        };
                    })
                    .Build();

            _connection.On<Message>("ReceiveMessage", (message) =>
            {
                Messages.Add(message);
            });
        }

        public async void OnViewAppearing()
        {
            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async void OnViewDisappearing()
        {
            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public string UserName { get; set; }

        public ObservableCollection<Message> Messages => _messages;

        public string TextMessage
        {
            get => _textMessage;
            set
            {
                _textMessage = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SendCommand =>
            _sendCommand ??= new Command(OnSend);

        private async void OnSend()
        {
            try
            {
                await _connection.InvokeAsync("SendMessage",
                    new Message
                    {
                        Sender = UserName,
                        Text = TextMessage
                    }); ;

                TextMessage = String.Empty;
            }
            catch (Exception ex)
            {

            }
        }

        private string _textMessage;

        private ICommand _sendCommand;

        private ObservableCollection<Message> _messages = new ObservableCollection<Message>();

        private HubConnection _connection;
    }
}
