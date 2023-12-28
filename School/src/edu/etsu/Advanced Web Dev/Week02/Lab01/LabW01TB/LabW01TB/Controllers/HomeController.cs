using LabW01TB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Schema;

namespace LabW01TB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PerfectNumber(int? id)
        {
            string output = "";
           if (id == null)
            {
                output = "No number";
            } 
           else if(id > 9000)
            {
                output = "The number is too large!";
            }
           else if (id <= 0)
            {
                output = "Positive integers only!";
            }
            else
            {
                output = "Divisors: ";
                int total = 0;
                for (int i = 1; i < id; i++)
                {
                    
                    if (id % i == 0)
                    {
                        output += $"{i} ";
                        total += i;
                    }
                }
                if(total == id)
                {
                    output += $"[{id} is the perfect number.]";
                }
                else
                {
                    output += $"[{id} is not the perfect number.]";
                }
            }
           return Content(output);
        }

        public IActionResult StudentGrades()
        {
            Student[] studentArray = new Student[5];

            Student fred = new Student();
            fred.Name = "Fred";
            fred.Grade = LetterGrade.D;
            studentArray[0] = fred;

            Student wilma = new Student();
            wilma.Name = "Wilma";
            wilma.Grade = LetterGrade.A;
            studentArray[1] = wilma;

            Student betty = new Student();
            betty.Name = "Betty";
            betty.Grade = LetterGrade.B;
            studentArray[2] = betty;

            Student barney= new Student();
            barney.Name = "Barney";
            barney.Grade = LetterGrade.F;
            studentArray[3] =  barney;

            Student pebbles = new Student();
            pebbles.Grade = LetterGrade.A;
            pebbles.Name = "Pebbles";
            studentArray[4] = pebbles;

            return View(studentArray);
        }

        public IActionResult TimesTable()
        {
            int[,] timesTable = new int[12,12];
            string output = "";
            for (int i = 1; i <= 12; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    timesTable[i -1,j - 1] = i * j;   
                }
            }
            for (int i=0; i< 12; i++)
            {
                for (int j =0; j < 12; j++)
                {
                    output += string.Format("{0, 4}", timesTable[i, j]);
                }
                output += "\n";
            }
            return Content(output);
        }

        public IActionResult StudentDetails()
        {
            Student s = new Student();
            s.Name = "Bob";
            s.Grade = LetterGrade.B;
            return View(s);
        }

        public IActionResult MyToy()
        {
            Toy myToy = new Toy();
            myToy.Price = 6.99;
            myToy.Name = "Stuffed Bear";
            myToy.ToyType = "Plush";

            return View(myToy);
        }
        public IActionResult SimpleTypes()
        {
            bool isTall = true;
            sbyte sbyteData = 12;
            decimal decimalData = 1.23m;
            float floatData = 3.14f;
            uint uintData = 235677;
            short shortData = 1234;

            return Content($"My name is Tyler. My values: {isTall} {sbyteData} {decimalData} {floatData} {uintData} {shortData}");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}