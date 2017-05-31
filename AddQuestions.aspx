<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQuestions.aspx.cs" Inherits="SubsystemB.AddQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="StyleSheet1.css" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400" rel="stylesheet">
</head>
<body>
    <div class="wrapper">
            <div class="header">
                <span>Learn-On-Line</span><br />
                <span class="page-heading">AddQuestions&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                </span>&nbsp;</div>
            <div class="content">
    <form id="form1" runat="server" autocomplete="off">
                    <asp:LinkButton ID="lnkBtnSignOut" runat="server" PostBackUrl="~/HomePage.aspx">Sign Out</asp:LinkButton>

    <div style="height: 904px">
    
        <asp:Label ID="Label2" runat="server" Text="Topic"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:TextBox ID="txtTopic" runat="server" Height="16px" Width="138px" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter Question"></asp:Label>
        <br />
        <asp:TextBox ID="txtQuestion" runat="server" Height="53px" Width="408px"></asp:TextBox>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Difficulty of Question" ToolTip="How hard the question is "></asp:Label>
        <br />
        <asp:DropDownList ID="ddlDifficulty" runat="server">
            <asp:ListItem Value="1">Easy</asp:ListItem>
            <asp:ListItem Value="2">Medium</asp:ListItem>
            <asp:ListItem Value="3">Hard</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Age Group of Quiz" ToolTip="Select one age group "></asp:Label>
        <br />
        <asp:DropDownList ID="ddlQuizLevel" runat="server">
            <asp:ListItem Value="1">6-10yrs</asp:ListItem>
            <asp:ListItem Value="2">11-13yrs</asp:ListItem>
            <asp:ListItem Value="3">14-16yrs</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label3" runat="server" Text="Type of Question"></asp:Label>
        <br />
        <asp:Label ID="Label9" runat="server" Font-Italic="True">Select one out of the two types of questions</asp:Label>
        <br />
        <asp:DropDownList ID="ddlQuestionType" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">Single Answer Input</asp:ListItem>
            <asp:ListItem Value="2">Multiple Choice</asp:ListItem>
        </asp:DropDownList>
        <asp:Panel ID="pnlSingleAns" runat="server" Height="36px" Width="309px">
            <asp:Label ID="Label10" runat="server" Text="Fill in the correct answer" Font-Italic="True"></asp:Label>
            <asp:TextBox ID="txtSingleAns" runat="server" style="margin-top: 0px"></asp:TextBox>
        </asp:Panel>
        <br />
        <asp:Panel ID="pnlMutipleChoice" runat="server" Height="135px" Width="331px">
            <asp:Label ID="Label8" runat="server" Font-Italic="True" Text="Tick the right answer(s) and fill in the fields"></asp:Label>
            <br />
            <asp:CheckBox ID="chkA" runat="server" Text="A" />
            <asp:TextBox ID="txtA" runat="server" style="margin-bottom: 0px"></asp:TextBox>
            <br />
            <asp:CheckBox ID="chkB" runat="server" Text="B" />
            <asp:TextBox ID="txtB" runat="server"></asp:TextBox>
            <br />
            <asp:CheckBox ID="chkC" runat="server" Text="C" />
            <asp:TextBox ID="txtC" runat="server"></asp:TextBox>
            <br />
            <asp:CheckBox ID="chkD" runat="server" Text="D" />
            <asp:TextBox ID="txtD" runat="server"></asp:TextBox>
        </asp:Panel>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button ID="btnAddQuestion" runat="server" Text="Add Question" OnClick="btnAddQuestion_Click" />
        &nbsp;<br />
        <asp:Label ID="lblQuestionAddedConfirmation" runat="server" ForeColor="#009933" Text="Question has been added successfuly." Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="#FF3300" Text="Please fill in all the fields." Visible="False" Enabled="False"></asp:Label>
        <br />
&nbsp;<br />
        <br />
        <br />
        <br />
&nbsp;<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <br />
        <br />
        <br />
        <br />
        <br />
        <br />
            <br />
            <br />
            <br />
            <br />
        <br />
        <br />
        <br />
    
    </div>
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
