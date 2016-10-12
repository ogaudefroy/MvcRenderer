<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomPage.aspx.cs" Inherits="MvcRenderer.SampleApp.CustomPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>I am a WebForm page</h1>
    <form id="form1" runat="server">
    <div>
        <mr:MvcRenderer runat="server" Controller="Home" Action="IntegratedZone" />
    </div>
        <asp:HyperLink runat="server" NavigateUrl="~/" Text="Go back to MVC" />
    </form>
</body>
</html>
