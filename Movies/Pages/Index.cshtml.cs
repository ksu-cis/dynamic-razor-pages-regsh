using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The current search terms 
        /// </summary>
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// The filtered MPAA Ratings
        /// </summary>
        public string[] MPAARatings { get; set; }

        /// <summary>
        /// The filtered genres
        /// </summary>
        public string[] Genres { get; set; }

        /// <summary>
        /// The minimum IMDB Rating
        /// </summary>
        public double? IMDBMin { get; set; }

        /// <summary>
        /// The maximum IMDB Rating
        /// </summary>
        public double? IMDBMax { get; set; }

        /// <summary>
        /// The minimum RottenTomatoes rating set by the user
        /// </summary>
        [BindProperty (SupportsGet =true)]
        public double? TomatoesMin { get; set; }

        /// <summary>
        /// The maximum RottenTomatoes rating set by the user
        /// </summary>
        [BindProperty (SupportsGet =true)]
        public double? TomatoesMax { get; set; }

        /// <summary>
        /// The movies to display on the index page
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }

        /// <summary>
        /// Does the response initialization for incoming GET requests
        /// </summary>
        public void OnGet(double? IMDBMin, double? IMDBMax)
        {
            
            SearchTerms = Request.Query["SearchTerms"];
            MPAARatings = Request.Query["MPAARatings"];
            Genres = Request.Query["Genres"];
            
            // Nullable conversion workaround
            this.IMDBMin = IMDBMin;
            this.IMDBMax = IMDBMax;
            /*
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);
            Movies = MovieDatabase.FilterByTomatoes(Movies, TomatoesMin, TomatoesMax);
            */

            Movies = MovieDatabase.All;
            if(SearchTerms != null)
            {
                Movies = Movies.Where(movie =>
                    movie.Title != null &&
                    movie.Title.Contains(SearchTerms, System.StringComparison.InvariantCultureIgnoreCase));
            }

            if(MPAARatings != null && MPAARatings.Length > 0)
            {
                Movies = Movies.Where(movie =>
                    movie.MPAARating != null &&
                    MPAARatings.Contains(movie.MPAARating)
                    );
            }

            if(Genres != null && Genres.Length > 0)
            {
                Movies = Movies.Where(movie =>
                    movie.MajorGenre != null &&
                    Genres.Contains(movie.MajorGenre)
                    );
            }

            if(!(IMDBMin == null && IMDBMax == null))
            {
                if(IMDBMin == null)
                {
                    Movies = Movies.Where(movie =>
                        movie.IMDBRating <= IMDBMax);
                }
                else if(IMDBMax == null)
                {
                    Movies = Movies.Where(movie =>
                        movie.IMDBRating >= IMDBMin);
                }
                else
                {
                    Movies = Movies.Where(movie =>
                        movie.IMDBRating >= IMDBMin &&
                        movie.IMDBRating <= IMDBMax);
                }
            }

            if (!(TomatoesMin == null && TomatoesMax == null))
            {
                if (TomatoesMin == null)
                {
                    Movies = Movies.Where(movie =>
                        movie.RottenTomatoesRating <= TomatoesMax);
                }
                else if (TomatoesMax == null)
                {
                    Movies = Movies.Where(movie =>
                        movie.RottenTomatoesRating >= TomatoesMin);
                }
                else
                {
                    Movies = Movies.Where(movie =>
                        movie.RottenTomatoesRating >= TomatoesMin &&
                        movie.RottenTomatoesRating <= TomatoesMax);
                }
            }
        }
    }
}
