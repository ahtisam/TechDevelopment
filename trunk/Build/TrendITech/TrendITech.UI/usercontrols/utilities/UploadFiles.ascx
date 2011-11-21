<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadFiles.ascx.cs"
    Inherits="TrendITech.UI.usercontrols.utilities.UploadFiles" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<fieldset>
    <legend>Upload amamzon settlement files</legend>
    <div class="clearfix">
        <p class="formControl clearfix inputText">
            <label for="AsyncFileUpload1">
                <span class="required">*</span> Select the file
            </label>
            <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnUploadedComplete="AsyncFileUpload1_UploadedComplete"
                ThrobberID="Image1" />
            <asp:Image ID="Image1" runat="server" ImageUrl="/furniture/shared/generatorphp-thumb.gif" />
            <br />
        </p>
        <p class="formControl clearfix inputText">
            <label for="txtFileName">
                <span class="required">*</span> File name
            </label>
            <asp:Label ID="lblFileName" runat="server" Text="Label"></asp:Label>
            <%--<asp:TextBox ID="txtFileName" runat="server" ReadOnly="true"></asp:TextBox>--%>
        </p>
        <p class="formControl clearfix inputText">
            <label for="txtFileName">
                <span class="required">*</span> File size
            </label>
            <asp:Label ID="lblFileSize" runat="server" Text="Label"></asp:Label>
            <%--<asp:TextBox ID="txtFileSize" runat="server" ReadOnly="true"></asp:TextBox>--%>
        </p>
        <p class="formControl clearfix inputText">
            <label for="txtFileName">
                <span class="required">*</span> Store file location
            </label>
            <asp:Label ID="lblFileStoreLocation" runat="server" Text="Label"></asp:Label>
            <%--<asp:TextBox ID="txtFileStoreLocation" runat="server" ReadOnly="true"></asp:TextBox>--%>
        </p>
    </div>
</fieldset>
