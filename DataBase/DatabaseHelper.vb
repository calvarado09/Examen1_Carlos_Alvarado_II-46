Imports System.Data.SqlClient

Public Class DatabaseHelper
    Private ReadOnly connectionString As String =
        ConfigurationManager.ConnectionStrings("Conexion_Clientes").ConnectionString

    Public Function AgregarCliente(cliente As Cliente) As String
        Try
            Dim fechaDate As Date = Date.Now
            Dim query As String = "INSERT INTO CLIENTES (Nombre, Apellidos, Email, Telefono) " &
                            "VALUES (@Nombre, @Apellidos, @Email, @Telefono)"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", cliente.Nombre),
                New SqlParameter("@Apellidos", cliente.Apellidos),
                New SqlParameter("@Email", cliente.Email),
                New SqlParameter("@Telefono", cliente.Telefono)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Cliente agregado correctamente."
        Catch ex As FormatException
            Return "Error: Formato de datos incorrecto. " & ex.Message
        Catch ex As Exception
            Return "Error al agregar el cliente: " & ex.Message
        End Try

    End Function

    Public Function EliminarCliente(id As Integer) As String
        Try
            Dim query As String = "DELETE FROM CLIENTES WHERE ClienteId = @id "
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@id", id)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        Return "No se encontró el cliente con el ID especificado."
                    End If
                End Using
            End Using
            Return "Cliente eliminado correctamente."
        Catch ex As Exception
            Return "Error al eliminar el cliente: " & ex.Message
        End Try
    End Function

    Public Function ActualizarCliente(id As Integer, cliente As Cliente) As String
        Try
            Dim query As String = "UPDATE CLIENTES SET Nombre = @Nombre, Apellidos = @Apellidos, Email = @Email, Telefono = @Telefono WHERE ClienteId = @id"
            Dim parameters As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", cliente.Nombre),
                New SqlParameter("@Apellidos", cliente.Apellidos),
                New SqlParameter("@Email", cliente.Email),
                New SqlParameter("@Telefono", cliente.Telefono),
                New SqlParameter("@id", id)
            }
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddRange(parameters.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            Return "Cliente actualizado correctamente."
        Catch ex As Exception
            Return "Error al actualizar el Cliente: " & ex.Message
        End Try
    End Function

End Class
