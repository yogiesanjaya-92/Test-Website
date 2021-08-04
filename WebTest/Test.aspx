<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WebTest.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Insert Data" OnClick="Button1_Click" BackColor="#0066FF" />
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel2" runat="server">
                <asp:TextBox ID="TextBox1" runat="server" placeholder="Keywords" Width="300px"></asp:TextBox>
                <asp:Button ID="Button2" runat="server" Text="Search Data" OnClick="Button2_Click" BackColor="#0066FF" />
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel3" runat="server">
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
