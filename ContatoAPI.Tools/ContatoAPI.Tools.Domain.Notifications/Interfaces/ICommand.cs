using System;
using System.Collections.Generic;
using System.Text;
using ContatoAPI.Tools.Domain.Notifications.Model;

namespace ContatoAPI.Tools.Domain.Notifications.Interfaces
{
    public interface ICommand
    {
        List<Model.Notification> NotificationsList { get; set; }

        bool HasNotifications();

        List<Notification> GetNotifications();
    }

}