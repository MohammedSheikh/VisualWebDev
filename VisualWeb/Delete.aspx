<%@ Page Title="" Language="C#" MasterPageFile="~/Car.master" AutoEventWireup="true" CodeFile="Delete.aspx.cs" Inherits="Delete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    <asp:Label ID="lblMessage" runat="server" Text="Are you sure you want to delete this car??"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" />
&nbsp;
    <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" />
    <p>
    </p>
</asp:Content>

