using GymManagement.Domain.Admins;

namespace GymManagement.Application.Common.Interfaces;

public interface IAdminsRepository
{
    Task<Admin?> GetByIdAsync(Guid adminId);
    Task UpdateAsync(Admin admin);
    Task AddAsync(Admin admin);
    Task<List<Admin>> GetAllAsync();
}