<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Order.ascx.cs" Inherits="TrendITech.UI.usercontrols.curd.Order" %>
<link href="../../css/curd_form.css" rel="stylesheet" type="text/css" />
<link href="../../css/components/forms.css" rel="stylesheet" type="text/css" />
<link href="../../js/tablesorter/themes/green/style.css" rel="stylesheet" type="text/css" />
<script src="../../js/tablesorter/jquery.tablesorter.js" type="text/javascript"></script>
<script src="../../js/jquery.highlight.js" type="text/javascript"></script>

<script>
    !window.jQuery && document.write('<script src="jquery-1.4.3.min.js"><\/script>');
	</script>
<script type="text/javascript" src="../../js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
<script type="text/javascript" src="../../js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
<link rel="stylesheet" type="text/css" href="../../js/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
<%--<link href="../../js/fancybox/style.css" rel="stylesheet" type="text/css" />--%>

<asp:panel id="pnlMain" runat="server" cssclass="formPanel">
    <fieldset>
        <legend>Order form</legend>
        <asp:panel id="pnlMsg" runat="server">
            <asp:literal id="literalMsg" runat="server"></asp:literal>
        </asp:panel>
        <asp:panel id="pnlValidation" runat="server">
            <asp:literal id="literalValid" runat="server"></asp:literal>
        </asp:panel>
        <asp:panel id="pnlCUD" runat="server" cssclass="clearfix">
            <div class="clearfix">
                <p class="formControl clearfix inputText">
                    <label for="txtOrderCreateDate">
                        <span class="required">*</span> Create Date
                    </label>
                    <asp:textbox id="txtOrderCreateDate" runat="server" maxlength="50">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="txtOrderExpectedDate">
                        <span class="required">*</span> Expected Date
                    </label>
                    <asp:textbox id="txtOrderExpectedDate" runat="server" maxlength="50">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="txtOrderAmount">
                        <span class="required">*</span> Total Amount
                    </label>
                    <asp:textbox id="txtOrderAmount" runat="server" maxlength="50" text="0.00" enabled="false">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="txtOrderItems">
                        <span class="required">*</span> Total Items
                    </label>
                    <asp:textbox id="txtOrderItems" runat="server" maxlength="50" text="0" enabled="false">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="txtRefNote">
                        <span class="required">*</span> Reference Note
                    </label>
                    <asp:textbox id="txtRefNote" runat="server" maxlength="500" textmode="MultiLine"
                        rows="5" columns="20">
                    </asp:textbox>
                </p>
                <div class="formControl clearfix right">
                    <asp:button runat="server" text="Reload" cssclass="submit" />
                    <asp:button runat="server" text="Edit" cssclass="submit" visible="false" />
                    <asp:button runat="server" text="Save" cssclass="submit" />
                    <asp:button id="btnDelete" runat="server" text="Delete" cssclass="submit" visible="false" />
                    <asp:button id="btnUpdate" runat="server" text="Update" cssclass="submit" visible="false" />
                    <asp:button runat="server" text="Cancel" cssclass="submit" />
                </div>
            </div>
        </asp:panel>
    </fieldset>
    
    <asp:panel id="pnlRead" runat="server" cssclass="">
        <asp:updatepanel id="updateOrderDetail" runat="server" updatemode="Always">
            <contenttemplate>
        
            <asp:listview id="lvDynamicTextboxes" runat="server" itemplaceholderid="itemPlaceholder" 
                onitemdatabound="lvDynamicTextboxes_ItemDataBound" 
                onitemcommand="lvDynamicTextboxes_ItemCommand">
                <layouttemplate>
                <table id="tblItemCollection" class="tablesorter">
                <thead>
                    <tr>
                        <th>
                            Select
                        </th>
                        <th>
                            Image
                        </th>
                        <th>
                            Model No
                        </th>
                        <th>
                            Cost
                        </th>
                        <th>
                            Qunatity
                        </th>
                        <th>
                            Ref Note
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                </tbody>
                </table>
            </layouttemplate>
                <ItemTemplate>
                <tr class="even">                    
                    <td>
                        <asp:HiddenField id="classID" runat="server" Value="<%# Container.DataItemIndex %>"></asp:HiddenField>
                        <asp:HiddenField id="DbID" runat="server" Value="0"></asp:HiddenField>
                        <asp:HiddenField id="Active" runat="server" Value="1"></asp:HiddenField>
                        <asp:Button id="btnRemove" runat="server" Text="Remove" CssClass="submit" CommandName="Remove" />
                        &#160;                                
                        <asp:Button id="btnAdd" runat="server" CssClass="submit" Text="Add" CommandName="Create"/>
                    </td>
                    <td>
                        <a id="smallImg" runat="server" class="Popup" href="">
                            <asp:Image id="img" runat="server"></asp:Image>
                        </a>
                    </td>
                    <td>
                        <asp:DropDownList id="ddlModel" runat="server" ></asp:DropDownList>
                        <asp:Button id="btnLoad" runat="server" CssClass="submit" Text="..." CommandName="Load"/>
                    </td>
                    <td>
                        <asp:TextBox id="txtCost" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox id="txtQty" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox id="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td> 
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="odd">
                    <td>
                        <asp:HiddenField id="classID" runat="server" Value="<%# Container.DataItemIndex %>"></asp:HiddenField>
                        <asp:HiddenField id="DbID" runat="server" Value="0"></asp:HiddenField>
                        <asp:HiddenField id="Active" runat="server" Value="1"></asp:HiddenField>
                        <asp:Button id="btnRemove" runat="server" Text="Remove" CssClass="submit" CommandName="Remove" />
                        &#160;                                
                        <asp:Button id="btnAdd" runat="server" CssClass="submit" Text="Add" CommandName="Create"/>
                    </td>
                    <td>
                        <a id="smallImg" runat="server" class="Popup" href="">
                            <asp:Image id="img" runat="server"></asp:Image>
                        </a>
                    </td>
                    <td>
                        <asp:DropDownList id="ddlModel" runat="server" ></asp:DropDownList>
                        <asp:Button id="btnLoad" runat="server" CssClass="submit" Text="..." CommandName="Load"/>
                    </td>
                    <td>
                        <asp:TextBox id="txtCost" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox id="txtQty" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox id="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>                                                
                </tr>
            </AlternatingItemTemplate>
            </asp:listview>
            <asp:Literal id="script" runat="server"></asp:Literal>
            </contenttemplate>
        </asp:updatepanel>
    </asp:panel>
</asp:panel>
<script type="text/javascript">

    $(document).ready(function () {
        var max = 0;
        $("label").each(function () {
            if ($(this).width() > max)
                max = $(this).width();
        });

        $("label").width(max);        
        $('#<%=pnlMain.ClientID %>').highlight();        
        $('#tblItemCollection').highlight();
        AssignFancyBox();

    });

    function AssignFancyBox() {        
        $("a.Popup").fancybox();
    }

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
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    }

</script>
