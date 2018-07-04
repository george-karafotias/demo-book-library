<%@ Page Title="Book Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookCategories.aspx.cs" Inherits="BookLibrary.BookCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <div>
        <asp:GridView runat="server" ItemType="BookLibrary.Models.BookCategory" SelectMethod="GetBookCategories" CssClass="table table-striped table-bordered">
        </asp:GridView>
    </div>
</asp:Content>
