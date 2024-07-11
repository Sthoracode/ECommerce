using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Components
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public BreadcrumbViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public IViewComponentResult Invoke()
        {
            string returnUrl = httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString();
            var routeData = httpContextAccessor.HttpContext.GetRouteData();
            string controller = routeData.Values["controller"].ToString();
            string action = routeData.Values["action"].ToString();
            List<string> lst = new List<string> 
            {
                returnUrl, controller, action
            };
            return View(lst);
        }
    }
}
