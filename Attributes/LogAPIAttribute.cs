using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MetuljmaniaDatabase.Attributes
{
    /// <summary>
    /// Attribute for logging actions.
    /// </summary>
    public class LogAPIAttribute : ActionFilterAttribute
    {
        protected readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Log before the action method is invoked.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionDescriptor = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor;
            var controller = actionDescriptor.ControllerName;
            var method = actionDescriptor.ActionName;
            var parameters = string.Join(", ", context.ActionArguments.Select(x => x.Key + "='" + CustomObjectToString(x.Value) + "'").ToArray());
            _logger.Info("{0} / {1} / {2}", controller, method, parameters);

            return base.OnActionExecutionAsync(context, next);
        }

        /// <summary>
        /// Log before the action method is invoked.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var actionDescriptor = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor;
            var controller = actionDescriptor.ControllerName;
            var method = actionDescriptor.ActionName;
            var parameters = string.Join(", ", context.ActionArguments.Select(x => x.Key + "='" + CustomObjectToString(x.Value) + "'").ToArray());
            _logger.Info("{0} / {1} / {2}", controller, method, parameters);

            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Log after the action method is invoked.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var actionDescriptor = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor;
            var controller = actionDescriptor.ControllerName;
            var method = actionDescriptor.ActionName;
            _logger.Info("{0} / {1}", controller, method);

            base.OnActionExecuted(context);
        }

        /// <summary>
        /// Cast object to string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string CustomObjectToString(object obj)
        {
            try
            {
                if (obj is null)
                {
                    // Check if object is null - just return.
                    return null;
                }
                if (obj is string stringValue)
                {
                    // Check if object is a string - just return.
                    return stringValue;
                }
                if (obj.GetType().IsPrimitive)
                {
                    // Check if object is a primitive - cast to string.
                    return obj.ToString();
                }
                if (obj is IEnumerable enumerableObj)
                {
                    // Check if object is an enumerable - return values casted to strings.
                    return string.Join(", ", (from object element in enumerableObj select element.ToString()).ToList());
                }

                // Default handling - return all properties.
                var sb = new StringBuilder();
                var propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => !x.GetIndexParameters().Any());
                foreach (var propertyInfo in propertyInfos)
                {
                    var value = propertyInfo.GetValue(obj, null) ?? "null";
                    sb.Append(propertyInfo.Name + ": " + (string.Equals(propertyInfo.Name, "password", StringComparison.OrdinalIgnoreCase) ? "****" : value) + ", ");
                }

                return sb.ToString().TrimEnd(' ', ',');
            }
            catch (Exception)
            {
                // Handle - swallow exception as logging should really never break functionalities.
                return null;
            }
        }
    }
}
