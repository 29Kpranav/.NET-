﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Session.WebForm1" %>  
  
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head id="Head1" runat="server">  
    <title></title>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
        User Name:-<asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>  
        <input id="Text1" type="text" /><br />  
        <br />  
        Password:-<asp:TextBox ID="tbpwd" runat="server"></asp:TextBox>  
        <br />  
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />  
        <asp:Button ID="Button2" runat="server" Text="Button" />
    </div>  
        <p>
            &nbsp;</p>
    </form>  
    <p>
        &nbsp;</p>
</body>  
</html> 
<!---->