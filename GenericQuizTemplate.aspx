<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenericQuizTemplate.aspx.cs" Inherits="SubsystemB.GenericQuizTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="StyleSheet1.css" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400" rel="stylesheet"/>
</head>
    <div class="wrapper">
            <div class="header">
                <span>Learn-On-Line</span><br />
                <span class="page-heading">Quiz&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </span>&nbsp;

                <br />
                <span class="page-heading">
                
        <asp:Label ID="lblPercentage" runat="server" Font-Bold="True" Font-Underline="False" Font-Size="X-Large" ForeColor="#0033CC"></asp:Label>
                
                </span>
            </div>
        
            <div class="content">
<body style="height: 178px">
    <form id="form1" runat="server" autocomplete="off">
    <asp:LinkButton ID="lnkBtnHome" runat="server" OnClick="lnkBtnHome_Click">Home</asp:LinkButton>
                
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                    <asp:LinkButton ID="lnkBtnSignOut" runat="server" PostBackUrl="~/HomePage.aspx">Sign Out</asp:LinkButton>
        <div>
    
        &nbsp;<br />
        <asp:Panel ID="pnlMain" runat="server" Height="399px">
            <asp:Button ID="btnTestFinished" runat="server" OnClick="btnTestFinished_Click" Text="Finished" />
            <br />
            <asp:Label ID="lblAgeGroup" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblTopic" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label11" runat="server" Font-Italic="True" Text="Difficulty: "></asp:Label>
            <asp:Label ID="lblDifficulty" runat="server" Font-Italic="True"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQuestionCount" runat="server" Font-Bold="False" Font-Underline="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblQuestion" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="pnlSingleAns" runat="server" Height="36px" style="margin-top: 0px" Width="479px">
                <asp:TextBox ID="txtSingleAns" runat="server" Font-Bold="True" Font-Italic="True" style="margin-top: 0px" ToolTip="Fill in the correct answer"></asp:TextBox>
            </asp:Panel>
            <br />
            <asp:Panel ID="pnlMutipleChoice" runat="server" Height="135px" Width="331px">
                <asp:Label ID="Label8" runat="server" Font-Italic="True" Text="Tick the right answer(s)"></asp:Label>
                <br />
                <asp:CheckBox ID="chkA" runat="server" Text="A" />
                <asp:TextBox ID="txtA" runat="server" Enabled="False" style="margin-bottom: 0px"></asp:TextBox>
                <br />
                <asp:CheckBox ID="chkB" runat="server" Text="B" />
                <asp:TextBox ID="txtB" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <asp:CheckBox ID="chkC" runat="server" Text="C" />
                <asp:TextBox ID="txtC" runat="server" Enabled="False"></asp:TextBox>
                <br />
                <asp:CheckBox ID="chkD" runat="server" Text="D" />
                <asp:TextBox ID="txtD" runat="server" Enabled="False"></asp:TextBox>
            </asp:Panel>
            <asp:Button ID="btnNextQuestion" runat="server" OnClick="btnNextQuestion_Click1" Text="Next Question" />
        </asp:Panel>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
        <br />
        
        <br />
        
    <asp:Panel ID="pnlS" runat="server">
        <br />
        <asp:Label ID="lblMarksAdded" runat="server" ForeColor="#009933" Text="Quiz Completed. Your marks have been saved." Visible="False"></asp:Label>
        <br />
    </asp:Panel>
    </div>
    </form>
   
            <div class="footer">
                <div class="copyright">
                    COPYRIGHT © 2016 Learn-On-Line
                </div>
            </div>
        </div>
    </div>
</body>
</html>
