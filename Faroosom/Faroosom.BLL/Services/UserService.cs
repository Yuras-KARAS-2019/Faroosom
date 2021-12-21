using Faroosom.BLL.DTO.User;
using Faroosom.BLL.Interfaces;
using Faroosom.DAL;
using Faroosom.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faroosom.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly FaroosomContext _context;

        UserService(FaroosomContext context)
        {
            _context = context ?? throw new NullReferenceException(nameof(context));
        }

        public async Task<ICollection<UserDto>> GetAllUsersAsync()
        {
            return await _context.Users.Select(x => new UserDto
            {
                Id = x.Id,
                Age = x.Age,
                Name = x.Name,
                LastName = x.LastName,
                Login = x.Login
            }).ToListAsync();
        }

        public async Task<UserDto> GetUserByIdAsync(int userid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userid) ??
                       throw new KeyNotFoundException($"User Id = {userid} does not exist with");
            var result = new UserDto
            {
                Id = user.Id,
                Age = user.Age,
                Name = user.Name,
                LastName = user.LastName,
                Login = user.Login
            };
            return result;
        }

        public async Task SubscribeAsync(int subscriberId, int publisherId)
        {
            var subscription = new Subscription()
            {
                SubscriberId = subscriberId,
                PublisherId = publisherId,
            };
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();

        }

        public async Task UnsubscribeAsync(int subscriberId, int publisherId)
        {
            var subscription = await _context.Subscriptions.FirstOrDefaultAsync(x =>
                                   x.PublisherId == x.PublisherId &&
                                   x.SubscriberId == subscriberId) ?? throw new KeyNotFoundException("Мимо чел");
            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<UserDto>> GetAllUserSubscribersByIdAsync(int publisherId)
        {
            return await _context.Subscriptions
                .Where(x => x.PublisherId == publisherId)
                .Select(x => new UserDto
                {
                    Id = x.Subscriber.Id,
                    Age = x.Subscriber.Age,
                    Name = x.Subscriber.Name,
                    LastName = x.Subscriber.LastName,
                    Login = x.Subscriber.Login
                }).ToListAsync();
        }

        public async Task<ICollection<UserDto>> GetAllSubscriptionByIdAsync(int userId)
        {
            return await _context.Subscriptions
                .Where(x => x.SubscriberId == userId)
                .Select(x => new UserDto
                {
                    Id = x.Subscriber.Id,
                    Age = x.Subscriber.Age,
                    Name = x.Subscriber.Name,
                    LastName = x.Subscriber.LastName,
                    Login = x.Subscriber.Login
                }).ToListAsync();
        }
    }
}
