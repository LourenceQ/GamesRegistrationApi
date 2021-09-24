using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Entity
{
    public class Game
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Produces { get; set; }

        public Guid Price { get; set; }
    }
}
