using Chat.ChatHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Chat.ChatHelper.ViewModel
{
    public interface IMessageViewModel
    {
        string UserName { get; }
        ImageSource UserImage { get; }
        MessageType Type { get; }
        bool IsMyMessage { get; }
        string MessageText { get; }
        string SentTime { get;  }
        string FileUrl { get; }
    }
}
