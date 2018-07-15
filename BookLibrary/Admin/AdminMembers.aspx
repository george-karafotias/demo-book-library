<%@ Page Title="Members" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminMembers.aspx.cs" Inherits="BookLibrary.Admin.AdminMembers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <div>
        <div>
            <asp:Button runat="server" ID="AddMemberBtn" OnClick="AddMemberBtn_Click" Text="Add Member" CssClass="btn btn-default"></asp:Button>
            <asp:TextBox runat="server" ID="SearchText" CssClass="form-control" onkeydown="return (event.keyCode!=13)" style="display:inline" placeholder="Search..." />
            <asp:Button runat="server" OnClick="SearchBtn_Click" Text="Search" />
            <asp:Button runat="server" OnClick="ClearBtn_Click" Text="All Members" />
        </div>

        <asp:GridView runat="server" ID="Members" ItemType="BookLibrary.Models.Member" AllowSorting="true" AllowPaging="true" SelectMethod="Members_GetData" DataKeyNames="MemberID" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="Name" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                <asp:BoundField DataField="IdentityID" HeaderText="Identity" SortExpression="IdentityID" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:TemplateField HeaderText="Functions">
                    <ItemTemplate>
                        <asp:Button runat="server" ID="EditMemberBtn" OnClick="EditMemberButton_Click" CommandArgument="<%# BindItem.MemberID %>" Text="Edit" CssClass="btn btn-default"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
