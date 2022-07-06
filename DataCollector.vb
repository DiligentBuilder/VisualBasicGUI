Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing
Imports System.Collections.Generic
Imports System.BitConverter
Imports Microsoft.VisualBasic.FileIO
Imports DataPack

Public Class DataCollector
    Inherits Form

    'DATA
    '-----------------------------------------------------------------

    'Not sure exactly what a delegate is but its needed for the events to work properly
    Public Delegate Sub StringSubPointer()


    'SerialPort object handles data reception
    Dim WithEvents COMPort As New SerialPort

    'Another delegate that makes the events work
    Private COMDelegate As New SerialDataReceivedEventHandler(AddressOf Receiver)

    'most up to date data for each sensor
    Private currentPressure As Double
    Private currentThrust As Double
    Private currentAccelX As Double
    Private currentAccelY As Double
    Private currentAccelZ As Double

    'Array stores thermal data since only one sample is transferred at a time
    Private thermoArray(11) As Double

    'Enumeration for the type of packet being read
    Enum packetTypeEnum
        DATA = 0
        SENSOR = 1
        IGNITION = 2
        IGNITION_STATUS = 3
    End Enum

    Private packetType As Integer

    'stores the number of bytes that still need to be read
    Private bytesToRead As Integer

    'determines if incoming data will be written to a file
    'default state is false
    Private writeToFile As Boolean

    'main buffer of largest possible packet size (32)
    Private packetBuffer(32) As Byte

    'prevents events from firing when data is being read
    Private skipEvent As Boolean

    'tracks the amount of time left in the countdown
    Private timeToIgnition As Integer

    'file directory for data files to be written to
    Private fileDirectory As String

    'timing counter for data samples
    Private dataTime As UInteger

    'timing counter for thermocouple samples
    Private thermoTime As UInteger


    'FUNCTIONS
    '------------------------------------------------------

    'CONSTRUCTOR
    'use to modify directory 
    Public Sub New()
        'asks what COM Port the ardiuno is on
        'Console.Write("Enter COM Port: ")
        'COMPort.PortName = Console.ReadLine()
        'Me.SetPort("COM6")

        COMPort.BaudRate = 115200
        'sets the baud rate

        COMPort.ReadTimeout = 2000

        'COMPort.ReadBufferSize = 8192

        skipEvent = False
        bytesToRead = 0

        'will be set to false but is true for testing
        writeToFile = True

        'Sets the data path for testing
        Me.SetDirectory("C:\launch_data\")

        dataTime = 0
        thermoTime = 0

        'Console.WriteLine(COMPort.ReadBufferSize)

        'COMPort.Open()

        'creates handler for the events
        If Not IsHandleCreated Then Me.CreateControl()

        'creates a window
        FormBorderStyle = FormBorderStyle.None
        ClientSize = New Size(50, 50)
        Text = "DO NOT CLOSE"
    End Sub

    'function which handles the datareceived event
    Private Sub Receiver(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles COMPort.DataReceived
        If skipEvent = False Then
            skipEvent = True
            Me.BeginInvoke(New StringSubPointer(AddressOf DataHandler))
            'calls a thread to handle the processing after the second argument is executed
        End If
    End Sub


    'Function called from the receivedDataEvent Handler to read bytes into the packetBuffer
    Private Sub DataHandler()

        'variable used to skip the sorting algorithm if a bad header is read
        'helps prevent crashes when parsing data
        Dim skipSort As Boolean
        skipSort = False

        'converts the next byte from an int to a byte
        'done because of weird return types on serialport
        Dim receivedByte As Byte = System.Convert.ToByte(COMPort.ReadByte())


        'command = first halfbyte, argument = second halfbyte
        Dim command As Byte = receivedByte
        Dim argument As Byte = receivedByte


        'VISUAL BASIC DOESNT SUPPORT HEX LITERALS???

        'extracts command and argument
        command = command And 240   '0xF0 = 240
        command = command >> 4
        argument = argument And 15  '0x0F = 15


        'wrote cases for data and ignition packets before i knew i didnt need to handle them
        Select Case command
            Case 0
                packetType = packetTypeEnum.DATA
                bytesToRead = 4
            Case 1
                packetType = packetTypeEnum.SENSOR
                If argument = 8 Then
                    bytesToRead = 31
                Else
                    bytesToRead = 29
                End If
            Case 2
                packetType = packetTypeEnum.IGNITION
                bytesToRead = 3
            Case 3
                packetType = packetTypeEnum.IGNITION_STATUS
                bytesToRead = 1
            Case Else
        End Select


        'reads the following bytes after a header byte into the main buffer
        'NOTE: reads the data in backwards starting at the bytesToRead value assigned above
        'NOTE cont.: this is stupid, but it doesnt make it any more difficult to parse and saves me from having to do extra math
        For i As Integer = bytesToRead To 0 Step -1

            receivedByte = Convert.ToByte(COMPort.ReadByte())
            packetBuffer(i) = receivedByte

        Next

        SortBuffer()

        'resets the skipEvent flag and bytesToRead
        bytesToRead = 0
        skipEvent = False

        'stupid workaround to get it to run the event code again if there are new packets
        'in order for it to not drop data, i have to stop it from raising events while reading data
        'if i stop it from raising events it wont deal with the next packet
        'If COMPort.BytesToRead > 0  And skipSort = True Then
        '    Me.BeginInvoke(New StringSubPointer(AddressOf DataHandler))
        'End If

    End Sub


    'Function that parses the data in the packetBuffer into the correct data structures
    Private Sub SortBuffer()
        If packetType = packetTypeEnum.SENSOR Then
            Dim sampleBytes(2) As Byte 'temporary storage to convert a sample to an int
            Dim sampleData As Short    'temporary int to conert to a double
            Dim convertedData As Double
            Dim c As UInteger          'used in packet parsing algorithm due to the odd byte splitting
            Dim sensor As UInteger     'tracks which sensor a sample goes with
            Dim thermoNum As Byte  'tracks whcih thermocouple a sample is from

            c = 1
            sensor = 0

            Console.WriteLine("In Buffer: " + Convert.ToString(COMPort.BytesToRead))

            If bytesToRead <> 0 Then
                'reads one sample at a time from the packetBuffer
                For i As Integer = bytesToRead To 0 Step -1

                    'separates the bytes properly
                    If c Mod 2 <> 0 Then
                        sampleBytes(1) = packetBuffer(i)
                        sampleBytes(0) = packetBuffer(i - 1)
                        sampleBytes(0) = sampleBytes(0) And 240
                        sampleBytes(0) = sampleBytes(0) >> 4
                        Dim temp As Byte = sampleBytes(1) And 15
                        temp = temp << 4
                        sampleBytes(0) = sampleBytes(0) Or temp
                        sampleBytes(1) = sampleBytes(1) And 240
                        sampleBytes(1) = sampleBytes(1) >> 4
                        thermoNum = packetBuffer(i - 1)
                        thermoNum = thermoNum And 15

                        i = i - 1
                    Else
                        sampleBytes(1) = packetBuffer(i + 1)
                        sampleBytes(0) = packetBuffer(i)
                        sampleBytes(1) = sampleBytes(1) And 15
                    End If


                    'gets the integer value captured by the daq should be +-2047
                    sampleData = BitConverter.ToInt16(sampleBytes, 0)

                    'converts the sample to a value in volts for further processing
                    '204.7 is the scaling factor since 2047/207.4 = 10
                    convertedData = sampleData / 204.7

                    'converts and adds the sample to the correct sensor's queue
                    If sensor = 0 Then       'case for gauge pressure (PSI)

                        'conversion factor from (3000-0psi)/(10-2V)
                        convertedData = 375.0 * (convertedData - 2)

                        If writeToFile Then
                            My.Computer.FileSystem.WriteAllText(fileDirectory + "gauge_pressure.txt", Convert.ToString(dataTime) + ": " + Convert.ToString(convertedData) + vbNewLine, True)
                        End If

                        currentPressure = convertedData

                    ElseIf sensor = 1 Then  'case for thrust cell

                        'conversion factor of 111.11 kg/V
                        convertedData = 111.11111 * convertedData

                        If writeToFile Then
                            My.Computer.FileSystem.WriteAllText(fileDirectory + "load_cell.txt", Convert.ToString(dataTime) + ": " + Convert.ToString(convertedData) + vbNewLine, True)
                        End If

                        currentThrust = convertedData

                    ElseIf sensor = 2 Then  'case for accelerometer X
                        'acceleration is negative from 1V to 5V and positive from 5V to 9V
                        'output is in gs
                        convertedData = (convertedData - 5) * 1.5

                        If writeToFile Then
                            My.Computer.FileSystem.WriteAllText(fileDirectory + "accelerometer_X.txt", Convert.ToString(dataTime) + ": " + Convert.ToString(convertedData) + vbNewLine, True)
                        End If

                        currentAccelX = convertedData

                    ElseIf sensor = 3 Then  'case for accelerometer Y
                        'same scaling as X axis
                        convertedData = (convertedData - 5) * 1.5

                        If writeToFile Then
                            My.Computer.FileSystem.WriteAllText(fileDirectory + "accelerometer_Y.txt", Convert.ToString(dataTime) + ": " + Convert.ToString(convertedData) + vbNewLine, True)
                        End If

                        currentAccelY = convertedData

                    ElseIf sensor = 4 Then  'case for accelerometer Z
                        'same scaling as X axis
                        convertedData = (convertedData - 5) * 1.5

                        If writeToFile Then
                            My.Computer.FileSystem.WriteAllText(fileDirectory + "accelerometer_Z.txt", Convert.ToString(dataTime) + ": " + Convert.ToString(convertedData) + vbNewLine, True)
                        End If

                        currentAccelZ = convertedData

                    Else   'case for Thermocouple
                        'T(Celsius) = (Vout-1.25)/5mV
                        convertedData = (convertedData - 1.25) / 0.005

                        If writeToFile Then
                            My.Computer.FileSystem.WriteAllText(fileDirectory + "thermocouple.txt", "t = " + Convert.ToString(thermoTime) + ", " + Convert.ToString(Convert.ToInt32(thermoNum)) + ": " + Convert.ToString(convertedData) + vbNewLine, True)
                        End If

                        thermoTime = thermoTime + 1
                        If thermoNum > 11 Or thermoNum < 0 Then
                            thermoNum = 0
                        End If
                        thermoArray(Convert.ToInt32(thermoNum)) = convertedData

                    End If

                    'Determines which sensor a sample is from
                    If bytesToRead = 31 And i < 3 Then
                        sensor = 5
                    ElseIf sensor = 4 Then
                        sensor = 0
                        dataTime = dataTime + 1
                    Else
                        sensor = sensor + 1
                    End If
                    c = c + 1
                Next

            End If

        Else
            Dim ignitionBytes(4) As Byte
            ignitionBytes(3) = 0
            ignitionBytes(2) = 0
            ignitionBytes(1) = packetBuffer(1)
            ignitionBytes(0) = packetBuffer(0)

            timeToIgnition = BitConverter.ToInt32(ignitionBytes, 0)
        End If

    End Sub

    'closes the COMPort when the Form(window) the DataCollector is contained in closes
    Private Sub CloseForm(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If COMPort.IsOpen Then COMPort.Close()
    End Sub

    'sets the COMPort using a string containing the name ex: "COM5"
    Public Sub SetPort(ByVal port As String)
        COMPort.PortName = port
    End Sub

    'Toggles saving data to file on and off
    'returns the writeToFile state after being toggled
    Public Function ToggleWriteToFile()
        writeToFile = Not writeToFile
        Return writeToFile
    End Function

    'sets the file directory to write data to
    Public Sub SetDirectory(ByVal dir As String)
        fileDirectory = dir
    End Sub

    'returns a reference to the SerialPort object COMPort
    Public Function getCOMPort()
        Return COMPort
    End Function

    Public Sub openPort()
        'opens the COMPort
        Try
            COMPort.Open()

            'I dont think leftover data from a previous run could be in the buffer, but just in case
            COMPort.DiscardInBuffer()
        Catch ex As Exception
            MsgBox(ex.Message)
            'creates a message box with the error
        End Try

    End Sub


    'creates a DataPack object and returns it
    'ensures consistency in data (probably)
    Public Function getDataPack()
        Dim dp As New DataPack
        dp.SetCountdown(timeToIgnition)
        dp.SetPressure(currentPressure)
        dp.SetThrust(currentThrust)
        dp.SetAccelX(currentAccelX)
        dp.SetAccelY(currentAccelY)
        dp.SetAccelZ(currentAccelZ)
        dp.SetThermal(thermoArray)
        dp.SetDataTime(dataTime)
        dp.SetThermoTime(thermoTime)

        Return dp

    End Function


    'MAIN, COMMENT OUT IF THIS IS NOT THE ONLY FILE
    <System.STAThreadAttribute()> Public Shared Sub Main()
        'System.Threading.Thread.CurrentThread.ApartmentState = System.Threading.ApartmentState.STA
        System.Threading.Thread.CurrentThread.SetApartmentState(System.Threading.ApartmentState.STA)

        Application.Run(New DataCollector())
    End Sub 'Main

End Class

