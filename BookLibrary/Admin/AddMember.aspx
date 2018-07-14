<%@ Page Title="Add Member" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMember.aspx.cs" Inherits="BookLibrary.Admin.AddMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>

    <div class="form-horizontal">
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="FirstName" ValidationExpression = "^[\s\S]{2,}$" CssClass="text-danger" ErrorMessage="The First Name field requires at least 2 characters." Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="LastName" ValidationExpression = "^[\s\S]{3,}$" CssClass="text-danger" ErrorMessage="The Last Name field requires at least 3 characters." Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="IdentityID" CssClass="col-md-2 control-label">Identity</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="IdentityID" CssClass="form-control" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="IdentityID" ValidationExpression = "^[\s\S]{5,}$" CssClass="text-danger" ErrorMessage="The Identity field requires at least 5 characters." Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="text-danger" ErrorMessage="Please enter a valid email address." Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="SaveMemberButton_Click" Text="Save" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
