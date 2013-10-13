/// <reference path="person.js" />
/// <reference path="../lib/underscore.js" />
/// <reference path="book.js" />
function task06() {

    var arrayOfBooks = [
        new Book("Some bestseler", new Person("Asen", "Minkov", 18, 5)),
        new Book("Some story about old times", new Person("Tabita", "Georgieva", 48)),
        new Book("Some love story", new Person("Asen", "Minkov", 18)),
        new Book("Some story about old times", new Person("Tabita", "Georgieva", 48)),
        new Book("Some story about new times", new Person("Tabita", "Georgieva", 48)),
        new Book("Some story about present times", new Person("Tabita", "Georgieva", 48)),
    ];

    var grouped = _.groupBy(arrayOfBooks, function (book) {

        return book.author;
    });

    var bestAuthor = { author: undefined, booksCount: 0 };

    _.each(grouped, function (authorCollection) {
        console.log(authorCollection[0].author.toString());
        if (authorCollection.length > bestAuthor.booksCount) {
            bestAuthor.author = authorCollection[0].author;
            bestAuthor.booksCount = authorCollection.length;
        } 
        
        _.chain(authorCollection)
                .each(function (animalObj) {
                    console.log(animalObj.toString());
                });
    });

    console.log("Best author - >", bestAuthor.author.toString(), " books -> ", bestAuthor.booksCount);
}