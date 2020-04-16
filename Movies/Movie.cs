using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies
{
    /// <summary>
    /// A class representing a movie
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Gets or sets the title of the movie
        /// </summary>
        public string Title { get; set; }
                
        /// <summary>
        /// Gets or sets the MPAA rating of the movie
        /// </summary>
        public string MPAARating { get; set; }

        /// <summary>
        /// Gets or sets the genre of the movie
        /// </summary>
        public string MajorGenre { get; set; }

        /// <summary>
        /// Gets or sets the IMDB rating of the movie
        /// </summary>
        public float? IMDBRating { get; set; }

        /// <summary>
        /// Gets or sets the rotten tomatoes rating of the movie
        /// </summary>
        public float? RottenTomatoesRating { get; set; }
    }
}
