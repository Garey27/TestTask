using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoccerCatalog.Interfaces;
using SoccerCatalog.Models;

namespace SoccerCatalog.Repositories
{
    public class FootballerRepository : BaseRepository<Footballer>, IFootballerRepository
    {
        public FootballerRepository(AppDbContext context) : base(context)
        {
        }
    }
}