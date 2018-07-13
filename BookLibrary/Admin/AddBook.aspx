<%@ Page Title="Add Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="BookLibrary.Admin.AddBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <div class="form-horizontal">
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ISBN" CssClass="col-md-2 control-label">ISBN</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ISBN" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ISBN" CssClass="text-danger" ErrorMessage="The ISBN field is required." Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="BookTitle" CssClass="col-md-2 control-label">Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="BookTitle" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="BookTitle" CssClass="text-danger" ErrorMessage="The Title field is required." Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Category" CssClass="col-md-2 control-label">Category</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Category" runat="server" CssClass="form-control" ItemType="BookLibrary.Models.BookCategory" SelectMethod="GetBookCategories" AppendDataBoundItems="true" DataTextField="BookCategoryName" DataValueField="BookCategoryID">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Author" CssClass="col-md-2 control-label">Author</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Author" runat="server" CssClass="form-control" ItemType="BookLibrary.Models.Author" SelectMethod="GetAuthors" AppendDataBoundItems="true" DataTextField="AuthorName" DataValueField="AuthorID">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Publisher" CssClass="col-md-2 control-label">Publisher</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Publisher" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Publisher" CssClass="text-danger" ErrorMessage="The Publisher field is required." Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PublicationYear" CssClass="col-md-2 control-label">Publication Year</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PublicationYear" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PublicationYear" CssClass="text-danger" ErrorMessage="The Publication Year field is required." Display="Dynamic" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="PublicationYear" CssClass="text-danger" ValidationExpression="^[12][0-9]{3}$" Display="Dynamic" ErrorMessage="Please enter a valid publication year." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Price" CssClass="col-md-2 control-label">Price</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Price" CssClass="form-control" />
                <asp:RegularExpressionValidator runat="server" Text="* Must be a valid price without." ControlToValidate="Price" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="SaveBookButton_Click" Text="Save" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
