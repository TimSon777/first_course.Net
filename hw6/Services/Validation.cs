using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hw6.Services
{
    public static class Validation
    {
        public static IHtmlContent? Validate(PropertyInfo propertyInfo, object model)
        {
            var attributes = propertyInfo.GetCustomAttributes<ValidationAttribute>();

            foreach (var attr in attributes)
            {
                var value = propertyInfo.GetValue(model);
                if (attr.IsValid(value)) continue;

                var span = new TagBuilder("span")
                {
                    Attributes =
                    {
                        {"class", "field-validation-error"},
                        {"data-valmsg-for", propertyInfo.Name},
                        {"data-valmsg-replace", "true"}
                    }
                };
                
                return span.InnerHtml.Append(attr.ErrorMessage ?? attr.FormatErrorMessage(propertyInfo.Name));
            }

            return null;
        }
    }
}