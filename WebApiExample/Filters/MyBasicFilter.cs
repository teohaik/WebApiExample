using Microsoft.AspNetCore.Mvc.Filters;

namespace SimpleDotNetWebAPI
{
    public class MyBasicFilter : IActionFilter

    {

 
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("AFTER the HTTP method execution");

            Console.WriteLine("Request Headers AFTER EXECUTION:");

            foreach (var item in context.HttpContext.Request.Headers)
            {
                Console.WriteLine(item.Key + "=" + item.Value);
            }

            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("RESPONSE HEADERS AFTER EXECUTION:");

            foreach (var item in context.HttpContext.Response.Headers)
            {
                Console.WriteLine(item.Key + "=" + item.Value);
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
                 
            Console.WriteLine("We are just before the HTTP method execution");

            var ca = context.HttpContext;

            if (ca.Request.Method.Equals("GET"))
            {
                Console.WriteLine("Method is GET");
            }
            else if (ca.Request.Method.Equals("POST"))
            {
                Console.WriteLine("Method is POST");
            }

            Console.WriteLine("Headers BEFORE EXECUTION:");

            foreach(var item in ca.Request.Headers)
            {
               Console.WriteLine(item.Key + "=" + item.Value);  
            }

            ca.Request.Headers.Add("super", "secret");
            ca.Request.Headers.Add("Iron", "Man");


            context.HttpContext.Response.Headers.Add("responseHeaderKey", "Value");
            context.HttpContext.Response.Headers.Add("responseHeaderKey2", "Value2");
            context.HttpContext.Response.Headers.Add("responseHeaderKey3", "Value3");

        }
    }
}
