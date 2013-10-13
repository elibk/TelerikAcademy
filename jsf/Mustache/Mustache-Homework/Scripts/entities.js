var Student = Class.create({
    init: function (fname, lname, marks) {
        this.fname = fname;
        this.lname = lname
        this.marks = marks;
    },
    fullname: function () {
        return this.fname + " " + this.lname;
    }
});

var Mark = Class.create({
    init: function (subject, score) {
        this.subject = subject;
        this.score = score;
    }
});