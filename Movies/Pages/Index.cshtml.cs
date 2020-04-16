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

        public MovieDatabase MovieDatabase = new MovieDatabase();

        public List<Movie> Movies;

        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public List<string> mpaa { get; set; } = new List<string>();

        [BindProperty]
        public float? minIMDB { get; set; }

        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public void OnPost()
        {
            if (search != null && mpaa.Count > 0)
            {
                Movies = MovieDatabase.Search(search);
                Movies = MovieDatabase.FilterByMPAA(Movies, mpaa);
            }
            else if (search != null)
            {
                Movies = MovieDatabase.Search(search);
            }
            else if (mpaa.Count > 0)
            {
                Movies = MovieDatabase.FilterByMPAA(MovieDatabase.All, mpaa);
            }
            else
            {
                Movies = MovieDatabase.All;
            }

            if(minIMDB is float min)
            {
                Movies = MovieDatabase.FilterByMinIMDB(Movies, min);
            }
        }
    }
}
