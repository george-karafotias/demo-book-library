<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminBookCategories.aspx.cs" Inherits="BookLibrary.Admin.AdminBookCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <div>
        <div>
            <asp:Button runat="server" ID="AddBookCategoryBtn" Text="Add Category" OnClick="AddBookCategoryBtn_Click" CssClass="btn btn-default" />
        </div>
        <asp:GridView runat="server" ID="BookCategories" ItemType="BookLibrary.Models.BookCategory" SelectMethod="GetBookCategories" AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="BookCategoryName" HeaderText="Name" SortExpression="BookCategoryName" />
                <asp:TemplateField HeaderText="Functions">
                    <ItemTemplate>
                        <asp:Button runat="server" ID="EditCategoryBtn" OnClick="EditCategoryBtn_Click" CommandArgument="<%# BindItem.BookCategoryID %>" Text="Edit" CssClass="btn btn-default" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
