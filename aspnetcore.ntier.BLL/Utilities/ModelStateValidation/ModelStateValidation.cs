using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.BLL.Utilities.ModelStateValidation
{
    public class ModelStateValidation
    {

        public ModelStateDictionary ModelStateErrors(ModelStateDictionary ModelState, Dictionary<string, string> Errors)
        {
            foreach (var error in Errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }
            return ModelState;
        }
    }
}
