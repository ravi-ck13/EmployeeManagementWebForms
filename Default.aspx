<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeApp.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Employee List</h2>
        <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
            OnRowEditing="gvEmployees_RowEditing"
            OnRowUpdating="gvEmployees_RowUpdating"
            OnRowCancelingEdit="gvEmployees_RowCancelingEdit"
            OnRowDeleting="gvEmployees_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <h2>Add Employee</h2>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
        Department: <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox><br />
        Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnAdd" runat="server" Text="Add Employee" OnClick="btnAdd_Click" />
    </form>
</body>
</html>
