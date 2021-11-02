using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hw6.Services
{
    public static class HtmlExtension
    {
        public static HtmlString MyEditorForModel(this IHtmlHelper helper)
        {
            var model = helper
                .ViewData
                .ModelMetadata
                .ModelType;
            
            var fieldsHtml = model
                .GetProperties()
                .Select(p => p.ConvertFieldToHtml(helper.ViewData.Model));

            return new HtmlString(string.Join("", fieldsHtml));
        }
        
        private static string ConvertFieldToHtml(this PropertyInfo propertyInfo, object model)
        {
            var span = Validation.Validate(propertyInfo, model);
            return propertyInfo.GetLabelForTitle() + (
                propertyInfo.PropertyType.IsEnum
                    ? propertyInfo.GetEnumSelectList()
                    : propertyInfo.GetLabelForInput(span, model));
        }

        private static string GetEnumSelectList(this PropertyInfo propertyInfo)
        {
            var name = propertyInfo.Name;
            var @enum = PairValueNameEnum.GetEnum(propertyInfo);
            var orderedEnum = @enum.OrderBy(a => a.Value);
            
            var select = new TagBuilder("select")
            {
                Attributes = {{"id", name}, {"name", name}}
            };
            
            foreach (var (value, str) in orderedEnum)
            {
                var option = new TagBuilder("option")
                {
                    Attributes = {{"value", value.ToString()}}
                };
                
                option.InnerHtml.Append(str);
                select.InnerHtml.AppendHtml(option);
            }
            
            return select.GetHtmlString();
        }
        
        private static string GetLabelForTitle(this PropertyInfo propertyInfo)
        {
            var name = propertyInfo.Name;
            var attr = propertyInfo.GetCustomAttribute<DisplayNameAttribute>();
            
            var displayName = attr is null 
                ? string.Join(" ", propertyInfo.Name.SplitByCamelCase()) 
                : attr.DisplayName;

            var div = new TagBuilder("div")
            {
                Attributes = {{"class", "editor-label"}}
            };

            var label = new TagBuilder("label")
            {
                Attributes = {{"for", name}}
            };
            
            label.InnerHtml.Append(displayName);
            div.InnerHtml.AppendHtml(label);
            
            return div.GetHtmlString();
        }

        private static string GetLabelForInput(this PropertyInfo propertyInfo, IHtmlContent? span, object model)
        {
            var propertyType = propertyInfo.PropertyType;

            var isContains = IntegerTypes
                .WholeTypes
                .IsContains(propertyType);
            
            var value = model is null ? "" : propertyInfo.GetValue(model)?.ToString();
            var input = new TagBuilder("input")
            {
                Attributes =
                {
                    {"class", "text-box single-line"},
                    {"data-val", "true"},
                    {"id", propertyInfo.Name},
                    {"name", propertyInfo.Name},
                    {"type", !isContains ? "text" : "number"},
                    {"value", value}
                }
            };

            var @class = new TagBuilder("div")
            {
                Attributes = {{"class", "editor-field"}}
            };

            @class.InnerHtml.AppendHtml(input);
            if (span != null) @class.InnerHtml.AppendHtml(span);
            return @class.GetHtmlString();
        }
        
        public static string GetHtmlString(this IHtmlContent content)
        {
            if (content is null) return "";
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}