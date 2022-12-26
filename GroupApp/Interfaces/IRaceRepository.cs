using GroupApp.Models;

namespace GroupApp.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetAllRaces();
        Task<IEnumerable<Race>> GetRaceByCity(string city);
        Task<Race> GetAllRacesById(int id);
        bool Add(Race race);
        bool Update(Race race);
        bool Delete(Race race);
        bool Save();
    }
}
