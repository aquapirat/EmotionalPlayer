using Player.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Player.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
