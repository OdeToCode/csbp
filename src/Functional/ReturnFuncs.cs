using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional
{
    public class ReturnFuncs
    {
        
        public void Demo()
        {
            var movies = new List<Movie>
                             {
                                 new Movie {Title = "Star Wars"},
                                 new Movie {Title = "Starship Troopers"},
                                 new Movie {Title = "E.T."}
                             };

            var starMovies = movies.Where(TitleStartsWith("Star"));
        }

        private Func<Movie, bool> TitleStartsWith(string value)
        {
            return movie => movie.Title.StartsWith(value);
        }

    }
}