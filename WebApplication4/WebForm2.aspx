<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication4.WebForm2" %>

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
                    <td>STUDENT DETAILS :</td>
                    <td>&nbsp;</td>
                </tr> 
                 <tr>   
                    <td>Student Id :
                        <asp:TextBox ID="txtStudid" runat="server"></asp:TextBox></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Student Name :
                        <asp:TextBox ID="txtStudname" runat="server"></asp:TextBox></td>                    
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Marks :
                        <asp:TextBox ID="txtMarks" runat="server"></asp:TextBox></td>
                    <td>&nbsp;</td>                    
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="bnSubmit" runat="server" Text="Create" OnClick="bnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search Student" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                
            </table>
        </div>
    </form>
</body>
</html>
