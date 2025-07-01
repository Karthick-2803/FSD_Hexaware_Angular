// Enum for Courses
enum Course {
    Angular = "Angular",
    NodeJS = "Node.js",
    FullStack = "FullStack"
}

// Enum for Course Category
enum CourseCategory {
    FrontEnd = "Front-End",
    BackEnd = "Back-End",
    FullStack = "Full-Stack"
}

// Enum for Enrollment Status
enum EnrollmentStatus {
    Eligible = "Eligible",
    NotEligible = "Not Eligible"
}

// Interface for Student
interface Student {
    name: string;
    age: number;
    courseName: Course;
    knowsHTML: boolean;
}

// Class for handling enrollment
class Enrollment {
    private status: EnrollmentStatus;
    private category: CourseCategory;

    constructor(private student: Student) {}

    private determineCategory(): void {
        if (this.student.courseName === Course.Angular) {
            this.category = CourseCategory.FrontEnd;
        } else if (this.student.courseName === Course.NodeJS) {
            this.category = CourseCategory.BackEnd;
        } else {
            this.category = CourseCategory.FullStack;
        }
    }

    private checkEligibility(): void {
        if (
            this.student.age >= 18 &&
            (this.student.courseName !== Course.Angular || this.student.knowsHTML)
        ) {
            this.status = EnrollmentStatus.Eligible;
        } else {
            this.status = EnrollmentStatus.NotEligible;
        }
    }

    public printSummary(): void {
        this.determineCategory();
        this.checkEligibility();

        console.log(`Student Name: ${this.student.name}`);
        console.log(`Age: ${this.student.age}`);
        console.log(`Course: ${this.student.courseName}`);
        console.log(`Knows HTML: ${this.student.knowsHTML}`);
        console.log(`Course Category: ${this.category}`);
        console.log(`Enrollment Status: ${this.status}`);
        console.log("------------------------");
    }
}

// Create student objects
const student1: Student = {
    name: "Sneha",
    age: 20,
    courseName: Course.Angular,
    knowsHTML: true
};

const student2: Student = {
    name: "Karan",
    age: 17,
    courseName: Course.NodeJS,
    knowsHTML: false
};

const student3: Student = {
    name: "Riya",
    age: 22,
    courseName: Course.Angular,
    knowsHTML: false
};

const student4: Student = {
    name: "Aman",
    age: 25,
    courseName: Course.FullStack,
    knowsHTML: true
};

// Create and process enrollments
const enrollment1 = new Enrollment(student1);
enrollment1.printSummary();

const enrollment2 = new Enrollment(student2);
enrollment2.printSummary();

const enrollment3 = new Enrollment(student3);
enrollment3.printSummary();

const enrollment4 = new Enrollment(student4);
enrollment4.printSummary();
