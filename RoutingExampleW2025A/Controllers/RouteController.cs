using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoutingExampleW2025A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        /// <summary>
        /// This method receives a get request and outputs a message
        /// </summary>
        /// <returns>A message indicating another routing example</returns>
        /// <example>
        /// GET: localhost:xx/api/Route/Get1 -> Routing Example 1
        /// </example>
        [HttpGet(template: "Get1")]
        public string Get1()
        {
            return "Routing Example 1";
        }

        /// <summary>
        /// This method receives a get request and outputs a message
        /// </summary>
        /// <returns>A message indicating a routing example</returns>
        /// <example>
        /// GET: localhost:xx/api/Route/Get2 -> Routing Example 2
        /// </example>
        [HttpGet(template:"Get2")]
        public string Get2()
        {
            return "Routing Example 2";
        }

        // Another Comment here

        /// <summary>
        /// This method will receive a course code and welcome us to that course
        /// </summary>
        /// <param name="CourseCode">The name of the course to welcome</param>
        /// <returns>
        /// "Welcome to {CourseCode}", where {CourseCode} is an input string
        /// </returns>
        /// <example>
        /// GET: localhost:xx/api/Route/Get3?CourseCode=5125&Section=A&Semester=Winter -> Welcome to 5125 Section A Winter Semester
        /// </example>
        /// <example>
        /// GET: localhost:xx/api/Route/Get3?CourseCode=5126&Section=B&Semester=Summer -> Welcome to 5126 Section B Summer Semester
        /// </example>
        [HttpGet(template:"Get3")]
        public string Get3(string CourseCode, string Section, string Semester)
        {
            string message = $"Welcome to {CourseCode} Section {Section} {Semester} Semester";
           
            return message;
        }

        /// <summary>
        /// We want to receive an input temperature in degrees F and return that same temperature in C
        /// </summary>
        /// <param name="F">The input degrees in degrees Farehenheit (F)</param>
        /// <returns>
        /// The input temperature in degrees Celcius by taking the input temperature, applying the formula {F - 32} * 5/9
        /// </returns>
        /// <example>
        /// GET: api/Route/ConvertTemperature?F=80 -> 26.66667
        /// </example>
        /// <example>
        /// GET: api/Route/ConvertTemperature?F=55 -> 12.777777777777779
        /// </example>
        [HttpGet(template:"ConvertTemperature")]
        public double ConvertTemperature(double F)
        {
            // Compute Celcius from Farehenheit
            double C = (F - 32) * (5.0 / 9.0);
            return C;
        }

        /// <summary>
        /// This method receives a length in cm and returns the same length in inches
        /// </summary>
        /// <param name="cm">the input length in cm</param>
        /// <returns>
        /// The same length in inches
        /// </returns>
        /// <example>
        /// POST : localhost:xx/api/Route/ConvertToInches
        /// REQUEST BODY / FORM DATA: cm=1
        /// Content-Type: application/x-www-form-urlencoded
        /// -> 0.3937
        /// </example>
        /// <example>
        /// POST : localhost:xx/api/Route/ConvertToInches
        /// REQUEST BODY / FORM DATA: cm=10
        /// Content-Type: application/x-www-form-urlencoded
        /// -> 3.937
        /// </example>
        /// /// <example>
        /// POST : localhost:xx/api/Route/ConvertToInches
        /// REQUEST BODY / FORM DATA: cm=2.54
        /// Content-Type: application/x-www-form-urlencoded
        /// -> 0.999999999
        /// </example>
        [HttpPost(template:"ConvertToInches")]
        [Consumes("application/x-www-form-urlencoded")]
        public double ConvertToInches([FromForm]double cm)
        {
            double inches = cm * (1 / 2.54);
            return inches;
        }


        /// <summary>
        /// We want to receive a length, width, and height in inches and compute the value in cm^3
        /// </summary>
        /// <returns>
        /// A string that describes the total volume in cm cubed
        /// </returns>
        /// <example>
        /// POST: api/Route/ConvertToCmCubed
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: length_imperial=1&width_imperial=1&height_imperial=1
        /// -> The total volume is 16.387cm^3
        /// </example>
        /// <example>
        /// POST: api/Route/ConvertToCmCubed
        /// Header: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: length_imperial=10&width_imperial=10&height_imperial=10
        /// -> The total volume is 16387.064cm^3
        /// </example>
        [HttpPost(template:"ConvertToCmCubed")]
        [Consumes("application/x-www-form-urlencoded")]
        public string ConvertToCmCubed([FromForm] double length_imperial, [FromForm]double height_imperial, [FromForm] double width_imperial)
        {
            

            double length_metric = length_imperial * 2.54;
            double height_metric = height_imperial * 2.54;
            double width_metric = width_imperial* 2.54;

            return "The total volume is " + (length_metric * height_metric * width_metric) + " cm^3";

        }

        
        /// <summary>
        /// This method receives a POST request and outputs the body of that request
        /// </summary>
        /// <param name="input">The request body string</param>
        /// <returns>
        /// A string matching the request body
        /// </returns>
        /// <example>
        /// POST: api/Route/Post1
        /// Data: "My Message"
        /// Content-Type: application/json
        /// -> "My Message"
        /// </example>
        [HttpPost(template:"Post1")]
        public string Post1([FromBody]string input)
        {
            string output = input;
            return output;
        }

    }
}
