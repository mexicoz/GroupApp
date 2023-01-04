using GroupApp.Models;

namespace GroupApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Club>> GetAllUserClubs();
        Task<List<Race>> GetAllUserRaces();
        Task<AppUser> GetUserById(string id);
    }
}
