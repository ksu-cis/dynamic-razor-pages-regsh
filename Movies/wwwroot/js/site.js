// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
var movieEntries = document.getElementsByClassName("movie-entry");

var form = document.getElementById("search-and-filter-form");

form.addEventListener('submit', function (event) {
    event.preventDefault();

    var term = document.getElementById("search").value;

    var mpaa = [];
    var mpaaCheckBoxes = document.getElementsByClassName("mpaa");
    for (var j = 0; j < mpaaCheckBoxes.length; j++) {
        if (mpaaCheckBoxes[j].checked) {
            mpaa.push(mpaaCheckBoxes[j].value);
        }
    }

    var minIMDB = document.getElementById("minIMDB").value;
    
    for (var i = 0; i < movieEntries.length; i++) {
        var entry = movieEntries[i];

        // Step 1: Unhide all entries
        entry.style.display = "block";

        // Step 2: Filter by search term
        if (term) {
            if (!entry.dataset.title.toLowerCase().includes(term.toLowerCase())) {
                entry.style.display = "none";
            }
        }

        // Step 3: Filter by mpaa rating 
        if (mpaa.length > 0) {
            if (!mpaa.includes(entry.dataset.mpaa)) {
                entry.style.display = "none";
            }
        }

        // Step 4: Filter by imdb minimum rating 
        if (minIMDB) {
            console.log(entry.dataset.imdb);
            if (!entry.dataset.imdb || parseFloat(minIMDB) > parseFloat(entry.dataset.imdb)) {
                entry.style.display = "none";
            }
        }
    }
});