using MandatoryAssignmnt1;

namespace FootballApi.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        private static List<FootballPlayer> Data = new List<FootballPlayer>()
        {
            new FootballPlayer(){Id = _nextId++, Age = 15, Name = "Johannes", ShirtNumber = 13},
            new FootballPlayer(){Id = _nextId++, Age = 16, Name = "Jakob", ShirtNumber = 39},
            new FootballPlayer(){Id = _nextId++, Age = 15, Name = "Morten", ShirtNumber = 1},
            new FootballPlayer(){Id = _nextId++, Age = 18, Name = "Peter", ShirtNumber = 2},
        };

        public FootballPlayersManager()
        {

        }

        //The Manager must have 5 methods (GetAll, GetByID, Add, Update and Delete)

        public List<FootballPlayer> GetAll()
        {
            return Data;
        }

        public FootballPlayer GetById(int id)
        {
            try
            {
                return Data.Find(beer => beer.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public FootballPlayer Add(FootballPlayer playerToAdd)
        {
            playerToAdd.Id = _nextId++;
            Data.Add(playerToAdd);
            return playerToAdd;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer playerToDelete = Data.Find(player => player.Id == id);
            if (playerToDelete == null) return null;
            Data.Remove(playerToDelete);
            return playerToDelete;
        }

        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer playerToUpdate = Data.Find(player => player.Id == id);
            if (playerToUpdate == null) return null;
            playerToUpdate.Name = updates.Name;
            playerToUpdate.ShirtNumber = updates.ShirtNumber;
            playerToUpdate.Age = updates.Age;
            return playerToUpdate;
        }

    }
}
