using GroupApp.Models;

namespace GroupApp.Interfaces
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAllClubs();
        Task<IEnumerable<Club>> GetClubByCity(string city);
        Task<Club> GetClubById(int id);
        Task<Club> GetClubByIdNoTracking(int id);
        bool Add(Club club);
        bool Update(Club club);
        bool Delete(Club club);
        bool Save();
    }
}
