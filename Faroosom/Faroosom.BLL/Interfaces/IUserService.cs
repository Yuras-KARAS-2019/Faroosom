using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faroosom.BLL.DTO.User;

namespace Faroosom.BLL.Interfaces
{
    public interface IUserService
    {
        Task<ICollection<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<UserDto> GetUserByCredentialsAsync(CreateUserDto dto);

        Task SubscribeAsync(int subscriberId, int publisherId);
        Task UnsubscribeAsync(int subscriberId, int publisherId);

        Task<ICollection<UserDto>> GetAllUserSubscribersByIdAsync(int publisherId);
        Task<ICollection<UserDto>> GetAllSubscriptionByIdAsync(int userId);

        Task<UserDto> CreateUserAsync(CreateUserDto dto);
    }
}
