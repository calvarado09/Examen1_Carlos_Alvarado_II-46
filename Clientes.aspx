<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Clientes.aspx.vb" Inherits="Examen1_Carlos_Alvarado_II_46.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="Gv_Clientes" runat="server" AllowPaging="true"
        OnSelectedIndexChanged="Gv_Clientes_SelectedIndexChanged"
        OnRowDeleting="Gv_Clientes_RowDeleting"
        AllowSorting="true" AutoGenerateColumns="False" DataKeyNames="ClienteId"
        DataSourceID="SqlDataSource" Width="794px">
        <Columns>
            <asp:BoundField DataField="ClienteId" HeaderText="ClienteId" InsertVisible="False" ReadOnly="True" SortExpression="ClienteId" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
        </Columns>
    </asp:GridView>


    <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Conexion_Clientes %>" SelectCommand="SELECT * FROM [CLIENTES]"></asp:SqlDataSource>


</asp:Content>
