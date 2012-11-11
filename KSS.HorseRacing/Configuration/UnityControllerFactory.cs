namespace KSS.HorseRacing.Configuration
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class UnityControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// The create controller.
        /// </summary>
        /// <param name="requestContext">
        /// The request context.
        /// </param>
        /// <param name="controllerName">
        /// The controller name.
        /// </param>
        /// <returns>
        /// The System.Web.Mvc.IController.
        /// </returns>
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName != "Content")
            {
                Type controllerType = base.GetControllerType(requestContext, controllerName);
                return (IController)IoC.Resolve(controllerType);
            }

            return null;
        }
    }
}