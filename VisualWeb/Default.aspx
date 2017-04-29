<%@ Page Title="" Language="C#" MasterPageFile="~/Car.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Testing the default page</p>
    <p>
        <asp:ListBox ID="lstCars" runat="server" Height="225px" Width="601px"></asp:ListBox>
    </p>
    <p>
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblMessage" runat="server" Text="Please enter a color"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="btnApply" runat="server" Text="Apply" />
&nbsp;&nbsp;
        <asp:Button ID="btnDisplay" runat="server" Text="Display All" OnClick="btnDisplay_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
&nbsp;
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
&nbsp;
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
    </p>
</asp:Content>

