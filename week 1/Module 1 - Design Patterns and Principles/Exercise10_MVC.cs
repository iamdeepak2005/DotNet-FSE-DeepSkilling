using System;

namespace DesignPatterns.MVC
{
    // model
    public class Student
    {
        public string Name { get; set; }
        public string Grade { get; set; }
    }

    // view
    public class StudentView
    {
        public void Display(string name, string grade)
        {
            Console.WriteLine($"Student Profile: {name} (Grade: {grade})");
        }
    }

    // controller
    public class StudentController
    {
        private readonly Student _model;
        private readonly StudentView _view;

        public StudentController(Student model, StudentView view)
        {
            _model = model;
            _view = view;
        }

        public void SetName(string name) => _model.Name = name;
        public void SetGrade(string grade) => _model.Grade = grade;

        public void Render() => _view.Display(_model.Name, _model.Grade);
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- mvc architecture design test ---");

            Student model = new Student { Name = "Amit", Grade = "A" };
            StudentView view = new StudentView();
            StudentController controller = new StudentController(model, view);

            controller.Render();

            controller.SetName("Amit Sharma");
            controller.SetGrade("A+");
            controller.Render();
        }
    }
}