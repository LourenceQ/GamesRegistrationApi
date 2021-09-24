using ApiCatalogoJogos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repository
{
    public interface IGameRepository : IDisposable
    {
        Task<List<Game>> Get(int page, int quantity);
        Task<Game> GetById(Guid id);
        Task<List<Game>> Get(string nome, string producer);
        Task Insert(Game game);
        Task Update(IGameRepository game);
        Task Remove(Guid id);

    }
}
