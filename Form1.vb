Imports System.IO.Ports
Imports System.Timers
Public Class Form1
    Dim WithEvents COMPort As New SerialPort
    Dim Count As Integer
    Dim ThermoCount As Integer
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBaud.SelectedIndexChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        BtnCon.Enabled = False
        BtnCon.BringToFront()

        BtnDiscon.Enabled = False
        BtnDiscon.SendToBack()

        CmbBaud.SelectedItem = "115200"

        '' initialize graph
        '  Dim aw As String
        '  aw = 3000
        '  Chart1.Series("Series1").Points.AddY(aw)
        '  Chart1.Series("Series1").IsValueShownAsLabel = False
        ' Chart1.ChartAreas("ChartArea1").AxisX.Enabled = DataVisualization.Charting.AxisEnabled.False

        'transmission and launch variables initialization
        transmission = False
        launched = False


    End Sub


    ' instantiate data collector
    Dim dc As DataCollector = New DataCollector
    Private Sub BtnCon_Click(sender As Object, e As EventArgs) Handles BtnCon.Click
        BtnCon.Enabled = False
        BtnCon.SendToBack()

        dc.SetDirectory("C:\Users\aaron\OneDrive\Desktop\SOARData\")

        dc.getCOMPort.BaudRate = CmbBaud.SelectedItem
        dc.getCOMPort.PortName = CmbPort.SelectedItem
        dc.openPort()
        dc.Show()


        NonThermoTimer.Start()

        ThermoTimer.Start()

        BtnDiscon.Enabled = True
        BtnDiscon.BringToFront()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPort.SelectedIndexChanged

    End Sub

    Private Sub BtnScanPort_Click(sender As Object, e As EventArgs) Handles BtnScanPort.Click
        CmbPort.Items.Clear()
        Dim myPort As Array
        Dim i As Integer
        myPort = IO.Ports.SerialPort.GetPortNames()
        CmbPort.Items.AddRange(myPort)
        i = CmbPort.Items.Count
        i = i - 1
        Try
            CmbPort.SelectedIndex = i
        Catch ex As Exception
            Dim result As DialogResult
            result = MessageBox.Show("com port not detected", "Warning!", MessageBoxButtons.OK)
            CmbPort.Text = ""
            CmbPort.Items.Clear()
            Call Form1_Load(Me, e)
        End Try
        BtnCon.Enabled = True
        BtnCon.BringToFront()
        CmbPort.DroppedDown = True


    End Sub

    Private Sub BtnDiscon_Click(sender As Object, e As EventArgs) Handles BtnDiscon.Click
        BtnDiscon.Enabled = False
        BtnDiscon.SendToBack()

        NonThermoTimer.Stop()
        dc.getCOMPort().Close()

        BtnCon.Enabled = True
        BtnCon.BringToFront()

    End Sub

    Private Sub TimerPressure_Tick(sender As Object, e As EventArgs) Handles NonThermoTimer.Tick
        Try
            Dim i As Single = dc.getDataPack().GetDataTime()
            Dim j As Single = dc.getDataPack().GetPressure()
            Dim accelx As Single = dc.getDataPack().GetAccelX()
            Dim accely As Single = dc.getDataPack().GetAccelY()
            Dim accelz As Single = dc.getDataPack().GetAccelZ()
            Dim accelmag As Single = Math.Sqrt(dc.getDataPack().getAccelX() ^ 2 + dc.getDataPack.getAccelY() ^ 2 + dc.getDataPack.getAccelZ() ^ 2)
            Dim thrustval As Single = dc.getDataPack().GetThrust()

            Dim previousCount As Single = 0

            PressureValue.Text = "Pressure Value: " & j.ToString & " psi"
            ThrustValue.Text = "Thrust Value: " & thrustval.ToString & " kg"
            Label2.Text = "Acceleration magnitude: " & accelmag.ToString & " g"


            ''Dim x As Integer
            ''Dim element As Integer
            ''For x = 0 To Chart1.Series(0).Points.Count
            ''    element = Chart1.Series(0).XValue
            ''    If (element < Count - 20) Then
            ''        Chart1.Series(0).Points.RemoveAt(x)
            ''    End If

            'pressure 0 - 3000 psi
            Chart1.ChartAreas(0).AxisY.Maximum = 3000

            ' thrust 0 - 1000 kg
            Chart2.ChartAreas(0).AxisY.Maximum = 1000

            ' acceleration -6 to 6 gs
            Chart4.ChartAreas(0).AxisY.Maximum = 6
            Chart4.ChartAreas(0).AxisY.Minimum = -6
            If launched Then
                Chart1.Series("Series1").Points.AddXY((i / (133 * 4)).ToString, j.ToString)
                Chart1.ChartAreas(0).AxisX.Maximum = Count / (133 * 4)
                Chart1.ChartAreas(0).AxisX.Minimum = Count / (133 * 4) - 20
            Else
                ' Chart1.ChartAreas(0).AxisX.Maximum = (i / (133 * 4)) - (i / (133 * 4)) Mod 0.01
                ' Chart1.ChartAreas(0).AxisX.Minimum = (i / (133 * 4)) - (i / (133 * 4)) Mod 0.01 - 20
                If (i <> previousCount) Then
                    'update previous count
                    previousCount = i
                    Chart1.Series("Series1").Points.AddY(j)
                    Chart2.Series("Series1").Points.AddY(thrustval)

                    Chart4.Series("AccelX").Points.AddY(accelx)
                    Chart4.Series("AccelY").Points.AddY(accely)
                    Chart4.Series("AccelZ").Points.AddY(accelz)
                    Chart4.Series("AccelMag").Points.AddY(accelmag)
                End If
                Chart1.ChartAreas(0).AxisX.Maximum = XCount / 10
                Chart1.ChartAreas(0).AxisX.Minimum = XCount / 10 - 20

                Chart2.ChartAreas(0).AxisX.Maximum = XCount / 10
                Chart2.ChartAreas(0).AxisX.Minimum = XCount / 10 - 20





                Chart4.ChartAreas(0).AxisX.Maximum = XCount / 10
                Chart4.ChartAreas(0).AxisX.Minimum = XCount / 10 - 20


                ' Chart1.Series("Series1").Points.AddY(j)
                'Chart1.Series("Series1").Points.AddXY((i / (133 * 4)), j)
            End If

            Console.WriteLine(i)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub


    Dim launched As Boolean
    ' Create timer to keep track of the countdown to the launch
    Dim timer As Timer = New Timer()
    Private Sub Launch_Click(sender As Object, e As EventArgs) Handles Launch.Click
        ' start launch

        If (Not launched) Then

            ' send input dialog box to user to get confirmation of the launch

            Dim Message, Title, MyValue
            Message = "Enter Proplab Launch"    ' Set prompt.
            Title = "InputBox Demo"    ' Set title.
            'Default = "1"    ' Set default.
            ' Display message, title, and default value.
            MyValue = InputBox(Message, Title)



            ' Send command to arduino to send launch message

            ' SerialPort1.Write("Launch confirmed")
            'Timer1.Stop()
            If (MyValue = "Proplab Launch") Then
                launched = True

                Launch.Text = "Cancel Launch"


                ' ButtonCancel.BringToFront()
                Dim code(5) As Byte
                code(1) = Byte.Parse("28", System.Globalization.NumberStyles.HexNumber)
                code(2) = Byte.Parse("53", System.Globalization.NumberStyles.HexNumber)
                code(3) = Byte.Parse("4F", System.Globalization.NumberStyles.HexNumber)
                code(4) = Byte.Parse("41", System.Globalization.NumberStyles.HexNumber)
                code(5) = Byte.Parse("52", System.Globalization.NumberStyles.HexNumber)
                Dim i As Integer
                For i = 0 To 4
                    dc.getCOMPort().Write(code(i))
                Next
                ' start timer for launching
                Timer.Interval = 1000
                AddHandler timer.Elapsed, AddressOf TimerEvent
                timer.AutoReset = True
                timer.Enabled = True
            End If


            ' cancel launch
        ElseIf (launched) Then
            launched = False
            Launch.Text = "Ignite"
        End If
        'Timer2.Start()
    End Sub

    ' Elapsed Event

    Dim secondsCounter As Integer = 0
    Dim initialCount
    Dim initialThermoCount
    Private Sub TimerEvent(ByVal source As Object, ByVal e As ElapsedEventArgs)
        secondsCounter = secondsCounter + 1
        If secondsCounter < 37 Then
            CountdownLabel.Text = "Countdown to Launch: " & 37 - secondsCounter & "seconds"
        End If
        If secondsCounter = 37 Then
            initialCount = dc.getDataPack().GetDataTime
            initialThermoCount = dc.getDataPack().GetThermoTime
            Dim datapacketwrite(5) As Byte
            datapacketwrite(0) = Byte.Parse("0C", Globalization.NumberStyles.HexNumber)
            datapacketwrite(1) = Byte.Parse("00")
            datapacketwrite(2) = Byte.Parse("00")
            datapacketwrite(3) = Byte.Parse("00")
            datapacketwrite(4) = Byte.Parse("00")

            Dim i As Integer
            For i = 0 To 4
                SerialPort1.Write(datapacketwrite(i))
            Next

        End If
        If secondsCounter > 37 Then
            Count = dc.getDataPack().GetDataTime - initialCount
            ThermoCount = dc.getDataPack().GetDataTime - initialThermoCount
        End If

        ' Console.WriteLine("Event Raised at {0:HH:mm:ss.fff}", e.SignalTime)

    End Sub


    Dim SpaceCount As Byte = 0
    Dim LookUpTable As String = "0123456789ABCDEF"
    Dim RXArray(2047) As Char ' Text buffer. Must be global to be accessible from more threads.
    Dim RXCnt As Integer      ' Length of text buffer. Must be global too.

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles COMPort.DataReceived

        'Dim RXByte As Byte
        'Do
        '    '----- Start of communication protocol handling -----------------------------------------------------------
        '    ' The code between the two lines does the communication protocol. In this case, it simply emties the
        '    '   receive buffer and converts it to text, but for all practical applications, you must replace this part
        '    '     with a code, which can collect one entire telegram by searching for the telegram
        '    '       delimiter/termination. In case of a simple ASCII protocol, you may just use ReadLine and receive
        '    '         in a global string instead of a byte array.
        '    ' Because this routine runs on a thread pool thread, it does not block the UI, so if you have any data
        '    '   convertion, encryption, expansion, error detection, error correction etc. to do, do it here.
        '    RXCnt = 0
        '    Do
        '        RXByte = COMPort.ReadByte
        '        RXArray(RXCnt) = LookUpTable(RXByte >> 4) ' Convert each byte to two hexadecimal characters
        '        RXCnt = RXCnt + 1
        '        RXArray(RXCnt) = LookUpTable(RXByte And 15)
        '        RXCnt = RXCnt + 1
        '        RXArray(RXCnt) = " "
        '        RXCnt = RXCnt + 1
        '        SpaceCount = (SpaceCount + 1) And 31      ' Insert spaces and CRLF for better readability
        '        If SpaceCount = 0 Then                    ' Insert CRLF after 32 numbers
        '            RXArray(RXCnt) = Chr(13) ' CR
        '            RXCnt = RXCnt + 1
        '            RXArray(RXCnt) = Chr(10) ' LF
        '            RXCnt = RXCnt + 1
        '        Else
        '            If (SpaceCount And 3) = 0 Then        ' Insert two extra spaces for each 4 numbers
        '                RXArray(RXCnt) = " "
        '                RXCnt = RXCnt + 1
        '                RXArray(RXCnt) = " "
        '                RXCnt = RXCnt + 1
        '            End If
        '        End If
        '    Loop Until (COMPort.BytesToRead = 0)
        '    '----- End of communication protocol handling -------------------------------------------------------------
        '    Me.Invoke(New MethodInvoker(AddressOf Display)) ' Start "Display" on the UI thread
        'Loop Until (COMPort.BytesToRead = 0)  ' Don't return if more bytes have become available in the meantime

        'Me.BeginInvoke(New StringSubPointer(AddressOf Display), COMPort.ReadLine)

        Try
            Dim i As String = SerialPort1.ReadLine
            PressureValue.Text = i


            If (i <> "Lunch confirmed") Then
                PressureValue.Text = "Launch NOT confirmed"
                ' Dim result2 As DialogResult
                ' result2 = MessageBox.Show("Arduino serial input not detected", "Warning!", MessageBoxButtons.OK)
            Else
                PressureValue.Text = "Launch confirmed"
                '  Dim result3 As DialogResult
                '  result3 = MessageBox.Show("Arduino serial input detected", "Success!", MessageBoxButtons.OK)
                '  LaunchConfirm.BringToFront()
            End If
        Catch ex As Exception
            Dim dialog As DialogResult
            dialog = MessageBox.Show(ex.Message)
            Console.WriteLine(ex)
            'LblValue.Text = ex.Message
            'LblValue.Text = "Exception caught!"
        End Try

    End Sub

    Private Sub Display(ByVal Buffer As String)
        PressureValue.Text = Buffer

    End Sub


    Private Sub LblValue_Click(sender As Object, e As EventArgs) Handles PressureValue.Click

    End Sub

    'Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
    '    LblValue.Text = "Timer working"

    '    Try
    '        Dim i As String = SerialPort1.ReadExisting
    '        LblValue.Text = i


    '        If (i <> " Lunch confirmed") Then
    '            ' LblValue.Text = "Launch NOT confirmed"
    '            ' Dim result2 As DialogResult
    '            ' result2 = MessageBox.Show("Arduino serial input not detected", "Warning!", MessageBoxButtons.OK)
    '        Else
    '            LblValue.Text = "Launch confirmed"
    '            '  Dim result3 As DialogResult
    '            '  result3 = MessageBox.Show("Arduino serial input detected", "Success!", MessageBoxButtons.OK)
    '            '  LaunchConfirm.BringToFront()
    '        End If
    '    Catch ex As Exception
    '        LblValue.Text = "Exception caught!"
    '    End Try
    'End Sub

    Private Sub CheckSerial_Click(sender As Object, e As EventArgs)
        SerialPort1.Write("Launch confirmed")
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Dim cancel As Byte
        cancel = Byte.Parse("20534F4152", System.Globalization.NumberStyles.HexNumber)
        SerialPort1.Write(cancel)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles CountdownLabel.Click

    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub

    Dim transmission As Boolean
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles StartData.Click
        ' start data transmission
        If Not transmission Then
            transmission = True
            StartData.Text = "Stop Data Transmission"
            Dim StartTransPacket(5) As Byte
            StartTransPacket(0) = Byte.Parse("0A", Globalization.NumberStyles.HexNumber)
            StartTransPacket(1) = Byte.Parse("00", Globalization.NumberStyles.HexNumber)
            StartTransPacket(2) = Byte.Parse("00", Globalization.NumberStyles.HexNumber)
            StartTransPacket(3) = Byte.Parse("00", Globalization.NumberStyles.HexNumber)
            StartTransPacket(4) = Byte.Parse("00", Globalization.NumberStyles.HexNumber)
            Dim i As Integer
            For i = 0 To 4
                dc.getCOMPort.Write(StartTransPacket(i))
            Next
            GraphTimer.Start()
            ' stop data transmission
        ElseIf transmission Then
            transmission = False
            StartData.Text = "Start Data Transmission"
            Dim StartTransPacket(5) As Byte
            StartTransPacket(0) = Byte.Parse("00", Globalization.NumberStyles.HexNumber)
            StartTransPacket(1) = Byte.Parse("00", Globalization.NumberStyles.HexNumber)
            StartTransPacket(2) = Byte.Parse("00", Globalization.NumberStyles.HexNumber)
            StartTransPacket(3) = Byte.Parse("00", Globalization.NumberStyles.HexNumber)
            StartTransPacket(4) = Byte.Parse("00", Globalization.NumberStyles.HexNumber)
            Dim i As Integer
            For i = 0 To 4
                dc.getCOMPort.Write(StartTransPacket(i))
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(sender As Object, e As EventArgs) Handles FolderBrowserDialog1.HelpRequest

    End Sub

    Private Sub Chart6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles ThrustValue.Click

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles ThermoTimer.Tick
        Dim thermalArray(11) As Single
        thermalArray(0) = dc.getDataPack().GetThermal(0)
        thermalArray(1) = dc.getDataPack().GetThermal(1)
        thermalArray(2) = dc.getDataPack().GetThermal(2)
        thermalArray(3) = dc.getDataPack().GetThermal(3)
        thermalArray(4) = dc.getDataPack().GetThermal(4)
        thermalArray(5) = dc.getDataPack().GetThermal(5)
        thermalArray(6) = dc.getDataPack().GetThermal(6)
        thermalArray(7) = dc.getDataPack().GetThermal(7)
        thermalArray(8) = dc.getDataPack().GetThermal(8)
        thermalArray(9) = dc.getDataPack().GetThermal(9)
        thermalArray(10) = dc.getDataPack().GetThermal(10)
        thermalArray(11) = dc.getDataPack().GetThermal(11)

        Dim i As Single = dc.getDataPack().GetThermoTime()
        Dim previousCount As Single = 0

        Label3.Text = "Average Thermocouple Temperature: " & ((thermalArray(0) + thermalArray(1) + thermalArray(2) + thermalArray(3) + thermalArray(4) + thermalArray(5) + thermalArray(6) + thermalArray(7) + thermalArray(8) + thermalArray(9) + thermalArray(10)) / 11)

        If (i <> previousCount) Then
            'update previous count
            previousCount = i

            Chart3.Series("Row1Avg").Points.AddY((thermalArray(0) + thermalArray(1) + thermalArray(2)) / 3)
            Chart3.Series("Row2Avg").Points.AddY((thermalArray(3) + thermalArray(4) + thermalArray(5)) / 3)
            Chart3.Series("Row3Avg").Points.AddY((thermalArray(6) + thermalArray(7) + thermalArray(8)) / 3)
            Chart3.Series("Bulkhead").Points.AddY(thermalArray(9))
            Chart3.Series("Probe").Points.AddY(thermalArray(10))

            Chart3.ChartAreas(0).AxisX.Maximum = XCount / 10
            Chart3.ChartAreas(0).AxisX.Minimum = XCount / 10 - 600
        End If

    End Sub
    Dim XCount As Single = 0
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles GraphTimer.Tick
        XCount += 1
    End Sub

    Private Sub Chart4_Click(sender As Object, e As EventArgs) Handles Chart4.Click

    End Sub
End Class
