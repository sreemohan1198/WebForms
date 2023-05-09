<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td>DeptNumber:</td>
                    <td>
                        <asp:TextBox ID="txtDeptNo" runat="server"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>DeptName:</td>
                    <td>
                        <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Location</td>
                    <td>
                        <asp:TextBox ID="txtDeptLoc" runat="server"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
               <tr>
                   <td>
                       <asp:Button ID="btnInsert" runat="server" Text="Add Department" OnClick="btnInsert_Click" />
                   </td>
               </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search Details" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update Details" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete Details" OnClick="btnDelete_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
