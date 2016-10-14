# MvcRenderer
ASP.Net WebForms control rendering MVC actions

[![Build status](https://ci.appveyor.com/api/projects/status/cdj5sdlgbx51tydb?svg=true)](https://ci.appveyor.com/project/ogaudefroy/mvcrenderer) [![NuGet version](https://badge.fury.io/nu/MvcRenderer.svg)](https://badge.fury.io/nu/MvcRenderer)

## Basic usage

    <mr:MvcRenderer runat="server" Controller="Layout" Action="TopMenu" /> <%-- Basic rendering %-->
    <mr:MvcRenderer runat="server" Controller="Categories" Action="List" Area="Admin" /> <%-- Custom Area %-->

## Advanced usage
If you need to pass additional route values add an identifier to the control and set desired values in RouteValues property.
TempData are supported in rendered actions.
 
## Warning
If mixin WebForms with MVC for the first time, be carefull with declared MVC actions. If actions are not supposed to be accessible publicly do not forget to add a [ChildActionAttribute](https://msdn.microsoft.com/en-us/library/system.web.mvc.childactiononlyattribute%28v=vs.118%29.aspx) on the rendered actions.
