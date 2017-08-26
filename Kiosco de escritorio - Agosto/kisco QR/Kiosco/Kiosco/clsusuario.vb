Public Class clsusuario
    Private m_rol As String
    Private m_nombre As String
    Private m_email As String
    Private m_rfc As String
    Private m_numempleado As String
    Private m_empresa As String
    Private m_pass As String

    Public Property rol() As String
        Get
            Return Me.m_rol
        End Get
        Set(ByVal value As String)
            Me.m_rol = value
        End Set
    End Property

    Public Property nombre() As String
        Get
            Return Me.m_nombre
        End Get
        Set(ByVal value As String)
            Me.m_nombre = value
        End Set
    End Property

    Public Property email() As String
        Get
            Return Me.m_email
        End Get
        Set(ByVal value As String)
            Me.m_email = value
        End Set
    End Property

    Public Property rfc() As String
        Get
            Return Me.m_rfc
        End Get
        Set(ByVal value As String)
            Me.m_rfc = value
        End Set
    End Property

    Public Property nempleado() As String
        Get
            Return Me.m_numempleado
        End Get
        Set(ByVal value As String)
            Me.m_numempleado = value
        End Set
    End Property

    Public Property empresa() As String
        Get
            Return Me.m_empresa
        End Get
        Set(ByVal value As String)
            Me.m_empresa = value
        End Set
    End Property

    Public Property pass() As String
        Get
            Return Me.m_pass
        End Get
        Set(ByVal value As String)
            Me.m_pass = value
        End Set
    End Property

End Class
