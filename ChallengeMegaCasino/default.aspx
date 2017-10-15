<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ChallengeMegaCasino._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 57%;
        }
        .auto-style3 {
            height: 167px;
            width: 153px;
        }
        .auto-style4 {
            height: 167px;
            width: 156px;
        }
        .auto-style5 {
            height: 167px;
            width: 96px;
        }
        .auto-style6 {
            width: 528px;
        }
    </style>
</head>
<body style="width: 515px">
    <form id="form1" runat="server" class="auto-style6">
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Cherry.png" Width="174px" />
                </td>
                <td class="auto-style4">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Orange.png" />
                </td>
                <td class="auto-style5">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Seven.png" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        You Bet:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnLever" runat="server" Text="Pull The Lever!" OnClick="btnLever_Click" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="moneyLabel" runat="server"></asp:Label>
    </form>
    <p>
        &nbsp;</p>
    <p>
        1 Cherry - x2 Your Bet</p>
    <p>
        2 Cherries - x3 Your Bet</p>
    <p>
        3 Cherries - x4 Your Bet</p>
    <p>
        3 7&#39;s -- Jackpot!&nbsp; -- 100x Your Bet</p>
    <p>
        HOWEVER...if there&#39;s even one BAR you win nothing</p>
</body>
</html>
