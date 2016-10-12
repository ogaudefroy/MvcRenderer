namespace MvcRenderer
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.UI;

    /// <summary>
    /// ASP.Net control render ASP.Net MVC actions within ASPX pages.
    /// </summary>
    public class MvcRenderer : Control, IViewDataContainer
    {
        private readonly RouteValueDictionary _routeValues = new RouteValueDictionary();
        private ViewDataDictionary _viewData;

        /// <summary>
        /// Gets or sets the action to render.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the controller to be invoked.
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Gets the route values dictionary.
        /// </summary>
        public RouteValueDictionary RouteValues
        {
            get
            {
                return _routeValues;
            }
        }
        
        /// <summary>
        /// Gets or sets the viewdata used to render the action.
        /// </summary>
        public ViewDataDictionary ViewData
        {
            get
            {
                return _viewData ?? (_viewData = new ViewDataDictionary());
            }
            set
            {
                _viewData = value;
            }
        }

        /// <summary>
        /// Renders the action on the writer.
        /// </summary>
        /// <param name="writer">The System.Web.UI.HtmlTextWriter object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            var context = new HttpContextWrapper(this.Context);
            var vc = new ViewContext()
            {
                HttpContext = context,
                TempData = LoadTempDataFromContext(context),
                Writer = writer
            };

            var htmlHelper = new HtmlHelper(vc, this);
            if (Area != null)
            {
                RouteValues.Add("Area", Area);
            }
            htmlHelper.RenderAction(this.Action, this.Controller, RouteValues);
        }

        /// <summary>
        /// Loads tempdata from an existing HTTP context.
        /// </summary>
        /// <param name="context">The HTTP context containing tempdata.</param>
        /// <returns>The tempdatadictionary.</returns>
        private TempDataDictionary LoadTempDataFromContext(HttpContextBase context)
        {
            var tempData = new TempDataDictionary();
            var tempDataProvider = CreateTempDataProvider();
            tempData.Load(new ControllerContext() { HttpContext = context }, tempDataProvider);
            return tempData;
        }

        /// <summary>
        /// Creates a ITempDataProvider instance based on current MVC Dependency resolution configuration.
        /// </summary>
        /// <returns>>A temporary data provider.</returns>
        private static ITempDataProvider CreateTempDataProvider()
        {
            var service = DependencyResolver.Current.GetService<ITempDataProviderFactory>();
            if (service != null)
            {
                return service.CreateInstance();
            }
            return DependencyResolver.Current.GetService<ITempDataProvider>() ?? new SessionStateTempDataProvider();
        }
    }
}
