function googleSearch(searchterm) {

    let modifiedSearchTerm = searchterm.replace(" ", "+")
    window.open("https://www.google.com/search?q=" + modifiedSearchTerm, "blank");

}