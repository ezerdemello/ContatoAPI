using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ContatoAPI.Tools.Domain.Notifications.Model;

namespace ContatoAPI.Tools.Domain.Notifications.Interfaces
{
    public static class CommandExtensions
    {
        public static List<Model.Notification> GetNotificationsList(this ICommand command)
        {
            return command.NotificationsList;
        }            

        public static bool ContainsNotifications(this ICommand command)
        {
            if (command.NotificationsList == null)
                return false;

            return command.NotificationsList.Any();
        }

        public static void AddNotification(this ICommand command, Notification notification)
        {
            if (notification == null)
                return;

            if (command.NotificationsList == null)
            {
                command.NotificationsList = new List<Model.Notification>();
                command.NotificationsList.Add(notification);
            }
            else
            {
                if (!command.NotificationsList.Any(x => x.key == notification.key))
                    command.NotificationsList.Add(notification);
            }

        }

        public static bool ModelValidate(this ICommand command, object model)
        {
            bool isValid = true;
            List<ValidationResult> results = new List<ValidationResult>();
            System.ComponentModel.DataAnnotations.ValidationContext context = new System.ComponentModel.DataAnnotations.ValidationContext(model);

            isValid = Validator.TryValidateObject(model, context, results, true); 
                        
            if (!isValid)
                results.ForEach(x => AddNotification(command, new Model.Notification { key = x.MemberNames.FirstOrDefault(), value = x.ErrorMessage }));

            return isValid;
        }

    }

}