<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <asp:Label ID="UserNameLabel" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID ="Username" runat="server"></asp:TextBox>
            <p></p>
            <asp:Label ID="PasswordLabel" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            <p></p>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Login_Click" BackColor="Blue" ForeColor="White" />
            <asp:Label ID="LoginLabel" runat="server" ForeColor="Green"></asp:Label>
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
