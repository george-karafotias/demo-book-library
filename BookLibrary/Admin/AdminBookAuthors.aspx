<%@ Page Title="Authors" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminBookAuthors.aspx.cs" Inherits="BookLibrary.Admin.AdminBookAuthors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <div>
        <div>
            <asp:Button runat="server" OnClick="AddAuthorButton_Click" Text="Add Author" CssClass="btn btn-default"></asp:Button>
            <asp:TextBox runat="server" ID="SearchText" CssClass="form-control" style="display:inline" placeholder="Search..." />
            <asp:Button runat="server" OnClick="SearchBtn_Click" Text="Search" />
            <asp:Button runat="server" OnClick="ClearBtn_Click" Text="All Authors" />
        </div>

        <asp:GridView runat="server" ID="BookAuthors" ItemType="BookLibrary.Models.Author" AutoGenerateColumns="false" AllowSorting="false" AllowPaging="true" PageSize="10" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="AuthorName" HeaderText="Name" SortExpression="AuthorName" />
                <asp:TemplateField HeaderText="Functions">
                    <ItemTemplate>
                        <asp:Button runat="server" ID="EditAuthorBtn" OnClick="EditAuthorBtn_Click" CommandArgument="<%# BindItem.AuthorID %>" Text="Edit" CssClass="btn btn-default" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
