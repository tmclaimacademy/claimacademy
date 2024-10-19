<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleWebFormsApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Web Forms App</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Welcome to Simple Web Forms App</h2>
            <asp:Label ID="LabelMessage" runat="server" Text="Click the button to see a message."></asp:Label><br /><br />
            <asp:Button ID="ButtonClickMe" runat="server" Text="Click Me!" OnClick="ButtonClickMe_Click" />
        </div>
    </form>
</body>
</html>
