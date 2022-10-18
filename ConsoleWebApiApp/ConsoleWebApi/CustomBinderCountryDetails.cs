using ConsoleWebApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace ConsoleWebApi
{
    public class CustomBinderCountryDetails : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // id
            var modelName = bindingContext.ModelName;

            // id value
            var value = bindingContext.ValueProvider.GetValue(modelName);

            var result = value.FirstValue;

             

            if (!int.TryParse(result, out var id))
            {
                return Task.CompletedTask;
                
            }

            var model = new CountryModel()
            {
                Id = id,
                Area = 400,
                Name = "Ind",
                Population = 500
            };

            bindingContext.Result = ModelBindingResult.Success(model);

            return Task.CompletedTask;
        }
    }
}
