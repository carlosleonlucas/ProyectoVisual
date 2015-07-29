Public Class Platillo
    Public Shared ultimaID As Integer

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

    Private _restaurante As Restaurante
    Public Property Restaurante() As Restaurante
        Get
            Return _restaurante
        End Get
        Set(ByVal value As Restaurante)
            _restaurante = value
        End Set
    End Property

    Private _temperatura As String
    Public Property Temperatura() As String
        Get
            Return _temperatura
        End Get
        Set(ByVal value As String)
            _temperatura = value
        End Set
    End Property

    Private _tipo As String
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _categoria As Categoria
    Public Property Categoria() As Categoria
        Get
            Return _categoria
        End Get
        Set(ByVal value As Categoria)
            _categoria = value
        End Set
    End Property

    Public Sub New(id As String, nombre As String, restaurante As Restaurante, temperatura As String, tipo As String, descripcion As String, categoria As Categoria)
        Me._id = id
        ultimaID = Integer.Parse(id)
        Me._nombre = nombre
        Me._restaurante = restaurante
        Me._temperatura = temperatura
        Me._tipo = tipo
        Me._descripcion = descripcion
        Me._categoria = categoria
    End Sub

    Public Sub New(nombre As String, restaurante As Restaurante, temperatura As String, tipo As String, descripcion As String, categoria As Categoria)
        Me._id = (ultimaID + 1).ToString
        Me._nombre = nombre
        Me._restaurante = restaurante
        Me._temperatura = temperatura
        Me._tipo = tipo
        Me._descripcion = descripcion
        Me._categoria = categoria
    End Sub

End Class
