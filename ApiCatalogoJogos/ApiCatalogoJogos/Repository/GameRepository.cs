using ApiCatalogoJogos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repository
{
    public class GameRepository : IGameRepository
    {
        private static Dictionary<Guid, Game> games = new Dictionary<Guid, Game>()
        {
            { Guid.Parse(""), new Game{Id = Guid.Parse(""), Name = "", Producer = "", Price = 200} },
            { Guid.Parse(""), new Game{Id = Guid.Parse(""), Name = "", Producer = "", Price = 200} },
            { Guid.Parse(""), new Game{Id = Guid.Parse(""), Name = "", Producer = "", Price = 200} },
            { Guid.Parse(""), new Game{Id = Guid.Parse(""), Name = "", Producer = "", Price = 200} },
            { Guid.Parse(""), new Game{Id = Guid.Parse(""), Name = "", Producer = "", Price = 200} },
            { Guid.Parse(""), new Game{Id = Guid.Parse(""), Name = "", Producer = "", Price = 200} }
        };

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<Game>> Get(int page, int quantity)
        {
              return Task.FromResult(games.Values.Skip((page - 1) * quantity).Take(quantity).ToList());
        }

        public Task<List<Game>> Get(string name, string producer)
        {
            return Task.FromResult(games.Values.Where(game => game.Name.Equals(name) && game.Producer.Equals(producer)).ToList());
        }

        public Task<Game> GetById(Guid id)
        {
            if (!games.ContainsKey(id))
                return null;
            return Task.FromResult(games[id]);
        }

        public Task Insert(Game game)
        {
            games.Add(game.Id, game);
            return Task.CompletedTask;
        }

        public Task Remove(Guid id)
        {
            games.Remove(id);
            return Task.CompletedTask;
        }

        public Task Update(IGameRepository game)
        {
            throw new NotImplementedException();
        }

        public Task Update(Game game)
        {
            games[game.Id] = game;
            return Task.CompletedTask;
        }

        /*
        public void Dispose()
        {
            //
        }
        */
    }
}
