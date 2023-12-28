namespace LectureWeek01v7._0.Models
{
    public class Employee
    {
        public string name { get; set; } = String.Empty;

        public virtual string Talk()
        {
            return $"{name}: blah blah blah";
        }

    }
    public class Manager : Employee
    {
        public override string Talk()
        {
            return $"{name}: Get back to work!";
        }
    }
}
