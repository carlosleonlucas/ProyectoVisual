Public Class Usuario
    Private _tipoUsuario As String
    Public Property tipUsu() As String
        Get
            Return _tipoUsuario
        End Get
        Set(ByVal value As String)
            _tipoUsuario = value
        End Set
    End Property


    Private _id As String
    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Private _clave As String
    Public Property Clave() As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property







    Public Sub New(tipoUsuario As String, id As String, nombre As String, usuario As String, clave As String)
        Me.tipUsu = tipoUsuario
        Me._id = id
        Me._nombre = nombre
        Me._usuario = usuario
        Me._clave = clave
    End Sub

    Public Sub New()

    End Sub

End Class
