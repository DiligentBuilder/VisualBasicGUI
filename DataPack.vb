Public Class DataPack
    'Variables to store data samples
    Private pressure As Double
    Private thrust As Double
    Private accelX As Double
    Private accelY As Double
    Private accelZ As Double
    Private thermalArray(11) As Double

    Private dataCount As UInteger
    Private thermalCount As UInteger
    Private timeToIgnition As Integer


    'GETTERS
    'gets the time to ignition
    Public Function GetCountdown()
        Return timeToIgnition
    End Function

    'gets the latest pressure data
    '0-3000psi
    Public Function GetPressure()
        Return pressure
    End Function

    'gets the latest thrust data
    '0-1000kg
    Public Function GetThrust()
        Return thrust
    End Function

    'gets the latest accelerometer X axis data
    '-6 to 6 gs
    Public Function GetAccelX()
        Return accelX
    End Function

    'gets the latest accelerometer Y axis data
    Public Function GetAccelY()
        Return accelY
    End Function

    'gets the latest accelerometer Z axis data
    Public Function GetAccelZ()
        Return accelZ
    End Function

    'gets the thermal data for the thermocouple indexed my index
    Public Function GetThermal(ByVal index As Integer)
        Return thermalArray(index)
    End Function

    'gets the time count for data samples
    Public Function GetDataTime()
        Return dataCount
    End Function

    'gets the time count for thermo samples
    Public Function GetThermoTime()
        Return thermalCount
    End Function


    'SETTERS
    Public Sub SetCountdown(ByVal c As Integer)
        timeToIgnition = c
    End Sub

    Public Sub SetPressure(ByVal p As Double)
        pressure = p
    End Sub

    Public Sub SetThrust(ByVal t As Double)
        thrust = t
    End Sub

    Public Sub SetAccelX(ByVal x As Double)
        accelX = x
    End Sub

    Public Sub SetAccelY(ByVal y As Double)
        accelY = y
    End Sub

    Public Sub SetAccelZ(ByVal z As Double)
        accelZ = z
    End Sub

    Public Sub SetThermal(ByVal t() As Double)
        thermalArray = t
    End Sub

    Public Sub SetDataTime(ByVal t As UInteger)
        dataCount = t
    End Sub

    Public Sub SetThermoTime(ByVal t As UInteger)
        thermalCount = t
    End Sub


End Class