function task01() {

    var people = [
        new Student("Doncho", "Minkov", [new Mark("Math", 4), new Mark("JavaScript", 6)]),
        new Student("Nikolay", "Kostov", [new Mark("MVC", 6), new Mark("JavaScript", 5)]),
        new Student("Ivaylo", "Kendov", [new Mark("OOP", 4), new Mark("C#", 6), new Mark("C#2", 6), new Mark("C#3", 6), new Mark("C#4", 6)]),
        new Student("Svetlin", "Nakov", [new Mark("Unit Testing", 5), new Mark("WPF", 6)]),
        new Student("Asya", "Georgieva", [new Mark("Automation Testing", 6), new Mark("Manual Testing", 4)]),
        new Student("Georgi", "Georgiev")
    ];

    var personTemplate = Mustache.compile(document.getElementById("person-template").innerHTML);
    var tableView = controls.getTableView(people, 5, 5);

    var tableViewHtml = tableView.render(personTemplate);

    document.getElementById("content").innerHTML = tableViewHtml;
}