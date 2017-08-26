Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Xml
Imports MySQLDriverCS

Public Class clsKioscoHandler

    Private m_Conn As String

    Private m_ConnODBC As OdbcConnection
    Private m_ConnODBC2009 As OdbcConnection

    Public Sub New(ByVal conn As String)
        Me.m_Conn = conn
    End Sub

    Public Function ObtenNominas() As ArrayList
        'Dim tr As FbTransaction
        Dim trODBC As OdbcTransaction
        Try
            Dim cadenaODBC As String

            cadenaODBC = Me.m_Conn

            Dim OdbcDr As OdbcDataReader
            Dim arreDatos As New ArrayList
            Dim strQuery As New System.Text.StringBuilder()
            'Me.m_conn.Open()
            Me.m_ConnODBC = New OdbcConnection(cadenaODBC)
            Me.m_ConnODBC.Open()
            trODBC = Me.m_ConnODBC.BeginTransaction(IsolationLevel.Serializable)
            Dim commODBC As New OdbcCommand("", Me.m_ConnODBC, trODBC)
            With strQuery
                .Remove(0, .Length)
                .Append("select * from nominas")

            End With
            'comm.CommandText = strQuery.ToString
            commODBC.CommandText = strQuery.ToString
            'dr = com.ExecuteReader()
            OdbcDr = commODBC.ExecuteReader()
            While OdbcDr.Read()
                Dim c As New clsKiosco
                c.IdNomina = OdbcDr("NOMINA_ID")
                c.FechaNomina = OdbcDr("FECHA_PAGO")
                arreDatos.Add(c)
            End While
            'Me.m_conn.Close()
            Me.m_ConnODBC.Close()
            Return arreDatos
        Catch ex As Exception
            Try
                trODBC.Rollback()
            Catch ex1 As Exception
                MsgBox(ex.Message)
            End Try
        Finally
            Try
                Me.m_ConnODBC.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Try
    End Function

    Public Function ObtenDatosArticulo(ByVal clave As Integer) As ArrayList
        'Dim tr As FbTransaction
        Dim trODBC As OdbcTransaction
        Try

            Dim cadenaODBC As String
            Dim arreDatos As New ArrayList
            cadenaODBC = Me.m_Conn
            Dim OdbcDr As OdbcDataReader
            Dim strQuery As New System.Text.StringBuilder()
            'Me.m_conn.Open()
            Me.m_ConnODBC2009 = New OdbcConnection(cadenaODBC)
            Me.m_ConnODBC2009.Open()

            trODBC = Me.m_ConnODBC2009.BeginTransaction(IsolationLevel.RepeatableRead)
            Dim commODBC As New OdbcCommand("", Me.m_ConnODBC2009, trODBC)
            With strQuery
                .Remove(0, .Length)
                .Append("select u.* from usos_folios_fiscales u ")
                .Append("inner join pagos_nomina p ")
                .Append("on u.docto_id = p.pago_nomina_id ")
                .Append("inner join nominas n ")
                .Append("on n.nomina_id = p.nomina_id ")
                .Append("where n.nomina_id = " & clave.ToString)
            End With
            'comm.CommandText = strQuery.ToString
            commODBC.CommandText = strQuery.ToString
            'dr = com.ExecuteReader()
            OdbcDr = commODBC.ExecuteReader()
            trODBC.Commit()
            While OdbcDr.Read()
                Dim c As New clsKiosco
                c.Fecha = OdbcDr("FECHA")
                c.XML = OdbcDr("XML")
                c.FechaHoraTimbrado = OdbcDr("FECHA_HORA_TIMBRADO")
                c.UUID = OdbcDr("UUID")
                c.CFDI_ID = OdbcDr("CFDI_ID")
                arreDatos.Add(c)
            End While
            'Me.m_conn.Close()
            Me.m_ConnODBC2009.Close()
            Return arreDatos
        Catch ex As Exception
            Try
                trODBC.Rollback()
            Catch ex1 As Exception
                MsgBox(ex.Message)
            End Try
        Finally
            Try
                Me.m_ConnODBC2009.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Try
    End Function

    Public Sub AgregaDatos(ByVal fecha As Date, ByVal xml As String, ByVal fechatim As Date, ByVal uuid As String, ByVal cfdiid As Integer _
    , ByVal nomempresa As String, ByVal rfcempre As String, ByVal nomempleado As String, ByVal rfcEmp As String, ByVal NUMSS As String, ByVal NCURP As String _
    , ByVal fecha1pago As Date, ByVal fecha2pago As Date, ByVal numdiaspagados As Integer, ByVal dept As String, ByVal foliofis As String, ByVal selloCFDI As String, ByVal sellosat As String _
    , ByVal nocert As String, ByVal fechatimx As String, ByVal lexpedicion As String, ByVal FPago As String)
        Dim DBCon As MySQLConnection


        DBCon = New MySQLConnection(New MySQLConnectionString("atalanta.com.mx", "atalanta_kiosco", "atalanta_kiosco", "zVMyDEaqH6d7", 3306).AsString)
        'DBCon = New MySQLConnection(New MySQLConnectionString("atalanta.com.mx", "atalanta_camaras", "atalanta", "jessyka", 3306).AsString)
        Dim consulta As String
        consulta = "insert into tblXML " + _
                "values (@fecha,@xml,@fechatim,@uuidd,@cfdiid,@NombreEmpresa,@RFCEmpresa,@NombreEmpleado,@RFCEmpleado,@NSS,@CURP,@FechaIPago,@FechaFPago," + _
                "@NumDiasPagados,@Departamento,@FolioFiscal,@SDCFDI,@SDSAT,@NoCertificado,@FechaTimbrado,@LugarExpedicion,@FormaPago)"


        Dim fechaP As New MySQLParameter("@fecha", DbType.DateTime)
        fechaP.Value = fecha
        Dim xmlP As New MySQLParameter("@xml", DbType.String)
        xmlP.Value = xml
        Dim fechatimP As New MySQLParameter("@fechatim", DbType.DateTime)
        fechatimP.Value = fechatim
        Dim uuidP As New MySQLParameter("@uuidd", DbType.String)
        uuidP.Value = uuid
        Dim cfdiidP As New MySQLParameter("@cfdiid", DbType.Int16)
        cfdiidP.Value = cfdiid

        Dim NombreEmpresa As New MySQLParameter("@NombreEmpresa", DbType.String)
        NombreEmpresa.Value = nomempresa
        Dim RFCEmpresa As New MySQLParameter("@RFCEmpresa", DbType.String)
        RFCEmpresa.Value = rfcempre
        Dim NombreEmpleado As New MySQLParameter("@NombreEmpleado", DbType.String)
        NombreEmpleado.Value = nomempleado
        Dim RFCEmpleado As New MySQLParameter("@RFCEmpleado", DbType.String)
        RFCEmpleado.Value = rfcEmp
        Dim NSS As New MySQLParameter("@NSS", DbType.String)
        NSS.Value = NUMSS
        Dim CURP As New MySQLParameter("@CURP", DbType.String)
        CURP.Value = NCURP
        Dim FechaIPago As New MySQLParameter("@FechaIPago", DbType.DateTime)
        FechaIPago.Value = fecha1pago
        Dim FechaFPago As New MySQLParameter("@FechaFPago", DbType.String)
        FechaFPago.Value = fecha2pago
        Dim NDiasPagados As New MySQLParameter("@NumDiasPagados", DbType.Int64)
        NDiasPagados.Value = numdiaspagados
        Dim Departamento As New MySQLParameter("@Departamento", DbType.String)
        Departamento.Value = dept
        Dim FolioFiscal As New MySQLParameter("@FolioFiscal", DbType.String)
        FolioFiscal.Value = foliofis
        Dim SDCFDI As New MySQLParameter("@SDCFDI", DbType.String)
        SDCFDI.Value = selloCFDI
        Dim SDSAT As New MySQLParameter("@SDSAT", DbType.String)
        SDSAT.Value = sellosat
        Dim NoCertificado As New MySQLParameter("@NoCertificado", DbType.String)
        NoCertificado.Value = nocert
        Dim FechaTimbrado As New MySQLParameter("@FechaTimbrado", DbType.String)
        FechaTimbrado.Value = fechatimx
        Dim LugarExpedicion As New MySQLParameter("@LugarExpedicion", DbType.String)
        LugarExpedicion.Value = lexpedicion
        Dim FormaPago As New MySQLParameter("@FormaPago", DbType.String)
        FormaPago.Value = FPago
        Try
            'Abrimos la conexión y comprobamos que no hay error
            Using comm As New MySQLCommand(consulta, DBCon)
                With comm
                    .CommandType = CommandType.Text
                    .Parameters.Add(fechaP)
                    .Parameters.Add(xmlP)
                    .Parameters.Add(fechatimP)
                    .Parameters.Add(uuidP)
                    .Parameters.Add(cfdiidP)
                    .Parameters.Add(NombreEmpresa)
                    .Parameters.Add(RFCEmpresa)
                    .Parameters.Add(NombreEmpleado)
                    .Parameters.Add(RFCEmpleado)
                    .Parameters.Add(NSS)
                    .Parameters.Add(CURP)
                    .Parameters.Add(FechaIPago)
                    .Parameters.Add(FechaFPago)
                    .Parameters.Add(NDiasPagados)
                    .Parameters.Add(Departamento)
                    .Parameters.Add(FolioFiscal)
                    .Parameters.Add(SDCFDI)
                    .Parameters.Add(SDSAT)
                    .Parameters.Add(NoCertificado)
                    .Parameters.Add(FechaTimbrado)
                    .Parameters.Add(LugarExpedicion)
                    .Parameters.Add(FormaPago)
                End With
                DBCon.Open()
                comm.ExecuteNonQuery()

            End Using
            '            MsgBox("Conecxion realizada satsfactoriamente")
        Catch ex As MySQLException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox(ex.Message.ToString)
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Sub

    Public Function ValidaFolioFiscal(ByVal foliofis As String) As Boolean
        Dim DBCon As MySQLConnection


        DBCon = New MySQLConnection(New MySQLConnectionString("atalanta.com.mx", "atalanta_kiosco", "atalanta_kiosco", "zVMyDEaqH6d7", 3306).AsString)
        'DBCon = New MySQLConnection(New MySQLConnectionString("atalanta.com.mx", "atalanta_camaras", "atalanta", "jessyka", 3306).AsString)
        Dim consulta As String
        Dim resultado As Integer
        consulta = "SELECT COUNT(*) FROM tblXML where FolioFiscal = @FolioFiscal"
        Dim FolioFiscal As New MySQLParameter("@FolioFiscal", DbType.String)
        FolioFiscal.Value = foliofis

        Try
            'Abrimos la conexión y comprobamos que no hay error
            Using comm As New MySQLCommand(consulta, DBCon)
                With comm
                    .CommandType = CommandType.Text
                    .Parameters.Add(FolioFiscal)
                End With
                DBCon.Open()
                resultado = comm.ExecuteScalar()
            End Using
            '            MsgBox("Conecxion realizada satsfactoriamente")
            If resultado > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As MySQLException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox(ex.Message.ToString)
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Function


    Public Sub AgregaDatosDetalles(ByVal foliofis As String, ByVal nocert As String, ByVal clavex As String _
    , ByVal conce As String, ByVal impgravado As Double, ByVal impexento As Double, ByVal tipox As String)
        Dim DBCon As MySQLConnection


        DBCon = New MySQLConnection(New MySQLConnectionString("atalanta.com.mx", "atalanta_kiosco", "atalanta_kiosco", "zVMyDEaqH6d7", 3306).AsString)
        'DBCon = New MySQLConnection(New MySQLConnectionString("atalanta.com.mx", "atalanta_camaras", "atalanta", "jessyka", 3306).AsString)
        Dim consulta As String
        consulta = "insert into tblXMLDetalles " + _
                "values (@FolioFiscal,@NoCertificado,@Clave,@Concepto,@ImporteGravado,@ImporteExento,@Tipo)"




        Dim FolioFiscal As New MySQLParameter("@FolioFiscal", DbType.String)
        FolioFiscal.Value = foliofis
        Dim NoCertificado As New MySQLParameter("@NoCertificado", DbType.String)
        NoCertificado.Value = nocert
        Dim Clave As New MySQLParameter("@Clave", DbType.String)
        Clave.Value = clavex
        Dim Concepto As New MySQLParameter("@Concepto", DbType.String)
        Concepto.Value = conce
        Dim ImporteGravado As New MySQLParameter("@ImporteGravado", DbType.Double)
        ImporteGravado.Value = impgravado
        Dim ImporteExento As New MySQLParameter("@ImporteExento", DbType.Double)
        ImporteExento.Value = impexento
        Dim Tipo As New MySQLParameter("@Tipo", DbType.String)
        Tipo.Value = tipox
        Try
            'Abrimos la conexión y comprobamos que no hay error
            Using comm As New MySQLCommand(consulta, DBCon)
                With comm
                    .CommandType = CommandType.Text
                    .Parameters.Add(FolioFiscal)
                    .Parameters.Add(NoCertificado)
                    .Parameters.Add(Clave)
                    .Parameters.Add(Concepto)
                    .Parameters.Add(ImporteGravado)
                    .Parameters.Add(ImporteExento)
                    .Parameters.Add(Tipo)
                End With
                DBCon.Open()
                comm.ExecuteNonQuery()

            End Using
            '            MsgBox("Conecxion realizada satsfactoriamente")
        Catch ex As MySQLException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox(ex.Message.ToString)
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Sub

End Class
