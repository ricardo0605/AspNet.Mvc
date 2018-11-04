using System.Web.Mvc;

namespace CrossCutting
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            if (filterContext.Exception != null)
            {
                // As we are dealing with asp.net pipeline, all actions
                // has to be done asynchronously.

                // LOG register
                // Send e-mail to system admin
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
