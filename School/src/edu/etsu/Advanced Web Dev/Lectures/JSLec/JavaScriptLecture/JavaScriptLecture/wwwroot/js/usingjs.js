'use strict';
// Object initializer
console.log("Object Initializer");
let o1 = {};
let o2 = { name: "Jeff", age: 23, grades: ["A", "B", "C"] };
console.log(o1);
console.log(o2);
console.log(o2.name);
console.log(o2["name"]);
console.log(o2.grades[1]);

// Functions
console.log("Functions");
sayHello("Jeff");
// Function definition
function sayHello(name) {
    console.log("Hello, " + name + "!");
}
// Function expression
let sayHello2 = function (name) {
    console.log("Hello, " + name + "!!");
};
sayHello2("Jeff");
// Arrow function
let sayHello3 = (name) => {
    console.log("Hello, " + name + "!!!");
};
sayHello3("Jeff");

// This is a self-invoking function that creates a localized scope.
(function _justTesting() {
    // Code goes here
    console.log("Just testing");
})();

(function () {
    // Code goes here
    console.log("Just testing");
})();

// var and let
console.log("var and let -------------------");
varTest();
letTest();
function varTest() {
    var x = 1;
    if (x === 1) {
        var x = 2; // same variable
        console.log(x); // 2
    }
    console.log(x); // 2
}
function letTest() {
    let x = 1;
    if (x === 1) {
        let x = 2; // different variable
        console.log(x); // 2
    }
    console.log(x); // 1
}