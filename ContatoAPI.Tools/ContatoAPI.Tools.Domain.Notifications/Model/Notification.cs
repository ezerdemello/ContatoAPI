using System;
using System.Collections.Generic;
using System.Text;

namespace ContatoAPI.Tools.Domain.Notifications.Model
{
    public class Notification
    {
        public Notification()
        {
            id = Guid.NewGuid();
            date = DateTime.Now;
        }

        public Notification(string key, string value)
        {
            id = Guid.NewGuid();
            this.key = key;
            this.value = value;
            date = DateTime.Now;
        }

        public Guid id { get; set; }

        public string key { get; set; }

        public string value { get; set; }

        public DateTime date { get; set; }
    }

}
