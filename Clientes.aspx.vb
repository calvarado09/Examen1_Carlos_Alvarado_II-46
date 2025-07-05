Imports Microsoft.Ajax.Utilities

Public Class Clientes
    Inherits System.Web.UI.Page
    Dim dbHelper As New DatabaseHelper()

    Protected Sub LimpiarCampos() 'Creación de un método para limpiar los campos del formulario
        TxtNombre.Text = String.Empty 'Limpia el campo de nombre
        TxtApellido.Text = String.Empty 'Limpia el campo de apellidos
        txtEmail.Text = String.Empty 'Limpia el campo de email
        txtTelefono.Text = String.Empty 'Limpia el campo de teléfono
        IdCliente.Value = String.Empty 'Limpia el campo oculto de ID del cliente
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Gv_Clientes_SelectedIndexChanged(sender As Object, e As EventArgs) '' Evento que se dispara al seleccionar un cliente en el GridView
        Dim index As Integer = Gv_Clientes.SelectedIndex 'Obtiene el indice de la fila seleccionada en el GridView
        Dim iddelCliente As Integer = Convert.ToInt32(Gv_Clientes.SelectedDataKey.Value) 'Obtiene el ID del cliente seleccionado

        If index >= 0 Then ' Verifica que el índice sea válido
            Dim row = Gv_Clientes.Rows(index) ' Obtiene la fila seleccionada del GridView
            Dim cliente As New Cliente() With { ' Crea un nuevo objeto de la clase Cliente y asigna los valores de la fila seleccionada
                .Nombre = row.Cells(2).Text, ' Asigna el nombre del cliente desde la celda correspondiente
                .Apellidos = row.Cells(3).Text, ' Asigna los apellidos del cliente desde la celda correspondiente
                .Email = row.Cells(4).Text, ' Asigna el email del cliente desde la celda correspondiente
                .Telefono = row.Cells(5).Text ' Asigna el telefono del cliente desde la celda correspondiente
            }

            IdCliente.Value = row.Cells(1).Text ' Asigna el ID del cliente desde la celda correspondiente
            TxtNombre.Text = cliente.Nombre ' Asigna el nombre del cliente al campo de texto correspondiente
            TxtApellido.Text = cliente.Apellidos ' Asigna los apellidos del cliente al campo de texto correspondiente
            txtEmail.Text = cliente.Email ' Asigna el email del cliente al campo de texto correspondiente
            txtTelefono.Text = cliente.Telefono ' Asigna el telefono del cliente al campo de texto correspondiente
        End If

    End Sub

    Protected Sub Gv_Clientes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) 'Evento que se dispara al intentar eliminar un cliente del GridView
        Dim id As Integer = Convert.ToInt32(Gv_Clientes.DataKeys(e.RowIndex).Value) 'Obtiene el ID del cliente a eliminar desde las claves de datos del GridView
        Dim resultado As String = dbHelper.EliminarCliente(id) 'Llama al método EliminarCliente del DatabaseHelper para eliminar el cliente
        lblMensaje.Text = resultado '' Muestra el resultado de la operación en una etiqueta de mensaje
        e.Cancel = True ' Evita que se vuelva a enlazar el GridView
        Gv_Clientes.DataBind() ' Vuelve a enlazar el GridView para reflejar los cambios
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) 'Evento que se dispara al hacer clic en el botón de agregar o actualizar cliente
        'Validaciones de que los campos del formulario no estén vacíos
        If String.IsNullOrWhiteSpace(TxtNombre.Text) OrElse
            String.IsNullOrWhiteSpace(TxtApellido.Text) OrElse
            String.IsNullOrWhiteSpace(txtEmail.Text) OrElse
            String.IsNullOrWhiteSpace(txtTelefono.Text) Then

            'Mensaje de error si algún campo está vacío
            lblMensaje.Text = "Por favor, complete todos los campos antes de guardar."
            Exit Sub ' Sale del método si hay campos vacíos
        End If

        ' Crea un objeto cliente con los valores del formulario
        Dim cliente As New Cliente() With {
            .Nombre = TxtNombre.Text.Trim(), ' Elimina espacios en blanco al inicio y al final del nombre y asigna el valor al objeto cliente
            .Apellidos = TxtApellido.Text.Trim(), ' Elimina espacios en blanco al inicio y al final de los apellidos y asigna el valor al objeto cliente
            .Email = txtEmail.Text.Trim(), ' Elimina espacios en blanco al inicio y al final del email y asigna el valor al objeto cliente
            .Telefono = txtTelefono.Text.Trim() ' Elimina espacios en blanco al inicio y al final del teléfono y asigna el valor al objeto cliente
        }

        ' Verificar si es inserción o actualización
        If IdCliente.Value.IsNullOrWhiteSpace Then 'Comprueba si el campo IdCliente está vacío para determinar si es una inserción
            ' Insertar nuevo cliente
            Dim resultado As String = dbHelper.AgregarCliente(cliente) 'Llama al método AgregarCliente del DatabaseHelper para agregar un nuevo cliente
            lblMensaje.Text = resultado 'Muestra el resultado de la operación en una etiqueta de mensaje
            lblMensaje.Text = ""
        Else 'Si en el campo IdCliente hay un valor, significa que se está actualizando un cliente existente
            Dim resultado As String = dbHelper.ActualizarCliente(IdCliente.Value, cliente) 'Llama al método ActualizarCliente del DatabaseHelper para actualizar el cliente existente
            lblMensaje.Text = resultado 'Muestra el resultado de la operación en una etiqueta de mensaje
            IdCliente.Value = "" 'Limpia el campo IdCliente después de la actualización

        End If
        LimpiarCampos() 'LLama al metodo Limpiar Campos
        Gv_Clientes.DataBind() 'Vuelve a enlazar el GridView para reflejar los cambios
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
        LimpiarCampos() 'Llama al método LimpiarCampos para limpiar los campos del formulario
    End Sub
End Class