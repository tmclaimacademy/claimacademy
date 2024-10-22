<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="DemoApplication.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Registration</h2>
            <asp:Label ID="UserNameLabel" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID ="Username" runat="server"></asp:TextBox>
            <p></p>
            <asp:Label ID="PasswordLabel" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            <p></p>
            <asp:Label ID="RepeatPasswordLabel" runat="server" Text="Repeat Password: "></asp:Label>
            <asp:TextBox ID="RepeatPassword" runat="server" TextMode="Password"></asp:TextBox>
            <p></p>
            <asp:Button ID="Register" runat="server" Text="Register" OnClick="Register_Click" BackColor="Blue" ForeColor="White" />
            <p></p>
            <asp:Label ID="RegistrationResult" runat="server" Text=""></asp:Label>
            <asp:BulletedList ID="PasswordErrors" runat="server"></asp:BulletedList>
        </div>
    </form>
</body>
</html>
