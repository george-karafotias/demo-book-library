<%@ Page Title="Add Borrowing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBorrowing.aspx.cs" Inherits="BookLibrary.Admin.AddBorrowing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>

    <asp:PlaceHolder runat="server" ID="CanAddBorrowing" Visible="true">
        <div class="form-horizontal">
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            <div class="form-group">
                <asp:Label runat="server" Visible="false" AssociatedControlID="MemberList" ID="MemberListLabel" CssClass="col-md-2 control-label">Member</asp:Label>
                <asp:Label runat="server" Visible="false" AssociatedControlID="MemberTextBox" ID="MemberTextBoxLabel" CssClass="col-md-2 control-label">Member</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="MemberList" runat="server" Visible="false" CssClass="form-control" ItemType="BookLibrary.Models.Member" AppendDataBoundItems="true">
                    </asp:DropDownList>
                    <asp:TextBox ID="MemberTextBox" runat="server" Visible="false" Enabled="false" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Visible="false" AssociatedControlID="BookList" ID="BookListLabel" CssClass="col-md-2 control-label">Book</asp:Label>
                <asp:Label runat="server" Visible="false" AssociatedControlID="BookTextBox" ID="BookTextBoxLabel" CssClass="col-md-2 control-label">Book</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="BookList" runat="server" Visible="false" CssClass="form-control" ItemType="BookLibrary.Models.Book" AppendDataBoundItems="true">
                    </asp:DropDownList>
                    <asp:TextBox ID="BookTextBox" runat="server" Visible="false" Enabled="false" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="FromDate" CssClass="col-md-2 control-label">Borrowing Date</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="FromDate" CssClass="form-control" placeholder="mm/dd/yyyy" />
                    <asp:RegularExpressionValidator ID="dateValRegex" runat="server" ControlToValidate="FromDate" ErrorMessage="Please Enter a valid borrowing date in the format (mm/dd/yyyy)." ValidationExpression="^(0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])[- /.](19|20)\d\d$"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="SaveBorrowingButton_Click" Text="Save" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </asp:PlaceHolder>

    <asp:PlaceHolder ID="CannotAddBorrowing" runat="server" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="Literal1" Text="Sorry, no books available to borrow." />
        </p>
    </asp:PlaceHolder>
</asp:Content>
