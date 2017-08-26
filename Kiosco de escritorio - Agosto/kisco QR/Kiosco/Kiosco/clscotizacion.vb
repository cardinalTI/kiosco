Public Class clscotizacion
    Private m_centro As String
    Private m_fecha_inicial As String
    Private m_fecha_timbrado As String
    Private m_numero_empleado As String
    Private m_certificado As String
    Private m_sin_certificado As String
    Private m_nombre_empleado As String
    Private m_rfc As String
    Private m_cfdi_timbrado As String

    Public Property nombre_empleado() As String
        Get
            Return Me.m_nombre_empleado
        End Get
        Set(ByVal value As String)
            Me.m_nombre_empleado = value
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

    Public Property cfdi_timbrado() As String
        Get
            Return Me.m_cfdi_timbrado
        End Get
        Set(ByVal value As String)
            Me.m_cfdi_timbrado = value
        End Set
    End Property



    Public Property centro() As String
        Get
            Return Me.m_centro
        End Get
        Set(ByVal value As String)
            Me.m_centro = value
        End Set
    End Property

    Public Property fecha_timbrado() As String
        Get
            Return Me.m_fecha_timbrado
        End Get
        Set(ByVal value As String)
            Me.m_fecha_timbrado = value
        End Set
    End Property
    Public Property fecha_inicial() As String
        Get
            Return Me.m_fecha_inicial
        End Get
        Set(ByVal value As String)
            Me.m_fecha_inicial = value
        End Set
    End Property
    Public Property numero_epleado() As String
        Get
            Return Me.m_numero_empleado
        End Get
        Set(ByVal value As String)
            Me.m_numero_empleado = value
        End Set
    End Property
    Public Property certificado() As String
        Get
            Return Me.m_certificado
        End Get
        Set(ByVal value As String)
            Me.m_certificado = value
        End Set
    End Property
    Public Property sin_certificado() As String
        Get
            Return Me.m_sin_certificado
        End Get
        Set(ByVal value As String)
            Me.m_sin_certificado = value
        End Set
    End Property



End Class
