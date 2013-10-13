if (!Object.create) {
    Object.create = function (obj) {
        function f() { }
        f.prototype = obj;
        return new f();
    };
}
if (!Object.prototype.extend) {
    Object.prototype.extend = function (properties) {
        function f() { }
        f.prototype = Object.create(this);
        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        f.prototype._super = this;
        //f.prototype._super = Object.create(this); // -> make differance between classes that extending, but not between their objects
        //f.prototype._super.prototype = Object.create(this);

        return new f();
    };
}