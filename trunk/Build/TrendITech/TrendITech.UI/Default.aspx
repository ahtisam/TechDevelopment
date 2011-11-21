<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="TrendITech.UI.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="usercontrols/curd/Category.ascx" TagName="Category" TagPrefix="uc1" %>
<%@ Register Src="usercontrols/curd/Inventory.ascx" TagName="Inventory" TagPrefix="uc2" %>
<%@ Register Src="usercontrols/curd/Menu.ascx" TagName="Menu" TagPrefix="uc3" %>
<%@ Register Src="usercontrols/curd/MenuTypes.ascx" TagName="MenuTypes" TagPrefix="uc4" %>
<%@ Register Src="usercontrols/curd/Order.ascx" TagName="Order" TagPrefix="uc5" %>
<%@ Register Src="usercontrols/curd/Products.ascx" TagName="Products" TagPrefix="uc6" %>


<%@ Register src="usercontrols/batchFiles/UploadAmazonFile.ascx" tagname="UploadAmazonFile" tagprefix="uc7" %>


<%@ Register src="usercontrols/reporting/VATCalculation.ascx" tagname="VATCalculation" tagprefix="uc8" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ISPAR</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/base.css" rel="stylesheet" type="text/css" />
    <link href="css/tipography.css" rel="stylesheet" type="text/css" />
    <link href="css/structure.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data" method="post">
    <div id="pageId" class="wrapper">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="false" DisplayAfter="1">
            <ProgressTemplate>
                <div id="progressBackgroundFilter">
                </div>
                <div id="processMessage">
                    <table style="text-align: center; width: 100%;">
                        <tr>
                            <td>
                                <p>
                                    Loading...</p>
                                <img alt="Loading" src="/furniture/shared/generatorphp-thumb.gif" />
                                <p>
                                    please wait</p>
                            </td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Always">
            <ContentTemplate>--%>
        
        <%--</ContentTemplate>
        </asp:UpdatePanel>
        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                if (args.get_error() == undefined) {
                    //alert("Fired JS after loading AJAX requests!");
                    $(document).ready(function () {
                        
                         AssignFancyBox();
                    });
                }
            }

            function load() {
                alert('Load');
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            }
    
        </script>--%>
    </div>
    <%--<uc1:Category ID="Category1" runat="server" />
    <uc2:Inventory ID="Inventory1" runat="server" />
    <uc3:Menu ID="Menu1" runat="server" />
    <uc4:MenuTypes ID="MenuTypes1" runat="server" />
    <uc5:Order ID="Order1" runat="server" />
    <uc6:Products ID="Products1" runat="server" />
    <uc5:Order ID="Order1" runat="server" />--%>
    <%--<uc7:UploadAmazonFile ID="UploadAmazonFile1" runat="server" />--%>

    <uc8:VATCalculation ID="VATCalculation1" runat="server" />

    </form>
</body>
</html>
