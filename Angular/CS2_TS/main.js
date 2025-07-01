// Enum for Courses
var Course;
(function (Course) {
    Course["Angular"] = "Angular";
    Course["NodeJS"] = "Node.js";
    Course["FullStack"] = "FullStack";
})(Course || (Course = {}));
// Enum for Course Category
var CourseCategory;
(function (CourseCategory) {
    CourseCategory["FrontEnd"] = "Front-End";
    CourseCategory["BackEnd"] = "Back-End";
    CourseCategory["FullStack"] = "Full-Stack";
})(CourseCategory || (CourseCategory = {}));
// Enum for Enrollment Status
var EnrollmentStatus;
(function (EnrollmentStatus) {
    EnrollmentStatus["Eligible"] = "Eligible";
    EnrollmentStatus["NotEligible"] = "Not Eligible";
})(EnrollmentStatus || (EnrollmentStatus = {}));
// Class for handling enrollment
var Enrollment = /** @class */ (function () {
    function Enrollment(student) {
        this.student = student;
    }
    Enrollment.prototype.determineCategory = function () {
        if (this.student.courseName === Course.Angular) {
            this.category = CourseCategory.FrontEnd;
        }
        else if (this.student.courseName === Course.NodeJS) {
            this.category = CourseCategory.BackEnd;
        }
        else {
            this.category = CourseCategory.FullStack;
        }
    };
    Enrollment.prototype.checkEligibility = function () {
        if (this.student.age >= 18 &&
            (this.student.courseName !== Course.Angular || this.student.knowsHTML)) {
            this.status = EnrollmentStatus.Eligible;
        }
        else {
            this.status = EnrollmentStatus.NotEligible;
        }
    };
    Enrollment.prototype.printSummary = function () {
        this.determineCategory();
        this.checkEligibility();
        console.log("Student Name: ".concat(this.student.name));
        console.log("Age: ".concat(this.student.age));
        console.log("Course: ".concat(this.student.courseName));
        console.log("Knows HTML: ".concat(this.student.knowsHTML));
        console.log("Course Category: ".concat(this.category));
        console.log("Enrollment Status: ".concat(this.status));
        console.log("------------------------");
    };
    return Enrollment;
}());
// Create student objects
var student1 = {
    name: "Sneha",
    age: 20,
    courseName: Course.Angular,
    knowsHTML: true
};
var student2 = {
    name: "Karan",
    age: 17,
    courseName: Course.NodeJS,
    knowsHTML: false
};
var student3 = {
    name: "Riya",
    age: 22,
    courseName: Course.Angular,
    knowsHTML: false
};
var student4 = {
    name: "Aman",
    age: 25,
    courseName: Course.FullStack,
    knowsHTML: true
};
// Create and process enrollments
var enrollment1 = new Enrollment(student1);
enrollment1.printSummary();
var enrollment2 = new Enrollment(student2);
enrollment2.printSummary();
var enrollment3 = new Enrollment(student3);
enrollment3.printSummary();
var enrollment4 = new Enrollment(student4);
enrollment4.printSummary();
