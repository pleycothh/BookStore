using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace ConsoleWebApi
{
    public class CustomBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;

            // get data by keyvalue "countries" return bool, and return country based on key input from query
            var result = data.TryGetValue("countries", out var country);



            if (result)
            {
                var array = country.ToString().Split('|');

                bindingContext.Result = ModelBindingResult.Success(array); 
            }

            return Task.CompletedTask;

        }
    }
}
