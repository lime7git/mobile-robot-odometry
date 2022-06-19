<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Formularz przesłania metodę dispose, aby wyczyścić listę składników.
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

    'Wymagane przez Projektanta formularzy systemu Windows
    Private components As System.ComponentModel.IContainer

    'UWAGA: następująca procedura jest wymagana przez Projektanta formularzy systemu Windows
    'Możesz to modyfikować, używając Projektanta formularzy systemu Windows. 
    'Nie należy modyfikować za pomocą edytora kodu.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.initButton = New System.Windows.Forms.Button()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.writeButton = New System.Windows.Forms.Button()
        Me.inputTextBox = New System.Windows.Forms.RichTextBox()
        Me.outputTextBox = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.portComboBox = New System.Windows.Forms.ComboBox()
        Me.baudComboBox = New System.Windows.Forms.ComboBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.wykres = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.clearButton = New System.Windows.Forms.Button()
        Me.LOG_CHECK = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.x_act = New System.Windows.Forms.RichTextBox()
        Me.y_act = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.next_button = New System.Windows.Forms.Button()
        Me.save_chart = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.new_y = New System.Windows.Forms.RichTextBox()
        Me.new_x = New System.Windows.Forms.RichTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.add_buton = New System.Windows.Forms.Button()
        Me.realpos_check = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.act_ang = New System.Windows.Forms.RichTextBox()
        Me.add_n_run = New System.Windows.Forms.Button()
        Me.run_point_button = New System.Windows.Forms.Button()
        Me.new_ang = New System.Windows.Forms.RichTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ang_button = New System.Windows.Forms.Button()
        CType(Me.wykres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'initButton
        '
        Me.initButton.Location = New System.Drawing.Point(558, 35)
        Me.initButton.Name = "initButton"
        Me.initButton.Size = New System.Drawing.Size(75, 23)
        Me.initButton.TabIndex = 0
        Me.initButton.Text = "Init"
        Me.initButton.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(559, 74)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 1
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'writeButton
        '
        Me.writeButton.Location = New System.Drawing.Point(301, 32)
        Me.writeButton.Name = "writeButton"
        Me.writeButton.Size = New System.Drawing.Size(75, 23)
        Me.writeButton.TabIndex = 2
        Me.writeButton.Text = "Write"
        Me.writeButton.UseVisualStyleBackColor = True
        '
        'inputTextBox
        '
        Me.inputTextBox.Location = New System.Drawing.Point(26, 33)
        Me.inputTextBox.Name = "inputTextBox"
        Me.inputTextBox.Size = New System.Drawing.Size(257, 63)
        Me.inputTextBox.TabIndex = 3
        Me.inputTextBox.Text = ""
        '
        'outputTextBox
        '
        Me.outputTextBox.Location = New System.Drawing.Point(12, 147)
        Me.outputTextBox.Name = "outputTextBox"
        Me.outputTextBox.Size = New System.Drawing.Size(271, 694)
        Me.outputTextBox.TabIndex = 4
        Me.outputTextBox.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Input"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Output"
        '
        'portComboBox
        '
        Me.portComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.portComboBox.FormattingEnabled = True
        Me.portComboBox.Location = New System.Drawing.Point(407, 33)
        Me.portComboBox.Name = "portComboBox"
        Me.portComboBox.Size = New System.Drawing.Size(121, 24)
        Me.portComboBox.TabIndex = 7
        '
        'baudComboBox
        '
        Me.baudComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.baudComboBox.FormattingEnabled = True
        Me.baudComboBox.Items.AddRange(New Object() {"11520"})
        Me.baudComboBox.Location = New System.Drawing.Point(407, 74)
        Me.baudComboBox.Name = "baudComboBox"
        Me.baudComboBox.Size = New System.Drawing.Size(121, 24)
        Me.baudComboBox.TabIndex = 8
        '
        'SerialPort1
        '
        '
        'wykres
        '
        ChartArea2.Name = "ChartArea1"
        Me.wykres.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.wykres.Legends.Add(Legend2)
        Me.wykres.Location = New System.Drawing.Point(289, 147)
        Me.wykres.Name = "wykres"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.wykres.Series.Add(Series2)
        Me.wykres.Size = New System.Drawing.Size(872, 694)
        Me.wykres.TabIndex = 9
        Me.wykres.Text = "Chart1"
        '
        'clearButton
        '
        Me.clearButton.Location = New System.Drawing.Point(208, 118)
        Me.clearButton.Name = "clearButton"
        Me.clearButton.Size = New System.Drawing.Size(75, 23)
        Me.clearButton.TabIndex = 11
        Me.clearButton.Text = "Clear"
        Me.clearButton.UseVisualStyleBackColor = True
        '
        'LOG_CHECK
        '
        Me.LOG_CHECK.AutoSize = True
        Me.LOG_CHECK.Location = New System.Drawing.Point(371, 118)
        Me.LOG_CHECK.Name = "LOG_CHECK"
        Me.LOG_CHECK.Size = New System.Drawing.Size(60, 21)
        Me.LOG_CHECK.TabIndex = 13
        Me.LOG_CHECK.Text = "LOG"
        Me.LOG_CHECK.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1006, 482)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Actual mouse postion"
        '
        'x_act
        '
        Me.x_act.Location = New System.Drawing.Point(1052, 514)
        Me.x_act.Name = "x_act"
        Me.x_act.Size = New System.Drawing.Size(86, 27)
        Me.x_act.TabIndex = 15
        Me.x_act.Text = ""
        '
        'y_act
        '
        Me.y_act.Location = New System.Drawing.Point(1052, 547)
        Me.y_act.Name = "y_act"
        Me.y_act.Size = New System.Drawing.Size(86, 27)
        Me.y_act.TabIndex = 16
        Me.y_act.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1029, 517)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 17)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "X"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1029, 553)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 17)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Y"
        '
        'next_button
        '
        Me.next_button.Location = New System.Drawing.Point(1007, 633)
        Me.next_button.Name = "next_button"
        Me.next_button.Size = New System.Drawing.Size(142, 64)
        Me.next_button.TabIndex = 19
        Me.next_button.Text = "RUN TO NEXT POINT"
        Me.next_button.UseVisualStyleBackColor = True
        '
        'save_chart
        '
        Me.save_chart.Location = New System.Drawing.Point(1007, 717)
        Me.save_chart.Name = "save_chart"
        Me.save_chart.Size = New System.Drawing.Size(142, 57)
        Me.save_chart.TabIndex = 20
        Me.save_chart.Text = "SAVE CHART AS .BMP"
        Me.save_chart.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(645, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 17)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Y"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(645, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 17)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "X"
        '
        'new_y
        '
        Me.new_y.Location = New System.Drawing.Point(668, 68)
        Me.new_y.Name = "new_y"
        Me.new_y.Size = New System.Drawing.Size(103, 27)
        Me.new_y.TabIndex = 22
        Me.new_y.Text = ""
        '
        'new_x
        '
        Me.new_x.Location = New System.Drawing.Point(668, 35)
        Me.new_x.Name = "new_x"
        Me.new_x.Size = New System.Drawing.Size(103, 27)
        Me.new_x.TabIndex = 21
        Me.new_x.Text = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(645, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 17)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Add point n run point"
        '
        'add_buton
        '
        Me.add_buton.Location = New System.Drawing.Point(777, 35)
        Me.add_buton.Name = "add_buton"
        Me.add_buton.Size = New System.Drawing.Size(67, 56)
        Me.add_buton.TabIndex = 26
        Me.add_buton.Text = "ADD"
        Me.add_buton.UseVisualStyleBackColor = True
        '
        'realpos_check
        '
        Me.realpos_check.AutoSize = True
        Me.realpos_check.Location = New System.Drawing.Point(668, 101)
        Me.realpos_check.Name = "realpos_check"
        Me.realpos_check.Size = New System.Drawing.Size(99, 21)
        Me.realpos_check.TabIndex = 27
        Me.realpos_check.Text = "REAL POS"
        Me.realpos_check.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1008, 583)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 17)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "ANG"
        '
        'act_ang
        '
        Me.act_ang.Location = New System.Drawing.Point(1052, 580)
        Me.act_ang.Name = "act_ang"
        Me.act_ang.Size = New System.Drawing.Size(86, 27)
        Me.act_ang.TabIndex = 28
        Me.act_ang.Text = ""
        '
        'add_n_run
        '
        Me.add_n_run.Location = New System.Drawing.Point(861, 2)
        Me.add_n_run.Name = "add_n_run"
        Me.add_n_run.Size = New System.Drawing.Size(86, 56)
        Me.add_n_run.TabIndex = 30
        Me.add_n_run.Text = "ADDnRUN"
        Me.add_n_run.UseVisualStyleBackColor = True
        '
        'run_point_button
        '
        Me.run_point_button.Location = New System.Drawing.Point(861, 64)
        Me.run_point_button.Name = "run_point_button"
        Me.run_point_button.Size = New System.Drawing.Size(86, 56)
        Me.run_point_button.TabIndex = 31
        Me.run_point_button.Text = "RUN"
        Me.run_point_button.UseVisualStyleBackColor = True
        '
        'new_ang
        '
        Me.new_ang.Location = New System.Drawing.Point(1020, 52)
        Me.new_ang.Name = "new_ang"
        Me.new_ang.Size = New System.Drawing.Size(69, 27)
        Me.new_ang.TabIndex = 32
        Me.new_ang.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(976, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(142, 17)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Turn ang (+- 0 - 180)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(976, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 17)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "ANG"
        '
        'ang_button
        '
        Me.ang_button.Location = New System.Drawing.Point(1095, 38)
        Me.ang_button.Name = "ang_button"
        Me.ang_button.Size = New System.Drawing.Size(75, 52)
        Me.ang_button.TabIndex = 35
        Me.ang_button.Text = "TURN"
        Me.ang_button.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 853)
        Me.Controls.Add(Me.ang_button)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.new_ang)
        Me.Controls.Add(Me.run_point_button)
        Me.Controls.Add(Me.add_n_run)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.act_ang)
        Me.Controls.Add(Me.realpos_check)
        Me.Controls.Add(Me.add_buton)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.new_y)
        Me.Controls.Add(Me.new_x)
        Me.Controls.Add(Me.save_chart)
        Me.Controls.Add(Me.next_button)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.y_act)
        Me.Controls.Add(Me.x_act)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LOG_CHECK)
        Me.Controls.Add(Me.clearButton)
        Me.Controls.Add(Me.wykres)
        Me.Controls.Add(Me.baudComboBox)
        Me.Controls.Add(Me.portComboBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.outputTextBox)
        Me.Controls.Add(Me.inputTextBox)
        Me.Controls.Add(Me.writeButton)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.initButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.wykres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents initButton As Button
    Friend WithEvents closeButton As Button
    Friend WithEvents writeButton As Button
    Friend WithEvents inputTextBox As RichTextBox
    Friend WithEvents outputTextBox As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents portComboBox As ComboBox
    Friend WithEvents baudComboBox As ComboBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents wykres As DataVisualization.Charting.Chart
    Friend WithEvents clearButton As Button
    Friend WithEvents LOG_CHECK As CheckBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents x_act As RichTextBox
    Friend WithEvents y_act As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents next_button As Button
    Friend WithEvents save_chart As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents new_y As RichTextBox
    Friend WithEvents new_x As RichTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents add_buton As Button
    Friend WithEvents realpos_check As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents act_ang As RichTextBox
    Friend WithEvents add_n_run As Button
    Friend WithEvents run_point_button As Button
    Friend WithEvents new_ang As RichTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents ang_button As Button
End Class
