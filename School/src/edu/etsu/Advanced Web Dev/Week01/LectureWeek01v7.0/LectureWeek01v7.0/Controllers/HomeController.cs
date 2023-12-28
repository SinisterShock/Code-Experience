using LectureWeek01v7._0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Principal;
using System.Text.Json;

namespace LectureWeek01v7._0.Controllers
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
        public IActionResult HelloWorld()
        {
            return Content("Hello World!");
        }

        public IActionResult Hello(string? id)
        {
            var name = "Bob";
            if (id != null)
            {
                name = id;
            }
            return Content($"Hello, {name}!");
        }

        public IActionResult SimpleTypes()
        {
            bool isTall = false;
            byte age = 80;
            decimal money = 1.23m;
            float weight = 1.23f;
            return Content($"{isTall} {age} {money} {weight}");
        }
        enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        enum Months : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };

        public IActionResult EnumerationTypes()
        {
            Days today = Days.Monday;
            int dayNumber = (int)today;
            string model = $"{today} is day number #{dayNumber}. ";

            foreach (string item in Enum.GetNames(typeof(Months)))
            {
                model += item + " ";
            }

            return Content(model);
        }

        public IActionResult ClassTypes()
        {
            Employee e = new()
            {
                name = "Junior"
            };
            Manager m = new()
            {
                name = "Boss"
            };
            string model = e.Talk();
            model += " ";
            model += m.Talk();

            return Content(model);
        }

        public IActionResult InterfaceTypes()
        {
            IGetArea s = new Rectangle { length = 20, width = 10 };
            return Content($"The area of the shape is {s.GetArea()}");
        }

        public IActionResult ArrayTypes()
        {
            int[] array1 = new int[5];
            string s1 = String.Join(",", array1);

            int[] array2 = new int[] { 1, 3, 5, 7, 45, 4 };
            string s2 = String.Join(",", array2);

            int[] array3 = {1, 2, 3, 4 ,5};
            string s3 = String.Join(",", array3);

            int[,] twoDar = new int[2, 3];

            int[,] tda =
            {
                {1, 2, 3 },
                {4, 5, 6}
            };

            int[][] ja = new int[6][];
            ja[0] = new int[4] { 1, 2, 3, 4 };
            ja[5] = new int[10] {1, 2, 3, 4, 5 , 6, 7, 8, 9, 10 };

            return Content($"Array 1: [{s1}]\nArray 2: [{s2}]\nArray 3: [{s3}]");
        }

        public IActionResult ImplicitTypesDemo()
        {
            int i = 6;

            var s = "Hello";

            var a = new[] { 0, 1, 2 };

            var list = new List<int>();

            return Content($"i = {i} s = {s} a = {String.Join(",", a)} list = {String.Join(",", list)}");
        }

        public IActionResult AnonymousTypesDemo()
        {
            var o = new { Amount = 108, Message = "Hello" };
            var ojson = JsonSerializer.Serialize(o);


            var anonArray = new[]
            {
                new {name = "apple", diam = 4},
                new {name = "grape", diam = 1}
            };
            var ajson = JsonSerializer.Serialize(anonArray);

            return Content(
                $" o = {ojson}\n" +
                $"anonArray = {ajson}"
                );
        }

        public IActionResult LINQDemo()
        {
            var products = new[]
            {
                new {Color = "Red", Price = 1.3m},
                new {Color = "Blue", Price = 2.4m},
                new {Color = "Pink", Price = 0.89m}
            };

            var productQ = 
                from prod in products
                select new {prod.Color, Price = prod.Price * 2};

            var model = "";
            foreach(var p in productQ)
            {
                model += $"Color={p.Color}, Price={p.Price}" + Environment.NewLine;
            }
            return Content(model);
        }

        public IActionResult LambdaDemo()
        {
            var products = new[]
            {
                new {Id = 1, Color = "Red", Price = 1.3m},
                new {Id = 2, Color = "Blue", Price = 2.4m},
                new {Id = 3, Color = "Pink", Price = 0.89m}
            };

            var product = products.FirstOrDefault(p => p.Id == 2);

            var model = $"Id={product?.Id} Color={product?.Color} Price={product?.Price}";

            return Content(model);
            
        }

        public IActionResult NullableTypes(int? id)
        {
            var model = "";
            int? x = id;

            if (x.HasValue)
            {
                model += "x = " + Convert.ToString(x.Value);
            }
            else
            {
                model += "x = Undefined";
            }

            int? c = id;
            int d = c ?? -1;

            int? e = id;
            int? f = id;
            int g = e ?? f ?? -1;

            return Content($"{model} d={d} g={g}");
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