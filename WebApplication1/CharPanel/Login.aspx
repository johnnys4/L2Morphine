<%@ Page Title="" Language="C#" MasterPageFile="~/CharPanel/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="L2Morphine.CharPanel.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="loginpanel">
        <div style="padding-top:5%;">You can login with your game account!</div>
        <div class="username">
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label><br />
            <asp:TextBox ID="txtboxUsername" runat="server"></asp:TextBox>
        </div>
        <div class="password">
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label><br />
            <asp:TextBox ID="txtbotPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="loginbuttons">
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br /><br />
            <asp:Label ID="Label3" runat="server" CssClass=""></asp:Label>
            <br />
        </div>
        
    </div>


</asp:Content>
