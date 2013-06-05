if (!Object.create) {
    Object.create = function (obj) {
        function f() { };
        f.prototype = obj;
        return new f();
    }
}

if (!Object.prototype.extend) {
    Object.prototype.extend = function (properties) {
        function f() { };
        f.prototype = Object.create(this);
        for (var prop in properties) {
            f.prototype[prop] = properties[prop];
        }
        f.prototype._super = this;
        return new f();
    }
}

var School = {
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    }
};

var Person = {
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },

    introduce: function () {
        return "Name: " + this.firstName + " " + this.lastName +
            ", Age: " + this.age;
    }
};

var Student = Person.extend({
    init: function (firstName, lastName, age, grade) {
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this.grade = grade;
    },


    introduce: function () {
        return this._super.introduce() + ", Grade: " + this.grade;
    }
});

var Teacher = Person.extend({
    init: function (firstName, lastName, age, specialty) {
        this._super = Object.create(this._super);
        this._super.init(firstName, lastName, age);
        this.specialty = specialty;
    },

    introduce: function () {
        return this._super.introduce() + ", Specialty: " + this.specialty;
    }
});

var SchoolClass = {
    init: function (name, studentsCapacity, studentsCount, formTeacher) {
        this.name = name;
        this.studentsCapacity = studentsCapacity;
        this.studentsCount = studentsCount;
        this.formTeacher = formTeacher;
    }
};

//Test School:
var schoolPMG = Object.create(School);
schoolPMG.init("PMG", "Sliven", 5);
//this is created just to check if inheritence of schoolPMG is OK
var schoolPGEE = Object.create(School);
schoolPGEE.init("PGEE", "Sofia", 10);
console.log("School name: " + schoolPMG.name);
console.log("School town: " + schoolPMG.town);
console.log("School classes: " + schoolPMG.classes);

//Test Student:
var petyr = Object.create(Student);
petyr.init("Petyr", "Petrov", 12, 5);
//this is created just to check if inheritance of petyr is OK
var spiro = Object.create(Student);
spiro.init("Spiro", "Spirov", 15, 6);
console.log(petyr.introduce());

var ivanov = Object.create(Teacher);
ivanov.init("Ivan", "Ivanov", 47, "Informatics");
//this is created just to check if inheritance of ivanov is OK
var gospodinov = Object.create(Teacher);
gospodinov.init("Goran", "Gospodinov", 55, "Mathematics");
console.log(ivanov.introduce());

//Test Class:
var class5A = Object.create(SchoolClass);
class5A.init("5A", 30, 25, ivanov);
console.log("Class5A name: " + class5A.name);
console.log("Class5A students capacity: " + class5A.studentsCapacity);
console.log("Class5A students count: " + class5A.studentsCount);
console.log("Class5A form-teacher: " + class5A.formTeacher.introduce());