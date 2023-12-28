namespace LectureWeek01v7._0.Models
{
    public class Rectangle : IGetArea
    {
        public double length { get; set; }
        public double width { get; set; }

        public double GetArea()
        {
            return length * width;
        }
    }
}
