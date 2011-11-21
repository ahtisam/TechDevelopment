<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoadAppDataFile.ascx.cs"
    Inherits="TrendITech.UI.usercontrols.utilities.LoadAppDataFile" %>
<fieldset>
    <legend>Load file list by selected file type</legend>
    <div class="clearfix">
        <p class="formControl clearfix inputText">
            <label for="ddlFileExtentions">
                <span class="required">*</span> Select file type to load
            </label>
            <asp:dropdownlist id="ddlFileExtentions" runat="server">
            </asp:dropdownlist>
        </p>
        <div class="formControl clearfix right">
            <asp:button id="btnLoadSelectedFile" runat="server" text="Load Selected File Types"
                cssclass="submit" onclick="btnLoadSelectedFile_Click" />
        </div>    
        <p class="formControl clearfix inputText">
            <label for="rdoBtnLstFiles">
                <span class="required">*</span> Select file from the list 
            </label>            
            <asp:radiobuttonlist id="rdoBtnLstFiles" runat="server" autopostback="True" onselectedindexchanged="rdoBtnLstFiles_SelectedIndexChanged">
            </asp:radiobuttonlist>
            <asp:hiddenfield id="hdnfldSelectFilePath" runat="server"></asp:hiddenfield>
            <asp:hiddenfield id="hdnfldSelectFile" runat="server"></asp:hiddenfield>
        </p>
    </div>
</fieldset>
