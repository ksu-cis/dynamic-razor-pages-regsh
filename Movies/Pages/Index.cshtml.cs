using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Terms being searched for in Movie title list
        /// </summary>
        public string SearchTerms { get; set; }

        /// <summary>
        /// The ratings by which the database should be filtered
        /// </summary>
        public string[] MPAARatings { get; set; }

        /// <summary>
        /// The genres by which the database should be filtered
        /// </summary>
        public string[] Genres { get; set; }

        /// <summary>
        /// The movies to display on the index page
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }
        /// <summary>
        /// Invoked every time a GET requestion is made for the page
        /// </summary>
        public void OnGet()
        {
            SearchTerms = Request.Query["SearchTerms"];
            MPAARatings = Request.Query["MPAARatings"];
            Genres = Request.Query["Genres"];
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
        }

    }
}
