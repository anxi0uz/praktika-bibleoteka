using ApiBookStore.Abstractions;
using ApiBookStore.DataAccess;
using ApiBookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ApiBookStore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User?> Authorize(string login, string password)
        {
            return await _context.Users
                .Where(p => p.Login == login.Trim() && p.Password == password.Trim())
                .FirstOrDefaultAsync();
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<int> CreateUser(string login, string password, string fio, string birthdate, string adress, string phoneNumber, int RoleId)
        {
            var user = new User()
            {
                Login = login,
                Password = password,
                Fio = fio,
                BirthDate = birthdate,
                Adress = adress,
                Phonenumber = phoneNumber,
                Role = RoleId
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
        public async Task<int> UpdateUser(int id, string login, string password, string fio, string birthdate, string adress, string phoneNumber, int RoleId)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Login, login)
                .SetProperty(p => p.Password, password)
                .SetProperty(p => p.Fio, fio)
                .SetProperty(p => p.BirthDate, birthdate)
                .SetProperty(p => p.Adress, adress)
                .SetProperty(p => p.Phonenumber, phoneNumber)
                .SetProperty(p => p.Role, RoleId));
            return id;
        }
        public async Task<int> DeleteUser(int id)
        {
            await _context.Users.Where(p => p.Id == id).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
