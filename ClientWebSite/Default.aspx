﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">File Download</asp:LinkButton>
        <br />
        <br />
    </div>
    <asp:FileUpload ID="FileUpload1" runat="server" Width="325px" />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Upload File" />
    <br />
    <br />
    <br />
    <br />
    
    </form>
</body>
</html>
