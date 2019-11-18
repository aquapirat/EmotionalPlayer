using Player.Application.Common.Interfaces;
using Player.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Player.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
