<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaAuto.aspx.cs" Inherits="WebTransportes.VistaAuto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Marca"></asp:Label>
            <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Modelo"></asp:Label>
            <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Matrícula"></asp:Label>
            <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Precio"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Id"></asp:Label>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Buscar por Marca"></asp:Label>
            <asp:DropDownList ID="ddlBuscarPorMarca" runat="server" OnSelectedIndexChanged="ddlBuscarPorMarca_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <br />
            <asp:GridView ID="gridAutos" runat="server"></asp:GridView>
            
        </div>
    </form>
</body>
</html>
