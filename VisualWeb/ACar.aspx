<%@ Page Title="" Language="C#" MasterPageFile="~/Car.master" AutoEventWireup="true" CodeFile="ACar.aspx.cs" Inherits="ACar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    Car ID&nbsp;&nbsp;
    <asp:TextBox ID="txtCarID" runat="server"></asp:TextBox>
    <br />
    <br />
    Manufacturer&nbsp;
    <asp:TextBox ID="txtManufacturer" runat="server"></asp:TextBox>
    <br />
    <br />
    Model&nbsp;&nbsp;
    <asp:TextBox ID="txtModel" runat="server"></asp:TextBox>
    <br />
    <br />
    Color&nbsp;&nbsp;
    <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
    <br />
    <br />
    Number Of Doors&nbsp;&nbsp;
    <asp:DropDownList ID="ddlNoOfDoors" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    Registration Date&nbsp;
    <asp:TextBox ID="txtRegistrationDate" runat="server"></asp:TextBox>
    <br />
    <br />
    Four Wheel Drive&nbsp;
    <asp:CheckBox ID="chkFourWheels" runat="server" Text="Four Wheels" />
    <br />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnOK" runat="server" Text="OK" />
&nbsp;
    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
    <p>
    </p>
</asp:Content>

