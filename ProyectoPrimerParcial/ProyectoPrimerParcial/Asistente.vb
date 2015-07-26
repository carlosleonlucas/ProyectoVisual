Public Class Asistente
    Inherits Usuario

    Sub New(tipoUsuario As String, id As String, nombre As String, usuario As String, clave As String)

        MyBase.New(tipoUsuario, id, nombre, usuario, clave)
    End Sub
End Class
