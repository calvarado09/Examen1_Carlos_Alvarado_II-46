<%@ Page Title="Clientes" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="Examen1_Carlos_Alvarado_II_46.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="IdCliente" runat="server" />
    <div class="row mb-3">
        <div class="col-md-4">

            <div class="form-group mb-3">
                <label for="TxtNombre">Nombre: </label>
                <asp:TextBox ID="TxtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label for="TxtApellido">Apellidos: </label>
                <asp:TextBox ID="TxtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>


            <div class="form-group mb-3">
                <label for="txtEmail">Correo electrónico: </label>
                <asp:TextBox TextMode="Email" ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>


            <div class="form-group mb-3">
                <label for="txtTelefono">Número de telefono: </label>
                <asp:TextBox TextMode="Phone" ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>



        </div>
    </div>

    <div class="form-group mb-3">
        <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    </div>

    <div class="form-group mb-3">
        
    </div>

    <div>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>

    <asp:GridView ID="Gv_Clientes" runat="server" AllowPaging="true"
        OnSelectedIndexChanged="Gv_Clientes_SelectedIndexChanged"
        OnRowDeleting="Gv_Clientes_RowDeleting"
        AllowSorting="true" AutoGenerateColumns="False" DataKeyNames="ClienteId"
        DataSourceID="SqlDataSource" Width="794px">
        <Columns>
            <asp:CommandField ShowSelectButton="true" />
            <asp:BoundField DataField="ClienteId" HeaderText="ClienteId" InsertVisible="False" ReadOnly="True" SortExpression="ClienteId" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>


    <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion_Clientes %>" SelectCommand="SELECT * FROM [CLIENTES]"></asp:SqlDataSource>


</asp:Content>
