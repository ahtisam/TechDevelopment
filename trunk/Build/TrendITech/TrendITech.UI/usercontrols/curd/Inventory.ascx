<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Inventory.ascx.cs" Inherits="TrendITech.UI.usercontrols.curd.Inventory" %>
<link href="../../css/curd_form.css" rel="stylesheet" type="text/css" />
<link href="../../css/components/forms.css" rel="stylesheet" type="text/css" />
<link href="../../js/tablesorter/themes/green/style.css" rel="stylesheet" type="text/css" />
<script src="../../js/tablesorter/jquery.tablesorter.js" type="text/javascript"></script>
<script src="../../js/jquery.highlight.js" type="text/javascript"></script>
<asp:panel id="pnlMain" runat="server" cssclass="formPanel">
    <fieldset>
        <legend>Inventory form</legend>
        <asp:panel id="pnlMsg" runat="server">
            <asp:literal id="literalMsg" runat="server"></asp:literal>
        </asp:panel>
        <asp:panel id="pnlValidation" runat="server">
            <asp:literal id="literalValid" runat="server"></asp:literal>
        </asp:panel>
        <asp:panel id="pnlCUD" runat="server" cssclass="clearfix">
            <div class="clearfix">
                <p class="formControl clearfix inputText">
                    <label for="txtModelNo">
                        <span class="required">*</span> Model No
                    </label>
                    <asp:textbox id="txtModelNo" runat="server" maxlength="50">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="txtQty">
                        <span class="required">*</span> Quantity
                    </label>
                    <asp:textbox id="txtQty" runat="server" maxlength="50">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="txtCost">
                        <span class="required">*</span> Cost
                    </label>
                    <asp:textbox id="txtCost" runat="server" maxlength="50">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="txtDate">
                        <span class="required">*</span> Date
                    </label>
                    <asp:textbox id="txtDate" runat="server" maxlength="20" enabled="false" readonly="true">
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
        <table id="tblItemCollection" class="tablesorter">
            <thead>
                <tr>
                    <th>
                        Select
                    </th>
                    <th>
                        Model-No
                    </th>
                    <th>
                        Quantity
                    </th>
                    <th>
                        Cost
                    </th>
                    <th>
                        Journal ID
                    </th>
                    <th>
                        Create On
                    </th>
                </tr>
            </thead>
            <asp:repeater id="repItemCollection" runat="server">
                <itemtemplate>  
                    <tr class="even">  
                            <td>                                
                                <asp:Button runat="server" CssClass="submit" Text="Select"></asp:Button>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ModelNo") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Qty") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Cost") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JournalID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedDate") %>'></asp:Label>
                            </td>        
                        </tr>  
                </itemtemplate>
                <alternatingitemtemplate>
                    <tr class="odd">  
                            <td>                                
                                <asp:Button runat="server" CssClass="submit" Text="Select"></asp:Button>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ModelNo") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Qty") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Cost") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "JournalID") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedDate") %>'></asp:Label>
                            </td>        
                        </tr>  
                </alternatingitemtemplate>
            </asp:repeater>
        </table>
    </asp:panel>
</asp:panel>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        var max = 0;
        $("label").each(function () {
            if ($(this).width() > max)
                max = $(this).width();
        });

        $("label").width(max);

        //$('#<%=pnlMain.ClientID %>').highlight();
        $('#<%=pnlMain.ClientID %>').highlight();
        $("#tblItemCollection").tablesorter();
        $('#tblItemCollection').highlight();
    });
</script>
