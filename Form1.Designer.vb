<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series9 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series10 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series11 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.BtnScanPort = New System.Windows.Forms.Button()
        Me.Launch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbBaud = New System.Windows.Forms.ComboBox()
        Me.CmbPort = New System.Windows.Forms.ComboBox()
        Me.BtnCon = New System.Windows.Forms.Button()
        Me.BtnDiscon = New System.Windows.Forms.Button()
        Me.NonThermoTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PressureValue = New System.Windows.Forms.Label()
        Me.LaunchConfirm = New System.Windows.Forms.Button()
        Me.NotLaunchedYet = New System.Windows.Forms.Label()
        Me.ThermoTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.CountdownLabel = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart4 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.StartData = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ThrustValue = New System.Windows.Forms.Label()
        Me.GraphTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnScanPort
        '
        Me.BtnScanPort.Location = New System.Drawing.Point(12, 12)
        Me.BtnScanPort.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnScanPort.Name = "BtnScanPort"
        Me.BtnScanPort.Size = New System.Drawing.Size(160, 92)
        Me.BtnScanPort.TabIndex = 0
        Me.BtnScanPort.Text = "Scan Port"
        Me.BtnScanPort.UseVisualStyleBackColor = True
        '
        'Launch
        '
        Me.Launch.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Launch.Location = New System.Drawing.Point(32, 308)
        Me.Launch.Margin = New System.Windows.Forms.Padding(4)
        Me.Launch.Name = "Launch"
        Me.Launch.Size = New System.Drawing.Size(264, 146)
        Me.Launch.TabIndex = 1
        Me.Launch.Text = "Ignite"
        Me.Launch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(338, 35)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 25)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Baud Rate"
        '
        'CmbBaud
        '
        Me.CmbBaud.FormattingEnabled = True
        Me.CmbBaud.Items.AddRange(New Object() {"19200", "38400", "57600", "115200"})
        Me.CmbBaud.Location = New System.Drawing.Point(456, 35)
        Me.CmbBaud.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbBaud.Name = "CmbBaud"
        Me.CmbBaud.Size = New System.Drawing.Size(120, 33)
        Me.CmbBaud.TabIndex = 7
        '
        'CmbPort
        '
        Me.CmbPort.FormattingEnabled = True
        Me.CmbPort.Location = New System.Drawing.Point(198, 35)
        Me.CmbPort.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbPort.Name = "CmbPort"
        Me.CmbPort.Size = New System.Drawing.Size(120, 33)
        Me.CmbPort.TabIndex = 8
        '
        'BtnCon
        '
        Me.BtnCon.Location = New System.Drawing.Point(12, 112)
        Me.BtnCon.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnCon.Name = "BtnCon"
        Me.BtnCon.Size = New System.Drawing.Size(188, 54)
        Me.BtnCon.TabIndex = 9
        Me.BtnCon.Text = "Connect"
        Me.BtnCon.UseVisualStyleBackColor = True
        '
        'BtnDiscon
        '
        Me.BtnDiscon.Location = New System.Drawing.Point(12, 112)
        Me.BtnDiscon.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDiscon.Name = "BtnDiscon"
        Me.BtnDiscon.Size = New System.Drawing.Size(188, 54)
        Me.BtnDiscon.TabIndex = 10
        Me.BtnDiscon.Text = "Disconnect"
        Me.BtnDiscon.UseVisualStyleBackColor = True
        '
        'NonThermoTimer
        '
        Me.NonThermoTimer.Interval = 10
        '
        'PressureValue
        '
        Me.PressureValue.AutoSize = True
        Me.PressureValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PressureValue.Location = New System.Drawing.Point(656, 423)
        Me.PressureValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PressureValue.Name = "PressureValue"
        Me.PressureValue.Size = New System.Drawing.Size(412, 51)
        Me.PressureValue.TabIndex = 11
        Me.PressureValue.Text = "Pressure Value: 000"
        '
        'LaunchConfirm
        '
        Me.LaunchConfirm.Location = New System.Drawing.Point(36, 308)
        Me.LaunchConfirm.Margin = New System.Windows.Forms.Padding(4)
        Me.LaunchConfirm.Name = "LaunchConfirm"
        Me.LaunchConfirm.Size = New System.Drawing.Size(164, 112)
        Me.LaunchConfirm.TabIndex = 12
        Me.LaunchConfirm.Text = "Confirm launch"
        Me.LaunchConfirm.UseVisualStyleBackColor = True
        '
        'NotLaunchedYet
        '
        Me.NotLaunchedYet.AutoSize = True
        Me.NotLaunchedYet.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NotLaunchedYet.Location = New System.Drawing.Point(2, 167)
        Me.NotLaunchedYet.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.NotLaunchedYet.Name = "NotLaunchedYet"
        Me.NotLaunchedYet.Size = New System.Drawing.Size(437, 61)
        Me.NotLaunchedYet.TabIndex = 13
        Me.NotLaunchedYet.Text = "Not launched yet!"
        '
        'ThermoTimer
        '
        Me.ThermoTimer.Interval = 1000
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.Coral
        Me.ButtonCancel.ForeColor = System.Drawing.Color.DarkRed
        Me.ButtonCancel.Location = New System.Drawing.Point(36, 308)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(164, 113)
        Me.ButtonCancel.TabIndex = 17
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = False
        '
        'CountdownLabel
        '
        Me.CountdownLabel.AutoSize = True
        Me.CountdownLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountdownLabel.ForeColor = System.Drawing.Color.Crimson
        Me.CountdownLabel.Location = New System.Drawing.Point(-4, 229)
        Me.CountdownLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CountdownLabel.Name = "CountdownLabel"
        Me.CountdownLabel.Size = New System.Drawing.Size(653, 61)
        Me.CountdownLabel.TabIndex = 18
        Me.CountdownLabel.Text = "Countdown to Launch: N/A"
        '
        'Chart1
        '
        ChartArea1.AxisX.Title = "Time in seconds"
        ChartArea1.AxisY.Title = "Pressure in psi"
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(656, 52)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(4)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(666, 369)
        Me.Chart1.TabIndex = 19
        Me.Chart1.Text = "Pressure"
        Me.Chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault
        Title1.Name = "Pressure"
        Title1.Text = "Pressure"
        Me.Chart1.Titles.Add(Title1)
        '
        'Chart2
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend1.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend1)
        Me.Chart2.Location = New System.Drawing.Point(1484, 52)
        Me.Chart2.Margin = New System.Windows.Forms.Padding(4)
        Me.Chart2.Name = "Chart2"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Series2.YValuesPerPoint = 2
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(620, 348)
        Me.Chart2.TabIndex = 20
        Me.Chart2.Text = "Chart2"
        '
        'Chart3
        '
        ChartArea3.Name = "ChartArea1"
        Me.Chart3.ChartAreas.Add(ChartArea3)
        Legend2.Name = "Legend1"
        Me.Chart3.Legends.Add(Legend2)
        Me.Chart3.Location = New System.Drawing.Point(1484, 548)
        Me.Chart3.Margin = New System.Windows.Forms.Padding(4)
        Me.Chart3.Name = "Chart3"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.Legend = "Legend1"
        Series3.Name = "Row1Avg"
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series4.Legend = "Legend1"
        Series4.Name = "Row2Avg"
        Series5.ChartArea = "ChartArea1"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series5.Legend = "Legend1"
        Series5.Name = "Row3Avg"
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series6.Legend = "Legend1"
        Series6.Name = "Bulkhead"
        Series7.ChartArea = "ChartArea1"
        Series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series7.Legend = "Legend1"
        Series7.Name = "Probe"
        Me.Chart3.Series.Add(Series3)
        Me.Chart3.Series.Add(Series4)
        Me.Chart3.Series.Add(Series5)
        Me.Chart3.Series.Add(Series6)
        Me.Chart3.Series.Add(Series7)
        Me.Chart3.Size = New System.Drawing.Size(620, 388)
        Me.Chart3.TabIndex = 21
        Me.Chart3.Text = "Chart3"
        '
        'Chart4
        '
        ChartArea4.Name = "ChartArea1"
        Me.Chart4.ChartAreas.Add(ChartArea4)
        Legend3.Name = "Legend1"
        Me.Chart4.Legends.Add(Legend3)
        Me.Chart4.Location = New System.Drawing.Point(658, 552)
        Me.Chart4.Margin = New System.Windows.Forms.Padding(4)
        Me.Chart4.Name = "Chart4"
        Series8.ChartArea = "ChartArea1"
        Series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series8.Legend = "Legend1"
        Series8.Name = "AccelX"
        Series9.ChartArea = "ChartArea1"
        Series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series9.Legend = "Legend1"
        Series9.Name = "AccelY"
        Series10.ChartArea = "ChartArea1"
        Series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series10.Legend = "Legend1"
        Series10.Name = "AccelZ"
        Series11.ChartArea = "ChartArea1"
        Series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series11.Legend = "Legend1"
        Series11.Name = "AccelMag"
        Me.Chart4.Series.Add(Series8)
        Me.Chart4.Series.Add(Series9)
        Me.Chart4.Series.Add(Series10)
        Me.Chart4.Series.Add(Series11)
        Me.Chart4.Size = New System.Drawing.Size(600, 387)
        Me.Chart4.TabIndex = 22
        Me.Chart4.Text = "Chart4"
        Title2.Name = "Accelerometer Values"
        Title2.Text = "Accelerometer Values"
        Title3.Name = "Title1"
        Me.Chart4.Titles.Add(Title2)
        Me.Chart4.Titles.Add(Title3)
        '
        'StartData
        '
        Me.StartData.Location = New System.Drawing.Point(36, 487)
        Me.StartData.Margin = New System.Windows.Forms.Padding(4)
        Me.StartData.Name = "StartData"
        Me.StartData.Size = New System.Drawing.Size(260, 171)
        Me.StartData.TabIndex = 25
        Me.StartData.Text = "Start Data Transmission"
        Me.StartData.UseVisualStyleBackColor = True
        '
        'FolderBrowserDialog1
        '
        '
        'ThrustValue
        '
        Me.ThrustValue.AutoSize = True
        Me.ThrustValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ThrustValue.Location = New System.Drawing.Point(1474, 413)
        Me.ThrustValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ThrustValue.Name = "ThrustValue"
        Me.ThrustValue.Size = New System.Drawing.Size(361, 51)
        Me.ThrustValue.TabIndex = 26
        Me.ThrustValue.Text = "Thrust Value: 000"
        '
        'GraphTimer
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(656, 971)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(569, 51)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Acceleration Magnitude: 000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1380, 983)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(822, 51)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Average Thermocouple Temperature: 000"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(2404, 1165)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ThrustValue)
        Me.Controls.Add(Me.Chart4)
        Me.Controls.Add(Me.Chart3)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.CountdownLabel)
        Me.Controls.Add(Me.Launch)
        Me.Controls.Add(Me.NotLaunchedYet)
        Me.Controls.Add(Me.PressureValue)
        Me.Controls.Add(Me.BtnCon)
        Me.Controls.Add(Me.CmbPort)
        Me.Controls.Add(Me.CmbBaud)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnScanPort)
        Me.Controls.Add(Me.BtnDiscon)
        Me.Controls.Add(Me.LaunchConfirm)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.StartData)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnScanPort As Button
    Friend WithEvents Launch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbBaud As ComboBox
    Friend WithEvents CmbPort As ComboBox
    Friend WithEvents BtnCon As Button
    Friend WithEvents BtnDiscon As Button
    Friend WithEvents NonThermoTimer As Timer
    ' Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents PressureValue As Label
    Friend WithEvents LaunchConfirm As Button
    Friend WithEvents NotLaunchedYet As Label
    Friend WithEvents ThermoTimer As Timer
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents ButtonCancel As Button
    Friend WithEvents CountdownLabel As Label
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Chart3 As DataVisualization.Charting.Chart
    Friend WithEvents Chart4 As DataVisualization.Charting.Chart
    Friend WithEvents StartData As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ThrustValue As Label
    Friend WithEvents GraphTimer As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
