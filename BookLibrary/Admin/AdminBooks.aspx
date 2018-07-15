<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminBooks.aspx.cs" Inherits="BookLibrary.Admin.AdminBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <div>
        <div>
            <asp:Button runat="server" OnClick="AddBookButton_Click" Text="Add Book" CssClass="btn btn-default"></asp:Button>
            <asp:Button runat="server" OnClick="AddBookCategoryButton_Click" Text="Add Category" CssClass="btn btn-default"></asp:Button>
            <asp:Button runat="server" OnClick="AddBookAuthorButton_Click" Text="Add Author" CssClass="btn btn-default"></asp:Button>
            <asp:TextBox runat="server" ID="SearchText" CssClass="form-control" onkeydown="return (event.keyCode!=13)" style="display:inline" placeholder="Search..." />
            <asp:Button runat="server" OnClick="SearchBtn_Click" Text="Search" />
            <asp:Button runat="server" OnClick="ClearBtn_Click" Text="All Books" />
        </div>
        
        <asp:GridView runat="server" ID="Books" ItemType="BookLibrary.Models.Book" AutoGenerateColumns="false" AllowSorting="true" OnSorting="theGrid_Sorting" AllowPaging="true" PageSize="5" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Category.BookCategoryName" HeaderText="Category" SortExpression="Category.BookCategoryName" />
                <asp:BoundField DataField="Author.AuthorName" HeaderText="Author" SortExpression="Author.AuthorName" />
                <asp:BoundField DataField="Publisher" HeaderText="Publisher" SortExpression="Publisher" />
                <asp:BoundField DataField="PublicationYear" HeaderText="PublicationYear" SortExpression="PublicationYear" />
                <asp:TemplateField HeaderText="Functions">
                    <ItemTemplate>
                        <asp:Button runat="server" ID="EditBookBtn" OnClick="EditBookButton_Click" CommandArgument="<%# BindItem.BookID %>" Text="Edit" CssClass="btn btn-default"></asp:Button>
                        <asp:Button runat="server" ID="DeleteBookBtn" OnClick="DeleteBookButton_Click" CommandArgument="<%# BindItem.BookID %>" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this book?');" CssClass="btn btn-default"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
