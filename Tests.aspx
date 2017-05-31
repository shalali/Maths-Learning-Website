<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tests.aspx.cs" Inherits="SubsystemB.Tests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="StyleSheet1.css" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Select an age group of interest for the test:</p>
        <p>
                <span class="page-heading">
            <asp:LinkButton ID="lnkBtnSignOut" runat="server" PostBackUrl="~/HomePage.aspx">Sign Out</asp:LinkButton>
            </span></p>
        <p>
            <asp:Button ID="btnBeginner" runat="server" Text="6-10" OnClick="btnBeginner_Click" style="height: 26px" />
        </p>
        <p>
            <asp:Button ID="btnIntermediate" runat="server" Text="11-13" OnClick="btnIntermediate_Click" style="height: 26px" />
        </p>
        <asp:Button ID="btnAdvanced" runat="server" OnClick="btnAdvanced_Click" Text="14-16" />
        <br />
        <br />
        <asp:Button ID="btnHallOfFame" runat="server" OnClick="btnHallOfFame_Click" Text="Hall Of Fame" />
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
