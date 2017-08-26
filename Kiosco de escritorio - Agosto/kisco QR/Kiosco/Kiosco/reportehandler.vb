Imports System.Data.Odbc

Public Class reportehandler
    Private m_con As String
    Private m_connODBC As OdbcConnection

    Public Sub New(ByVal conexion As String)
        Me.m_con = conexion
    End Sub

    Public Function Calculocompra(ByVal fechai As Date, ByVal fechaf As Date) As ArrayList

        ''fecha
        Dim año, mes, dia, año2, mes2, dia2 As String
        Dim inicial As String
        Dim final As String

        año = fechai.Year.ToString
        mes = fechai.Month.ToString
        dia = fechai.Day.ToString

        If mes.Length = 1 Then
            mes = "0" & mes
        End If

        año2 = fechaf.Year.ToString
        mes2 = fechaf.Month.ToString
        dia2 = fechaf.Day.ToString

        If mes2.Length = 1 Then
            mes2 = "0" & mes2
        End If

        inicial = "'" + mes + "-" + dia + "-" + año + "'"
        final = "'" + mes2 + "-" + dia2 + "-" + año2 + "'"

        'fecha


        'Dim tr As FbTransaction
        Dim trODBC As OdbcTransaction
        Try
            Dim cadenaODBC As String

            cadenaODBC = Me.m_con

            Dim OdbcDr As OdbcDataReader
            Dim arreDatos As New ArrayList
            Dim strQuery As New System.Text.StringBuilder()
            'Me.m_conn.Open()
            Me.m_connODBC = New OdbcConnection(cadenaODBC)
            Me.m_connODBC.Open()
            trODBC = Me.m_connODBC.BeginTransaction(IsolationLevel.Serializable)
            Dim commODBC As New OdbcCommand("", Me.m_connODBC, trODBC)
            With strQuery
                .Remove(0, .Length)

                .Append("select fp.nombre as centro, n.fecha_inicial as fecha_inicial ,pn.fecha as fecha_timbrado, ")
                .Append("count(em.nombre_completo) as numero_empleados, ")
                .Append("count(CASE pn.cfdi_certificado ")
                .Append("WHEN 'N' THEN ")
                .Append("NULL ELSE pn.cfdi_certificado END) as certificado, ((count(em.nombre_completo)) - (count(CASE pn.cfdi_certificado ")
                .Append("WHEN 'N' THEN ")
                .Append("NULL ELSE pn.cfdi_certificado END))) as sin_certificado ")
                .Append("from frecuencias_pago fp ")
                .Append("inner join nominas n ")
                .Append("on fp.frepag_id = n.frepag_id  ")
                .Append("inner join pagos_nomina pn ")
                .Append("on n.nomina_id =pn.nomina_id ")
                .Append("inner join empleados em ")
                .Append("on em.empleado_id = pn.empleado_id ")
                .Append("group by fp.frepag_id, fp.nombre, pn.fecha , n.fecha_inicial ")

            End With

            commODBC.CommandText = strQuery.ToString
            OdbcDr = commODBC.ExecuteReader()

            While OdbcDr.Read()
                Dim c As New clscotizacion
              
                Dim mes3 As Date
                Dim mes4 As String
                Dim nombrem As String
                'c.status = OdbcDr("status")
                c.centro = OdbcDr("centro")
                c.fecha_inicial = OdbcDr("fecha_inicial")
                c.fecha_timbrado = OdbcDr("fecha_timbrado")
                c.numero_epleado = OdbcDr("numero_empleados")
                c.certificado = OdbcDr("certificado")
                c.sin_certificado = OdbcDr("sin_certificado")
                arreDatos.Add(c)
            End While

            Me.m_connODBC.Close()

            Return arreDatos
        Catch ex As Exception
            Try
                trODBC.Rollback()
            Catch ex1 As Exception
                MsgBox(ex.Message)
            End Try
        Finally
            Try
                Me.m_connODBC.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Try
    End Function



    Public Function Calculocompran(ByVal fechai As Date, ByVal fechaf As Date) As ArrayList

        ''fecha
        Dim año, mes, dia, año2, mes2, dia2 As String
        Dim inicial As String
        Dim final As String

        año = fechai.Year.ToString
        mes = fechai.Month.ToString
        dia = fechai.Day.ToString

        If mes.Length = 1 Then
            mes = "0" & mes
        End If

        año2 = fechaf.Year.ToString
        mes2 = fechaf.Month.ToString
        dia2 = fechaf.Day.ToString

        If mes2.Length = 1 Then
            mes2 = "0" & mes2
        End If

        inicial = "'" + mes + "-" + dia + "-" + año + "'"
        final = "'" + mes2 + "-" + dia2 + "-" + año2 + "'"

        'fecha


        'Dim tr As FbTransaction
        Dim trODBC As OdbcTransaction
        Try
            Dim cadenaODBC As String

            cadenaODBC = Me.m_con

            Dim OdbcDr As OdbcDataReader
            Dim arreDatos As New ArrayList
            Dim strQuery As New System.Text.StringBuilder()
            'Me.m_conn.Open()
            Me.m_connODBC = New OdbcConnection(cadenaODBC)
            Me.m_connODBC.Open()
            trODBC = Me.m_connODBC.BeginTransaction(IsolationLevel.Serializable)
            Dim commODBC As New OdbcCommand("", Me.m_connODBC, trODBC)
            With strQuery
                .Remove(0, .Length)

                .Append("select fp.nombre as centro, n.fecha_inicial as fecha_inicial, pn.fecha as fecha_timbrado, ")
                .Append("em.nombre_completo as nombre_empleado,em.rfc as rfc, pn.cfdi_certificado  as cfdi_certificado ")
                .Append("from frecuencias_pago fp ")
                .Append("inner join nominas n ")
                .Append("on fp.frepag_id = n.frepag_id ")
                .Append("inner join pagos_nomina pn ")
                .Append("on n.nomina_id =pn.nomina_id ")
                .Append("inner join empleados em ")
                .Append("on em.empleado_id = pn.empleado_id where pn.cfdi_certificado = 'N' ")

               

            End With

            commODBC.CommandText = strQuery.ToString
            OdbcDr = commODBC.ExecuteReader()

            While OdbcDr.Read()
                Dim c As New clscotizacion

                Dim mes3 As Date
                Dim mes4 As String
                Dim nombrem As String
                'c.status = OdbcDr("status")
                c.centro = OdbcDr("centro")
                c.fecha_inicial = OdbcDr("fecha_inicial")
                c.fecha_timbrado = OdbcDr("fecha_timbrado")
                c.nombre_empleado = OdbcDr("nombre_empleado")
                c.rfc = OdbcDr("rfc")
                c.cfdi_timbrado = OdbcDr("cfdi_certificado")
                arreDatos.Add(c)
            End While

            Me.m_connODBC.Close()

            Return arreDatos
        Catch ex As Exception
            Try
                trODBC.Rollback()
            Catch ex1 As Exception
                MsgBox(ex.Message)
            End Try
        Finally
            Try
                Me.m_connODBC.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Try
    End Function
End Class
