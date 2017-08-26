Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.Xml

Imports Kiosco.Form1

Public Class clsKioscoHandler

    Private m_Conn As String
    Private opconexion As Form1
    Private m_ConnODBC As OdbcConnection
    Private m_ConnODBC2009 As OdbcConnection
    Public empresa As String


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
                MsgBox("Error No Controlado 55H: " & ex.Message)
            End Try
        Finally
            Try
                Me.m_ConnODBC.Close()
            Catch ex As Exception
                MsgBox("Error No Controlado 61H: " & ex.Message)
            End Try
        End Try
    End Function

    ''Obten frecuencias

    Public Function ObtenFrecuencias() As ArrayList
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
                .Append("select * from frecuencias_pago ")

            End With
            'comm.CommandText = strQuery.ToString
            commODBC.CommandText = strQuery.ToString
            'dr = com.ExecuteReader()
            OdbcDr = commODBC.ExecuteReader()
            While OdbcDr.Read()
                Dim c As New clsKiosco
                c.IdFrecuencia = OdbcDr("FREPAG_ID")
                c.NombreFrecuencia = OdbcDr("NOMBRE")
                arreDatos.Add(c)
            End While
            'Me.m_conn.Close()
            Me.m_ConnODBC.Close()
            Return arreDatos
        Catch ex As Exception
            Try
                trODBC.Rollback()
            Catch ex1 As Exception
                MsgBox("Error No Controlado 55H: " & ex.Message)
            End Try
        Finally
            Try
                Me.m_ConnODBC.Close()
            Catch ex As Exception
                MsgBox("Error No Controlado 61H: " & ex.Message)
            End Try
        End Try
    End Function

    ''Obten frecuencias

    Public Function ObtenDatosArticulo(ByVal clave As String, ByVal frecuencia As String) As ArrayList
        'Dim tr As FbTransaction
       
        Dim fecha As Date = Convert.ToDateTime(clave)
        Dim dia As String
        Dim mes As String
        Dim ano As String

        dia = fecha.Day
        mes = fecha.Month
        ano = fecha.Year

        Dim fechados As String = "'" & dia & "." & mes & "." & ano & "'"




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
                .Append(" select u.*, pn.nombre as puesto,emp.salario_diario,p.dias_trab as redondeo  from usos_folios_fiscales u ")
                .Append("inner join pagos_nomina p ")
                .Append("on u.docto_id = p.pago_nomina_id ")
                .Append("inner join puestos_no pn ")
                .Append("on p.puesto_no_id = pn.puesto_no_id ")
                .Append("inner join nominas n ")
                .Append("on n.nomina_id = p.nomina_id ")
                .Append("inner join empleados emp ")
                .Append("on p.empleado_id = emp.empleado_id ")
                .Append("inner join frecuencias_pago fp ")
                .Append("on fp.frepag_id = n.frepag_id ")
                .Append("where n.fecha  = " & fechados.ToString & " and fp.frepag_id = " & frecuencia.ToString)
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
                c.salario = OdbcDr("salario_diario")
                c.puestoe = OdbcDr("puesto")
                c.redondeo = OdbcDr("redondeo")
                arreDatos.Add(c)
            End While
            'Me.m_conn.Close()
            Me.m_ConnODBC2009.Close()
            Return arreDatos
        Catch ex As Exception
            Try
                trODBC.Rollback()
            Catch ex1 As Exception
                MsgBox("Error No Controlado 112H: " & ex.Message)
            End Try
        Finally
            Try
                Me.m_ConnODBC2009.Close()
            Catch ex As Exception
                MsgBox("Error No Controlado 118: " & ex.Message)
            End Try
        End Try
    End Function


    ''obtener por lotes

    Public Function ObtenDatosArticulolotes(ByVal frecuencia As String, ByVal fechainicio As String, ByVal fechafin As String) As ArrayList
        'Dim tr As FbTransaction

        Dim fechain As Date = Convert.ToDateTime(fechainicio)
        Dim diain As String
        Dim mesin As String
        Dim anoin As String

        diain = fechain.Day
        mesin = fechain.Month
        anoin = fechain.Year

        Dim inicio As String = "'" & diain & "." & mesin & "." & anoin & "'"

        Dim fechafn As Date = Convert.ToDateTime(fechafin)
        Dim diafn As String
        Dim mesfn As String
        Dim anofn As String

        diafn = fechafn.Day
        mesfn = fechafn.Month
        anofn = fechafn.Year

        Dim final As String = "'" & diafn & "." & mesfn & "." & anofn & "'"




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
                .Append(" select u.*, pn.nombre as puesto,emp.salario_diario,p.dias_trab as redondeo  from usos_folios_fiscales u ")
                .Append("inner join pagos_nomina p ")
                .Append("on u.docto_id = p.pago_nomina_id ")
                .Append("inner join puestos_no pn ")
                .Append("on p.puesto_no_id = pn.puesto_no_id ")
                .Append("inner join nominas n ")
                .Append("on n.nomina_id = p.nomina_id ")
                .Append("inner join empleados emp ")
                .Append("on p.empleado_id = emp.empleado_id ")
                .Append("inner join frecuencias_pago fp ")
                .Append("on fp.frepag_id = n.frepag_id ")
                .Append("where  fp.frepag_id = " & frecuencia.ToString & " and n.fecha BETWEEN " & inicio.ToString & " and " & final.ToString)
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
                c.salario = OdbcDr("salario_diario")
                c.puestoe = OdbcDr("puesto")
                c.redondeo = OdbcDr("redondeo")
                arreDatos.Add(c)
            End While
            'Me.m_conn.Close()
            Me.m_ConnODBC2009.Close()
            Return arreDatos
        Catch ex As Exception
            Try
                trODBC.Rollback()
            Catch ex1 As Exception
                MsgBox("Error No Controlado 112H: " & ex.Message)
            End Try
        Finally
            Try
                Me.m_ConnODBC2009.Close()
            Catch ex As Exception
                MsgBox("Error No Controlado 118: " & ex.Message)
            End Try
        End Try
    End Function

    ''obtener por lotes

    ''nuevo metodo para empleado

    Public Function ObtenDatosnempleado(ByVal clave As Integer, ByVal empleado As String) As ArrayList
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
                .Append(" select u.*,emp.numero as empleado , pn.nombre as puesto,emp.salario_diario,p.dias_trab as redondeo  from usos_folios_fiscales u ")
                .Append("inner join pagos_nomina p ")
                .Append("on u.docto_id = p.pago_nomina_id ")
                .Append("inner join puestos_no pn ")
                .Append("on p.puesto_no_id = pn.puesto_no_id ")
                .Append("inner join nominas n ")
                .Append("on n.nomina_id = p.nomina_id ")
                .Append("inner join empleados emp ")
                .Append("on p.empleado_id = emp.empleado_id ")
                .Append("where n.nomina_id = " & clave.ToString & " AND emp.numero = " & empleado.ToString)
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
                c.salario = OdbcDr("salario_diario")
                c.puestoe = OdbcDr("puesto")
                c.redondeo = OdbcDr("redondeo")
                c.numeroemp = OdbcDr("empleado")
                arreDatos.Add(c)
            End While
            'Me.m_conn.Close()
            Me.m_ConnODBC2009.Close()
            Return arreDatos
        Catch ex As Exception
            Try
                trODBC.Rollback()
            Catch ex1 As Exception
                MsgBox("Error No Controlado 112H: " & ex.Message)
            End Try
        Finally
            Try
                Me.m_ConnODBC2009.Close()
            Catch ex As Exception
                MsgBox("Error No Controlado 118: " & ex.Message)
            End Try
        End Try
    End Function

    ''nuevo metodo para empleado

    ''nuevo
    Public Function Obtenusuario() As ArrayList
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
                .Append("select * from EMPLEADOS")

            End With
            'comm.CommandText = strQuery.ToString
            commODBC.CommandText = strQuery.ToString
            'dr = com.ExecuteReader()
            OdbcDr = commODBC.ExecuteReader()
            While OdbcDr.Read()
                Dim c As New clsKiosco
                c.rol = "2"
                If OdbcDr("APELLIDO_PATERNO") Is DBNull.Value Or OdbcDr("APELLIDO_MATERNO") Is DBNull.Value Or OdbcDr("NOMBRES") Is DBNull.Value Then
                    MsgBox("Debes agregar el nombre con apellidos del usuario " + c.nombre + " para continuar el proceso")
                End If
                c.nombre = OdbcDr("APELLIDO_PATERNO") + " " + OdbcDr("APELLIDO_MATERNO") + " " + OdbcDr("NOMBRES")
                c.email = OdbcDr("APELLIDO_PATERNO") + OdbcDr("NOMBRES") + "@nominas.com"

                If OdbcDr("RFC") Is DBNull.Value Then
                    MsgBox("Debes agregar el rfc del usuario " + c.nombre + " para continuar el proceso")
                End If
                c.rfc = OdbcDr("RFC")
                ' c.rfc = OdbcDr("RFC")
                c.nempleado = "0"
                Me.empresa = Form1.conexion
                If empresa = "ATALANTA" Then
                    c.empresa = "8"

                ElseIf empresa = "NEXTEL" Then
                    c.empresa = "14"
                End If

                c.pass = c.rfc
                arreDatos.Add(c)
            End While
            'Me.m_conn.Close()
            Me.m_ConnODBC.Close()
            Return arreDatos
        Catch ex As Exception
            Try
                trODBC.Rollback()
            Catch ex1 As Exception
                MsgBox("Error No Controlado 168H: " & ex.Message)
            End Try
        Finally
            Try
                Me.m_ConnODBC.Close()
            Catch ex As Exception
                MsgBox("Error No Controlado 174H: " & ex.Message)
            End Try
        End Try
    End Function

    Public Sub Agregausuario(ByVal nombre As String, ByVal email As String, ByVal pass As String, ByVal rfc As String, ByVal rol As String, ByVal nempleado As String _
   , ByVal empresa As String)
        Dim DBCon As OdbcConnection


        DBCon = New OdbcConnection("dsn=conexion") 'asstring'

        Dim consulta As String
        consulta = "insert into usuarios (nombre,email,password,rfc,rolId,noEmpleado,idEmpresa) " + _
                 "values ('" & nombre & "','" & email & "','" & pass & "','" & rfc & "','" & rol & "','" & nempleado & "','" & empresa & "')"

        'Dim nombreu As New OdbcParameter("@nombre", DbType.String)
        'nombreu.Value = nombre
        'Dim emailu As New OdbcParameter("@email", DbType.String)
        'emailu.Value = email
        'Dim passu As New OdbcParameter("@password", DbType.String)
        'passu.Value = pass
        'Dim rfcu As New OdbcParameter("@rfc", DbType.String)
        'rfcu.Value = rfc
        'Dim rolu As New OdbcParameter("@rolId", DbType.Int32)
        'rolu.Value = rol
        'Dim noemp As New OdbcParameter("@noEmpleado", DbType.Int32)
        'noemp.Value = nempleado
        'Dim Empresau As New OdbcParameter("@idEmpresa", DbType.Int32)
        'Empresau.Value = empresa



        Try
            'Abrimos la conexión y comprobamos que no hay error

            Using comm As New OdbcCommand(consulta, DBCon)
                With comm
                    .CommandType = CommandType.Text

                    '.Parameters.Add(nombreu)
                    '.Parameters.Add(emailu)
                    '.Parameters.Add(passu)
                    '.Parameters.Add(rfcu)
                    '.Parameters.Add(rolu)
                    '.Parameters.Add(noemp)
                    '.Parameters.Add(Empresau)


                End With
                DBCon.Open()
                ' MsgBox("Conecxion realizada satsfactoriamente")
                comm.ExecuteNonQuery()

            End Using
            '   MsgBox("Conecxion realizada satsfactoriamente")
        Catch ex As Odbc.OdbcException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox(ex.Message.ToString)
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Sub

    ''nuevo (xml)

    '  Public Sub Agregausuarioxml(ByVal nombre As String, ByVal email As String, ByVal pass As String, ByVal rfc As String, ByVal rol As Integer, ByVal nempleado As Integer _
    ', ByVal empresa As Integer)
    '      Dim DBCon As MySQLConnection


    '      DBCon = New MySQLConnection(New MySQLConnectionString("ipp.com.mx", "ipp_kiosco", "ipp_kiosco", "Ajpb1Q02T9yF", 3306).AsString)

    '      Dim consulta As String
    '      consulta = "insert into usuarios (nombre,email,password,rfc,rolId,noEmpleado,idEmpresa) " + _
    '              "values (@nombre,@email,@password,@rfc,@rolId,@noEmpleado,@idEmpresa)"

    '      Dim nombreu As New MySQLParameter("@nombre", DbType.String)
    '      nombreu.Value = nombre
    '      Dim emailu As New MySQLParameter("@email", DbType.String)
    '      emailu.Value = email
    '      Dim passu As New MySQLParameter("@password", DbType.String)
    '      passu.Value = pass
    '      Dim rfcu As New MySQLParameter("@rfc", DbType.String)
    '      rfcu.Value = rfc
    '      Dim rolu As New MySQLParameter("@rolId", DbType.Int32)
    '      rolu.Value = rol
    '      Dim noemp As New MySQLParameter("@noEmpleado", DbType.Int32)
    '      noemp.Value = nempleado
    '      Dim Empresau As New MySQLParameter("@idEmpresa", DbType.Int32)
    '      Empresau.Value = empresa



    '      Try
    '          'Abrimos la conexión y comprobamos que no hay error

    '          Using comm As New MySQLCommand(consulta, DBCon)
    '              With comm
    '                  .CommandType = CommandType.Text

    '                  .Parameters.Add(nombreu)
    '                  .Parameters.Add(emailu)
    '                  .Parameters.Add(passu)
    '                  .Parameters.Add(rfcu)
    '                  .Parameters.Add(rolu)
    '                  .Parameters.Add(noemp)
    '                  .Parameters.Add(Empresau)


    '              End With
    '              DBCon.Open()
    '              MsgBox("Conecxion realizada satsfactoriamente")
    '              comm.ExecuteNonQuery()

    '          End Using
    '          MsgBox("Conecxion realizada satsfactoriamente")
    '      Catch ex As MySQLException
    '          'Si hubiese error en la conexión mostramos el texto de la descripción
    '          MsgBox(ex.Message.ToString)
    '      Finally
    '          DBCon.Close()
    '          DBCon.Dispose()
    '      End Try
    '  End Sub

    ''nuevo (xml)

    Public Function Validausuario(ByVal RFCU As String) As Boolean
        Dim DBCon As OdbcConnection


        DBCon = New OdbcConnection("dsn=conexion") 'asstring'

        Dim consulta As String
        Dim resultado As Integer
        consulta = "SELECT COUNT(*) FROM usuarios where rfc = @rfc"
        Dim rfc As New OdbcParameter("@rfc", DbType.String)
        rfc.Value = RFCU

        Try
            'Abrimos la conexión y comprobamos que no hay error
            Using comm As New OdbcCommand(consulta, DBCon)
                With comm
                    .CommandType = CommandType.Text
                    .Parameters.Add(rfc)
                End With
                DBCon.Open()
                resultado = comm.ExecuteScalar()
            End Using
            ' MsgBox("Conecxion realizada satsfactoriamente")
            If resultado > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Odbc.OdbcException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox(ex.Message.ToString)
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Function

    'Public Function Validausuarioxml(ByVal RFCx As String) As Boolean
    '    Dim DBCon As MySQLConnection


    '    DBCon = New MySQLConnection(New MySQLConnectionString("ipp.com.mx", "ipp_kiosco", "ipp_kiosco", "Ajpb1Q02T9yF", 3306).AsString)

    '    Dim consulta As String
    '    Dim resultado As Integer
    '    consulta = "SELECT COUNT(*) FROM usuarios where rfc = @rfc"
    '    Dim rfc As New MySQLParameter("@rfc", DbType.String)
    '    rfc.Value = RFCx

    '    Try
    '        'Abrimos la conexión y comprobamos que no hay error
    '        Using comm As New MySQLCommand(consulta, DBCon)
    '            With comm
    '                .CommandType = CommandType.Text
    '                .Parameters.Add(rfc)
    '            End With
    '            DBCon.Open()
    '            resultado = comm.ExecuteScalar()
    '        End Using
    '        ' MsgBox("Conecxion realizada satsfactoriamente")
    '        If resultado > 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As MySQLException
    '        'Si hubiese error en la conexión mostramos el texto de la descripción
    '        MsgBox(ex.Message.ToString)
    '    Finally
    '        DBCon.Close()
    '        DBCon.Dispose()
    '    End Try
    'End Function

    ''nuevo

    Public Sub AgregaDatos(ByVal fecha As Date, ByVal xml As String, ByVal fechatim As Date, ByVal uuid As String, ByVal cfdiid As Integer _
    , ByVal nomempresa As String, ByVal rfcempre As String, ByVal nomempleado As String, ByVal rfcEmp As String, ByVal NUMSS As String, ByVal NCURP As String _
    , ByVal fecha1pago As Date, ByVal fecha2pago As Date, ByVal numdiaspagados As Integer, ByVal dept As String, ByVal foliofis As String, ByVal selloCFDI As String, ByVal sellosat As String _
    , ByVal nocert As String, ByVal fechatimx As String, ByVal lexpedicion As String, ByVal FPago As String)
        Dim DBCon As OdbcConnection


        DBCon = New OdbcConnection("atalanta_kiosco") 'asstring'
        'DBCon = New MySQLConnection(New MySQLConnectionString("atalanta.com.mx", "atalanta_camaras", "atalanta", "jessyka", 3306).AsString)
        Dim consulta As String
        consulta = "insert into tblXML " + _
                "values (@fecha,@xml,@fechatim,@uuidd,@cfdiid,@NombreEmpresa,@RFCEmpresa,@NombreEmpleado,@RFCEmpleado,@NSS,@CURP,@FechaIPago,@FechaFPago," + _
                "@NumDiasPagados,@Departamento,@FolioFiscal,@SDCFDI,@SDSAT,@NoCertificado,@FechaTimbrado,@LugarExpedicion,@FormaPago)"


        Dim fechaP As New OdbcParameter("@fecha", DbType.DateTime)
        fechaP.Value = fecha
        Dim xmlP As New OdbcParameter("@xml", DbType.String)
        xmlP.Value = xml
        Dim fechatimP As New OdbcParameter("@fechatim", DbType.DateTime)
        fechatimP.Value = fechatim
        Dim uuidP As New OdbcParameter("@uuidd", DbType.String)
        uuidP.Value = uuid
        Dim cfdiidP As New OdbcParameter("@cfdiid", DbType.Int16)
        cfdiidP.Value = cfdiid

        Dim NombreEmpresa As New OdbcParameter("@NombreEmpresa", DbType.String)
        NombreEmpresa.Value = nomempresa
        Dim RFCEmpresa As New OdbcParameter("@RFCEmpresa", DbType.String)
        RFCEmpresa.Value = rfcempre
        Dim NombreEmpleado As New OdbcParameter("@NombreEmpleado", DbType.String)
        NombreEmpleado.Value = nomempleado
        Dim RFCEmpleado As New OdbcParameter("@RFCEmpleado", DbType.String)
        RFCEmpleado.Value = rfcEmp
        Dim NSS As New OdbcParameter("@NSS", DbType.String)
        NSS.Value = NUMSS
        Dim CURP As New OdbcParameter("@CURP", DbType.String)
        CURP.Value = NCURP
        Dim FechaIPago As New OdbcParameter("@FechaIPago", DbType.DateTime)
        FechaIPago.Value = fecha1pago
        Dim FechaFPago As New OdbcParameter("@FechaFPago", DbType.String)
        FechaFPago.Value = fecha2pago
        Dim NDiasPagados As New OdbcParameter("@NumDiasPagados", DbType.Int64)
        NDiasPagados.Value = numdiaspagados
        Dim Departamento As New OdbcParameter("@Departamento", DbType.String)
        Departamento.Value = dept
        Dim FolioFiscal As New OdbcParameter("@FolioFiscal", DbType.String)
        FolioFiscal.Value = foliofis
        Dim SDCFDI As New OdbcParameter("@SDCFDI", DbType.String)
        SDCFDI.Value = selloCFDI
        Dim SDSAT As New OdbcParameter("@SDSAT", DbType.String)
        SDSAT.Value = sellosat
        Dim NoCertificado As New OdbcParameter("@NoCertificado", DbType.String)
        NoCertificado.Value = nocert
        Dim FechaTimbrado As New OdbcParameter("@FechaTimbrado", DbType.String)
        FechaTimbrado.Value = fechatimx
        Dim LugarExpedicion As New OdbcParameter("@LugarExpedicion", DbType.String)
        LugarExpedicion.Value = lexpedicion
        Dim FormaPago As New OdbcParameter("@FormaPago", DbType.String)
        FormaPago.Value = FPago
        Try
            'Abrimos la conexión y comprobamos que no hay error
            Using comm As New OdbcCommand(consulta, DBCon)
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
        Catch ex As Odbc.OdbcException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox(ex.Message.ToString)
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Sub

    Public Function ValidaFolioFiscal(ByVal foliofis As String) As Boolean
        Dim DBCon As OdbcConnection


        DBCon = New OdbcConnection("atalanta_kiosco")
        'DBCon = New MySQLConnection(New MySQLConnectionString("atalanta.com.mx", "atalanta_camaras", "atalanta", "jessyka", 3306).AsString)
        Dim consulta As String
        Dim resultado As Integer
        consulta = "SELECT COUNT(*) FROM tblXML where FolioFiscal = @FolioFiscal"
        Dim FolioFiscal As New OdbcParameter("@FolioFiscal", DbType.String)
        FolioFiscal.Value = foliofis

        Try
            'Abrimos la conexión y comprobamos que no hay error
            Using comm As New OdbcCommand(consulta, DBCon)
                With comm
                    .CommandType = CommandType.Text
                    .Parameters.Add(FolioFiscal)
                End With
                DBCon.Open()
                resultado = comm.ExecuteScalar()
            End Using
            '            MsgBox("Conexion realizada satsfactoriamente")
            If resultado > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Odbc.OdbcException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox(ex.Message.ToString)
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Function


    Public Sub AgregaDatosDetalles(ByVal foliofis As String, ByVal nocert As String, ByVal clavex As String _
    , ByVal conce As String, ByVal impgravado As Double, ByVal impexento As Double, ByVal tipox As String)
        Dim DBCon As OdbcConnection


        DBCon = New OdbcConnection("atalanta_kiosco")
        'DBCon = New MySQLConnection(New MySQLConnectionString("atalanta.com.mx", "atalanta_camaras", "atalanta", "jessyka", 3306).AsString)
        Dim consulta As String
        consulta = "insert into tblXMLDetalles " + _
                "values (@FolioFiscal,@NoCertificado,@Clave,@Concepto,@ImporteGravado,@ImporteExento,@Tipo)"




        Dim FolioFiscal As New OdbcParameter("@FolioFiscal", DbType.String)
        FolioFiscal.Value = foliofis
        Dim NoCertificado As New OdbcParameter("@NoCertificado", DbType.String)
        NoCertificado.Value = nocert
        Dim Clave As New OdbcParameter("@Clave", DbType.String)
        Clave.Value = clavex
        Dim Concepto As New OdbcParameter("@Concepto", DbType.String)
        Concepto.Value = conce
        Dim ImporteGravado As New OdbcParameter("@ImporteGravado", DbType.Double)
        ImporteGravado.Value = impgravado
        Dim ImporteExento As New OdbcParameter("@ImporteExento", DbType.Double)
        ImporteExento.Value = impexento
        Dim Tipo As New OdbcParameter("@Tipo", DbType.String)
        Tipo.Value = tipox
        Try
            'Abrimos la conexión y comprobamos que no hay error
            Using comm As New OdbcCommand(consulta, DBCon)
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
            '            MsgBox("Conexion realizada satsfactoriamente")
        Catch ex As Odbc.OdbcException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox("Error No Controlado 311H: " & ex.Message)
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Sub

End Class
