using System.IO;
using System.Web.Mvc;

namespace WebApplication1
{
    public static class MvcExtensions
    {
        public static string ConvertViewToString(this Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                ViewContext vContext = new ViewContext(controller.ControllerContext, vResult.View, controller.ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }
    }
}