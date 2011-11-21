<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VATCalculation.ascx.cs"
    Inherits="TrendITech.UI.usercontrols.reporting.VATCalculation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../../css/curd_form.css" rel="stylesheet" type="text/css" />
<link href="../../css/components/forms.css" rel="stylesheet" type="text/css" />
<link href="../../js/tablesorter/themes/green/style.css" rel="stylesheet" type="text/css" />
<script src="../../js/tablesorter/jquery.tablesorter.js" type="text/javascript"></script>
<script src="../../js/jquery.highlight.js" type="text/javascript"></script>
<asp:Panel ID="pnlMain" runat="server" CssClass="formPanel">
    <fieldset>
        <legend>Calculate VAT on sale</legend>
        <div class="clearfix">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="LoadVat"
                EnableClientScript="true" DisplayMode="BulletList" ForeColor="Red" />
            <p class="formControl clearfix inputText">
                <label for="calStartDate">
                    <span class="required">*</span> Start date
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="LoadVat"
                        Text="*" runat="server" ErrorMessage="Please select the start date." ControlToValidate="txtStartDate" />
                </label>
                <asp:TextBox ID="txtStartDate" runat="server">
                </asp:TextBox>
                <asp:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" Format="dd/MMM/yyyy hh:mm:ss"
                    TargetControlID="txtStartDate" />
            </p>
            <p class="formControl clearfix inputText">
                <label for="calEndDate">
                    <span class="required">*</span> End date
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="LoadVat"
                        Text="*" runat="server" ErrorMessage="Please select the end date." ControlToValidate="txtEndDate" />
                </label>
                <asp:TextBox ID="txtEndDate" runat="server">
                </asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate"
                    Format="dd/MMM/yyyy hh:mm:ss" />
            </p>
            <p class="formControl clearfix inputText">
                <label for="calEndDate">
                    <span class="required">*</span> VAT Percentage
                </label>
                <asp:TextBox ID="txtVATPercentage" runat="server" Text="0.00"></asp:TextBox>
            </p>
            <div class="formControl clearfix right">
                <asp:Button ID="btnLoadVatReport" runat="server" Text="Load" CssClass="submit" OnClick="btnLoadVatReport_Click"
                    ValidationGroup="LoadVat" CausesValidation="true" />
            </div>
        </div>
        <fieldset>
            <legend>Results</legend>
            <div class="clearfix">
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        Total rows
                    </label>
                    <asp:Label ID="lblRecordCount" runat="server" Text="0"></asp:Label>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        Total sold items
                    </label>
                    <asp:Label ID="lblTotalItemSold" runat="server" Text='0'></asp:Label>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        Sale price
                    </label>
                    <asp:Label ID="lblTotalPrice" runat="server" Text='0'></asp:Label>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        Amazon fee
                    </label>
                    <asp:Label ID="lblTotalFee" runat="server" Text='0'></asp:Label>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        Total amount
                    </label>
                    <asp:Label ID="lblTotalAmt" runat="server" Text='0'></asp:Label>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        VAT on net total amount
                    </label>
                    <asp:Label ID="lblTotalVAT" runat="server" Text='0'></asp:Label>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        Total purchased cost
                    </label>
                    <asp:Label ID="lblTotalPurchasedCost" runat="server" Text='0'></asp:Label>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        Net Amount
                    </label>
                    <asp:Label ID="lblTotalNetAmt" runat="server" Text='0'></asp:Label>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        Total item reclaim
                    </label>
                    <asp:Label ID="lblTotalItemReclaim" runat="server" Text='0'></asp:Label>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        Paid VAT to HM Revenue
                    </label>
                    <asp:Label ID="lblPaidVatHMRevenue" runat="server" Text='0'></asp:Label>
                </p>
                <p class="formControl clearfix inputText">
                    <label for="calStartDate">
                        Reclaim-VAT amount
                    </label>
                    <asp:Label ID="lblReclaimVAT" runat="server" Text='0'></asp:Label>
                </p>
                <div class="formControl clearfix right">
                    <asp:Button ID="btnSaveVatCalc" runat="server" Text="Save VAT Calc" CssClass="submit"
                        OnClick="btnSaveVatCalc_Click" />
                </div>
            </div>
            <asp:ListView ID="lstVAT" runat="server" OnItemDataBound="lstVAT_ItemDataBound">
                <LayoutTemplate>
                    <table id="tblItemCollection" class="tablesorter">
                        <thead>
                            <tr>
                                <th>
                                    Settlement ID
                                </th>
                                <th>
                                    Transaction Type
                                </th>
                                <th>
                                    Purchase Date
                                </th>
                                <th>
                                    Order ID
                                </th>
                                <th>
                                    Sale Price
                                </th>
                                <th>
                                    Amazon Fee
                                </th>
                                <th>
                                    Total Amount
                                </th>
                                <th>
                                    VAT Amt
                                </th>
                                <th>
                                    Purchased Cost
                                </th>
                                <th>
                                    Net Amount
                                </th>                                    
                                <th>
                                    Reclaim VAT
                                </th>
                                <th>
                                    Fulfillment By
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr class="even">
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, ("Settlementid"))%>
                        </td>
                        <td>
                            <asp:Label ID="lblTransactionType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("Transactiontype"))%>'></asp:Label>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, ("Purchaseddate"))%>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, ("Orderid"))%>
                        </td>
                        <td>
                            <asp:Label ID="lblItemSalePrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("Saleprice"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemFee" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("Amazonfee"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemAmt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("TotalAmount"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemVAT" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("VatAmt"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemPurchasedCost" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("PurchasedCost"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemNetAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("NetAmount"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReclaimVAT" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("ReclaimVatAmt"))%>'></asp:Label>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, ("Fullfilmentby"))%>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="odd">
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, ("Settlementid"))%>
                        </td>
                        <td>
                            <asp:Label ID="lblTransactionType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("Transactiontype"))%>'></asp:Label>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, ("Purchaseddate"))%>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, ("Orderid"))%>
                        </td>
                        <td>
                            <asp:Label ID="lblItemSalePrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("Saleprice"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemFee" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("Amazonfee"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemAmt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("TotalAmount"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemVAT" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("VatAmt"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemPurchasedCost" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("PurchasedCost"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblItemNetAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("NetAmount"))%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReclaimVAT" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, ("ReclaimVatAmt"))%>'></asp:Label>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, ("Fullfilmentby"))%>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:ListView>
        </fieldset>
    </fieldset>
</asp:Panel>
