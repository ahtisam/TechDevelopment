<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuTypes.ascx.cs" Inherits="TrendITech.UI.usercontrols.curd.MenuTypes" %>
<link href="../../css/curd_form.css" rel="stylesheet" type="text/css" />
<link href="../../css/components/forms.css" rel="stylesheet" type="text/css" />
<link href="../../js/tablesorter/themes/green/style.css" rel="stylesheet" type="text/css" />
<script src="../../js/tablesorter/jquery.tablesorter.js" type="text/javascript"></script>
<script src="../../js/jquery.highlight.js" type="text/javascript"></script>
<asp:panel id="pnlMain" runat="server" cssclass="formPanel">
    <fieldset>
        <legend>Menu types form</legend>
        <asp:panel id="pnlMsg" runat="server">
            <asp:literal id="literalMsg" runat="server"></asp:literal>
        </asp:panel>
        <asp:panel id="pnlValidation" runat="server">
            <asp:literal id="literalValid" runat="server"></asp:literal>
        </asp:panel>
        <asp:panel id="pnlCUD" runat="server" cssclass="clearfix">
            <div class="clearfix">
                <p class="formControl clearfix inputText">
                    <label for="txtName">
                        <span class="required">*</span> Name
                    </label>
                    <asp:textbox id="txtName" runat="server" maxlength="50">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="txtDesc">
                        <span class="required">*</span> Description
                    </label>
                    <asp:textbox id="txtDesc" runat="server" maxlength="500" textmode="MultiLine" rows="5"
                        columns="20">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputSingleCheck">
                    <label for="chkActive">
                        <span class="required">*</span> State
                    </label>
                    <asp:checkbox id="chkActive" runat="server" text="Active" checked="true">
                    </asp:checkbox>
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
                        Name
                    </th>
                    <th>
                        Description
                    </th>
                    <th>
                        State
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
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Desc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox runat="server" readonly="true"></asp:CheckBox>
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
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Desc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox runat="server" readonly="true"></asp:CheckBox>
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
<%--<link href="../../css/curd_form.css" rel="stylesheet" type="text/css" />
<link href="../../css/components/buttons.css" rel="stylesheet" type="text/css" />
<link href="../../css/components/forms.css" rel="stylesheet" type="text/css" />
<asp:panel id="pnlMain" runat="server" cssclass="formPanel">
    <asp:panel id="pnlTopheading" runat="server">
        <h2>
            <asp:label id="lblHeaeding" runat="server" text="Label"></asp:label>
        </h2>
    </asp:panel>
    <asp:panel id="pnlMsg" runat="server">
        <asp:literal id="literalMsg" runat="server"></asp:literal>
    </asp:panel>
    <asp:panel id="pnlValidation" runat="server">
        <asp:literal id="literalValid" runat="server"></asp:literal>
    </asp:panel>
    <asp:panel id="pnlFormContainer" runat="server" cssclass="formControl">
        <asp:panel id="pnlCreate" runat="server" cssclass="clearfix">
            <div class="clearfix">               
                <p class="formControl clearfix inputText">
                    <label for="txtName">
                        <span class="required">*</span> Name
                    </label>
                    <asp:textbox id="txtName" runat="server" maxlength="50">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="txtDesc">
                        <span class="required">*</span> Description
                    </label>
                    <asp:textbox id="txtDesc" runat="server" maxlength="500" textmode="MultiLine" rows="5"
                        columns="20">
                    </asp:textbox>
                </p>
                <p class="formControl clearfix inputSingleCheck">
                    <label for="chkActive">
                        <span class="required">*</span> State
                    </label>
                    <asp:checkbox id="chkActive" runat="server" text="Active" checked="true">
                    </asp:checkbox>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="txtDate">
                        <span class="required">*</span> Date
                    </label>
                    <asp:textbox id="txtDate" runat="server" maxlength="20" enabled="false" readonly="true">
                    </asp:textbox>
                </p>
                <div class="formControl clearfix right">
                    <asp:imagebutton id="imgbtnCancel" runat="server" imageurl="~/furniture/shared/cancel.png"
                        alternatetext="Cancel" onclick="imgbtnCancel_Click">
                    </asp:imagebutton>
                    <asp:imagebutton id="imgbtnReload" runat="server" imageurl="~/furniture/shared/reload.png"
                        alternatetext="Reload" onclick="imgbtnReload_Click">
                    </asp:imagebutton>
                    <asp:imagebutton id="imgbtnSave" runat="server" imageurl="~/furniture/shared/save.png"
                        alternatetext="Save" onclick="imgbtnSave_Click">
                    </asp:imagebutton>
                </div>
                <asp:panel id="pnlUpdate" runat="server" cssclass="clearfix" visible="false">
                    <div class="formControl clearfix right">
                        <asp:imagebutton id="imgbtnUpdateCancel" runat="server" imageurl="~/furniture/shared/cancel.png"
                            alternatetext="Cancel" onclick="imgbtnUpdateCancel_Click">
                        </asp:imagebutton>
                        <asp:imagebutton id="imgbtnUpdate" runat="server" imageurl="~/furniture/shared/update.png"
                            alternatetext="Update" onclick="imgbtnUpdate_Click">
                        </asp:imagebutton>
                    </div>
                </asp:panel>
                <asp:panel id="pnlDelete" runat="server" cssclass="clearfix" visible="false">
                    <div class="formControl clearfix right">
                        <asp:imagebutton id="imgbtnDelCancel" runat="server" imageurl="~/furniture/shared/cancel.png"
                            alternatetext="Cancel" onclick="imgbtnDelCancel_Click">
                        </asp:imagebutton>
                        <asp:imagebutton id="imgbtnDelete" runat="server" imageurl="~/furniture/shared/delete.png"
                            alternatetext="Delete" onclick="imgbtnDelete_Click">
                        </asp:imagebutton>
                    </div>
                </asp:panel>
            </div>
        </asp:panel>
        <asp:panel id="pnlRead" runat="server" cssclass="clearfix">
            <div class="formPanel clearfix">
                <asp:repeater id="repMenuTypes" runat="server">
                    <headertemplate>
                        <table class="imagetable">  
                        <tr>  
                            <th>Select</th>                              
                            <th>Name</th>
                            <th>Description</th>  
                            <th>State</th>  
                            <th>Create On</th>
                        </tr>  
                    </headertemplate>
                    <itemtemplate>  
                        <tr>  
                            <td>                                
                                <asp:ImageButton runat="server" ImageUrl="~/furniture/shared/ok.png" AlternateText="Select"></asp:ImageButton>
                            </td>                            
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Desc") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox runat="server" readonly="true"></asp:CheckBox>
                            </td>
                            <td>
                                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedDate") %>'></asp:Label>
                            </td>        
                        </tr>  
                    </itemtemplate>
                    <footertemplate>  
                        <tr>  
                            <td colspan="5">  
                                Important Note: 
                            </td>  
                        </tr>  
                        </table>
                    </footertemplate>
                </asp:repeater>
            </div>
        </asp:panel>
    </asp:panel>
</asp:panel>--%>