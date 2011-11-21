<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadAmazonFile.ascx.cs"
    Inherits="TrendITech.UI.usercontrols.batchFiles.UploadAmazonFile" %>
<%@ Register Src="../utilities/LoadAppDataFile.ascx" TagName="LoadAppDataFile" TagPrefix="uc1" %>
<%@ Register Src="../utilities/UploadFiles.ascx" TagName="UploadFiles" TagPrefix="uc2" %>
<link href="../../css/curd_form.css" rel="stylesheet" type="text/css" />
<link href="../../css/components/forms.css" rel="stylesheet" type="text/css" />
<link href="../../js/tablesorter/themes/green/style.css" rel="stylesheet" type="text/css" />
<script src="../../js/tablesorter/jquery.tablesorter.js" type="text/javascript"></script>
<script src="../../js/jquery.highlight.js" type="text/javascript"></script>
<asp:panel id="pnlMain" runat="server" cssclass="formPanel">
    <uc2:UploadFiles ID="UploadFiles1" runat="server" />
    <uc1:LoadAppDataFile ID="LoadAppDataFile1" runat="server" />
    <fieldset>
        <legend>Execute amazon settlement file</legend>
        <div class="clearfix">
            <p class="formControl clearfix inputText">
                <label for="lblStatus">
                    Status
                </label>
                <asp:label id="lblStatus" runat="server" text="" font-bold="True" forecolor="#3333FF">
                </asp:label>
            </p>
            <div class="formControl clearfix right">
                <asp:button id="btnExecuteAmazonSatelmentFile" runat="server" text="Execute Amazon Satelment File"
                    cssclass="submit" onclick="btnExecuteAmazonSatelmentFile_Click" />
                &#160;
            </div>
            
            <div class="clearfix" style="margin: 10px auto; overflow:auto;width:995px;">
                <asp:gridview id="gvAmazonSatelemntFileProgress" runat="server" cellpadding="4" forecolor="#333333"
                    gridlines="None">
                    <alternatingrowstyle backcolor="White" forecolor="#284775" />
                    <editrowstyle backcolor="#999999" />
                    <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                    <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                    <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
                    <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
                    <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                    <sortedascendingcellstyle backcolor="#E9E7E2" />
                    <sortedascendingheaderstyle backcolor="#506C8C" />
                    <sorteddescendingcellstyle backcolor="#FFFDF8" />
                    <sorteddescendingheaderstyle backcolor="#6F8DAE" />
                </asp:gridview>
            </div>
            <div class="clearfix" style="overflow:hidden;">
                <asp:literal id="InsertedRecordsDetails" runat="server"></asp:literal>
            </div>

        </div>
    </fieldset>
</asp:panel>