namespace KSS.HorseRacing
{
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class ActionMenuItemExtension
    {
        /// <summary>
        /// The action menu item.
        /// </summary>
        /// <param name="htmlHelper">
        /// The html helper.
        /// </param>
        /// <param name="actionText">
        /// The action text.
        /// </param>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <returns>
        /// The System.Web.Mvc.MvcHtmlString.
        /// </returns>
        public static MvcHtmlString ActionMenuItem(this HtmlHelper htmlHelper, string actionText, string controller, string action)
        {
            var tagBuilder = new TagBuilder("li");
            var routeData = htmlHelper.ViewContext.RouteData;
            string activeAction = routeData.Values["action"].ToString();
            string activeController = routeData.Values["controller"].ToString();
            if (activeAction == action && activeController == controller)
            {
                tagBuilder.AddCssClass("active");
            }
            tagBuilder.InnerHtml = htmlHelper.ActionLink(actionText, action, controller).ToString();
            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
}