using System;
namespace SimpleChatMobile.Models
{
    public class Message
    {
        public Message()
        {
        }

        public string Destination { get; set; }

        public string Sender { get; set; }

        public string Text { get; set; }
    }
}
