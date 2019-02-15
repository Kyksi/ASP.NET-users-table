<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="users-table.aspx.cs" Inherits="ASP.NET_pages.users_table" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=0.6"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"/>
    <title>Users</title>
    <style>
        table{
            width: 94%;
            margin: 10px 3% 10px 3%;
            text-align: center;
        }
        input[type='text']{
            width: 250px;
            height: 30px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            padding-left: 10px;
        }
        tr:hover{
            background-color: lightgray;
            transition: 1s;
        }
        input[type='button'], input[type='submit']{
            width: 80px;
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a style="position: fixed; right: 29px;" href="https://nsemeniuk.000webhostapp.com/">Main page</a><br />
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" 
                 DataKeyNames="Id" 
                AutoGenerateColumns="False" 
                OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" EnableModelValidation="False" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField HeaderText="Surname" DataField="surname" />
                    <asp:BoundField HeaderText="Location" DataField="city" />
                    <asp:CommandField ButtonType="Button" ShowEditButton="True" ControlStyle-CssClass="btn btn-dark">
                        <ControlStyle CssClass="btn btn-dark"></ControlStyle>
                    </asp:CommandField>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger">
                        <ControlStyle CssClass="btn btn-danger"></ControlStyle>
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="LightGray" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
