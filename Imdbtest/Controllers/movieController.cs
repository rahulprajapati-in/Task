using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Imdbtest;
using System.Web.Routing;
using Newtonsoft.Json;

namespace Imdbtest.Controllers
{
    
    public class movieController : ApiController
    {
        public IEnumerable<movie_data> Get()
        {
            using (ImdbEntities1 movie = new ImdbEntities1())
            {        
                return movie.movie_data.ToList();
            }
        }

        
        public movie_data Get(int id)
        {
            using (ImdbEntities1 movie = new ImdbEntities1())
            {
                return movie.movie_data.FirstOrDefault(m => m.id == id) ;
            }
        }

        public IEnumerable<movie_data> Get(string sortBy, string sortDirection)
        {
            using (ImdbEntities1 movie = new ImdbEntities1())
            {
                if (sortDirection == "asc")
                    return movie.movie_data.OrderBy(x => x.movie_name).ToList();
                else
                    return movie.movie_data.OrderByDescending(x => x.movie_name).ToList();

            }
        }

        public IEnumerable<movie_data> Get(string searchmovie)
        {
            using (ImdbEntities1 movie = new ImdbEntities1())
            {
                    return movie.movie_data.Where(x => x.movie_name == searchmovie).ToList();

            }
        }

 

    }
}
