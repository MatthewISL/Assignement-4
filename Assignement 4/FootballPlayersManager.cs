using FootballPlayerProject;
using System.Reflection.Metadata.Ecma335;

namespace Assignement_4
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        public List<FootballPlayer> _playersData = new List<FootballPlayer>
        {
            new FootballPlayer{Id=_nextId++, Name="Bob", Age=32, ShirtNumber=47},
            new FootballPlayer{Id=_nextId++, Name="Tim", Age=21, ShirtNumber=14},
            new FootballPlayer{Id=_nextId++, Name="Greg", Age=25, ShirtNumber=82},
            new FootballPlayer{Id=_nextId++, Name="Jhon", Age=30, ShirtNumber=53}
        };

        public List<FootballPlayer> GetAll()
        {
            return _playersData;
        }
        public FootballPlayer GetById(int id)
        {
            return _playersData.Find(f => f.Id == id);
        }
        public FootballPlayer Add(FootballPlayer player)
        {
            player.Id= _nextId++;
            _playersData.Add(player);
            return player;
        }
        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer player = GetById(id);
            if(player == null)
            {
                return null;
            }
            player.Name = updates.Name;
            player.Age = updates.Age;
            player.ShirtNumber = updates.ShirtNumber;
            return player;
        }
        public FootballPlayer Delete(int id)
        {
            FootballPlayer player = GetById(id);
            if(player == null)
            {
                return null;
            }
            _playersData.Remove(player);
            return player;
        }
    }
}
