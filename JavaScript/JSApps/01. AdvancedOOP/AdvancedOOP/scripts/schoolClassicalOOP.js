var Class = (function () {
    function createClass(properties) {
        var f = function () {
            if (this._super) {
                this._super = new this._super(arguments);
            }
            this.init.apply(this, arguments);
        }
        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        if (!f.prototype.init) {
            f.prototype.init = function () { }
        }
        return f;
    }

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;
        var prototype = new parent();
        this.prototype = Object.create(prototype);
        this.prototype._super = parent;
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    }

    return {
        create: createClass,
    };
}());

var School = Class.create({
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    }
});

var Person = Class.create({
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },

    introduce: function () {
        return "Name: " + this.firstName + " " + this.lastName +
            ", Age: " + this.age;
    }
})

var Student = Class.create({
    init: function (firstName, lastName, age, grade) {
        this._super.init(firstName, lastName, age);
        this.grade = grade;
    },


    introduce: function () {
        return this._super.introduce() + ", Grade: " + this.grade;
    }
})

var Teacher = Class.create({
    init: function (firstName, lastName, age, specialty) {
        this._super.init(firstName, lastName, age);
        this.specialty = specialty;
    },

    introduce: function () {
        return this._super.introduce() + ", Specialty: " + this.specialty;
    }
})

var SchoolClass = Class.create({
    init: function (name, studentsCapacity, studentsCount, formTeacher) {
        this.name = name;
        this.studentsCapacity = studentsCapacity;
        this.studentsCount = studentsCount;
        this.formTeacher = formTeacher;
    }
})

Student.inherit(Person);
Teacher.inherit(Person);

//Test School:
var schoolPMG = new School("PMG", "Sliven", 5);
//this is created just to check if inheritence of schoolPMG is OK
var schoolPGEE = new School("PGEE", "Sofia", 10);
console.log("school is instance of School: " + (schoolPMG instanceof School));
console.log("School name: " + schoolPMG.name);
console.log("School town: " + schoolPMG.town);
console.log("School classes: " + schoolPMG.classes);

//Test Student:
var petyr = new Student("Petyr", "Petrov", 12, 5);
//this is created just to check if inheritance of petyr is OK
var spiro = new Student("Spiro", "Spirov", 15, 6); 
console.log(petyr.introduce());

var ivanov = new Teacher("Ivan", "ivanov", 47, "Informatics");
//this is created just to check if inheritance of ivanov is OK
var gospodinov = new Teacher("Goran", "Gospodinov", 55, "Mathematics");
console.log(ivanov.introduce());

//Test Class:
var class5A = new SchoolClass("5A", 30, 25, new Teacher("Petyr", "Vasilev", 40, "Physics"));
console.log("Class5A name: " + class5A.name);
console.log("Class5A students capacity: " + class5A.studentsCapacity);
console.log("Class5A students count: " + class5A.studentsCount);
console.log("Class5A form-teacher: " + class5A.formTeacher.introduce());

