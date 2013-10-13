Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
};

Function.prototype.extend = function (parent) {
    for (var i = 1; i < arguments.length; i += 1) {
        var name = arguments[i];
        this.prototype[name] = parent.prototype[name];
    }
    return this;
};

//Function.prototype.unextend = function (parent) {
//    for (var i = 1; i < arguments.length; i += 1) {
//        var name = arguments[i];
//        delete this.prototype[name];
//    }
//    return this;
//};