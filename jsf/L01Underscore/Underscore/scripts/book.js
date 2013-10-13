var Book = Class.create({
    init: function (title, author) {
        this.title = title;
        this.author = author;
    },
    
    toString: function () {
        return this.title + " author: " + this.author.toString();
    }
});