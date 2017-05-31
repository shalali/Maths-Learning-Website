<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="SubsystemB.HomPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="StyleSheet1.css" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400" rel="stylesheet">
</head>
<body><div class="wrapper">
            <div class="header">
                <span>Learn-On-Line</span><br />
                <span class="page-heading">Login</span>
                </div>
            <div class="content">
    <form id="form1" runat="server" autocomplete="off">

    <div>
    
        <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
    
    </div>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <br />
        Password<br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <p>
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
        </p>
        <p>
            <asp:Label ID="lblInvalidCredentials" runat="server" Text="Invalid username or password" Visible="False" ForeColor="#CC3300"></asp:Label>
        </p>
    </form>
</div>
            <div class="footer">
                <div class="copyright">
                    COPYRIGHT © 2016 Learn-On-Line
                </div>
            </div>
        </div>
</body>
</html>
