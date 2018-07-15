<%@ Page Title="Borrowings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminBorrowings.aspx.cs" Inherits="BookLibrary.Admin.AdminBorrowings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>

    <asp:GridView runat="server" ID="Borrowings" ItemType="BookLibrary.Models.Borrowing" AllowSorting="true" AllowPaging="true" SelectMethod="Borrowings_GetData" OnRowDataBound="Borrowings_RowDataBound" AutoGenerateColumns="false" DataKeyNames="BorrowingID" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="Member.DisplayName" HeaderText="Member" />
            <asp:BoundField DataField="Book.DisplayName" HeaderText="Book" />
            <asp:BoundField DataField="From" HeaderText="Borrowing Date" SortExpression="From" DataFormatString="{0:MM/dd/yyyy}" htmlencode="false" />
            <asp:BoundField DataField="To" HeaderText="Return Date" SortExpression="From" DataFormatString="{0:MM/dd/yyyy}" htmlencode="false" />
            <asp:TemplateField HeaderText="Functions">
                <ItemTemplate>
                    <asp:Button runat="server" ID="ReturnBtn" Text="Return" OnClick="ReturnBtn_Click" CommandArgument="<%# BindItem.BorrowingID %>" Visible="false" CssClass="btn btn-default" />
                    <asp:Button runat="server" ID="DeleteBtn" Text="Delete" OnClick="DeleteBtn_Click" CommandArgument="<%# BindItem.BorrowingID %>" OnClientClick="return confirm('Are you sure you want to delete this borrowing?');" CssClass="btn btn-default" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
