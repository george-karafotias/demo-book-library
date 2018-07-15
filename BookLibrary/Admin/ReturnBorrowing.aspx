<%@ Page Title="Return Borrowing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReturnBorrowing.aspx.cs" Inherits="BookLibrary.Admin.ReturnBorrowing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>

    <div class="form-horizontal">
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Member" CssClass="col-md-2 control-label">Member</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Member" CssClass="form-control" Enabled="false" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Book" CssClass="col-md-2 control-label">Book</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Book" CssClass="form-control" Enabled="false" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FromDate" CssClass="col-md-2 control-label">Borrowing Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FromDate" CssClass="form-control" Enabled="false" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ToDate" CssClass="col-md-2 control-label">Return Date</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ToDate" CssClass="form-control" placeholder="MM/dd/yyyy" />
                <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="ToDate" ErrorMessage="Please Enter a valid return date in the format (mm/dd/yyyy)." ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="ReturnBorrowingButton_Click" Text="Save" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
