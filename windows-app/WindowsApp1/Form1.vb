Imports System
Imports System.Threading
Imports System.IO
Imports System.IO.Ports
Imports System.ComponentModel
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Dim logger_flag As Boolean = False
    Dim xyData() As String

    Dim number_of_points As Integer = 1

    Dim myPort As Array
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SerialPort1.Close()
        myPort = IO.Ports.SerialPort.GetPortNames()
        portComboBox.Items.AddRange(myPort)
        writeButton.Enabled = False
        closeButton.Enabled = False
        run_point_button.Enabled = False
        next_button.Enabled = False
        add_n_run.Enabled = False
        ang_button.Enabled = False
        portComboBox.SelectedItem = "COM5"
        baudComboBox.SelectedItem = "11520"

        Me.wykres.ChartAreas(0).AxisX.Minimum = -1500
        Me.wykres.ChartAreas(0).AxisX.Maximum = 1500
        Me.wykres.ChartAreas(0).AxisY.Minimum = -1500
        Me.wykres.ChartAreas(0).AxisY.Maximum = 1500
        Me.wykres.ChartAreas(0).AxisX.Title = "X [mm]"
        Me.wykres.ChartAreas(0).AxisY.Title = "Y [mm]"
        Me.wykres.ChartAreas(0).AxisX.Interval = 150
        Me.wykres.ChartAreas(0).AxisY.Interval = 150

        Me.wykres.ChartAreas(0).BackColor = Color.White
        Me.wykres.BackColor = Color.White

        Me.wykres.Series.Clear()
        Me.wykres.Series.Add("Curve1")
        Me.wykres.Series.Add("point1")
        Me.wykres.Series("Curve1").LegendText = "Ścieżka robota"
        Me.wykres.Series("point1").LegendText = "Punkt zadany"

        Me.wykres.Series("point1").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Me.wykres.Series("point1").BorderWidth = 4
        Me.wykres.Series("point1").MarkerStyle = DataVisualization.Charting.MarkerStyle.Square
        Me.wykres.Series("point1").MarkerColor = Color.Red

        Me.wykres.Series("Curve1").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Me.wykres.Series("Curve1").BorderWidth = 2
        Me.wykres.Series("Curve1").Color = Color.Blue

        Me.wykres.Series.Add("Punkt osiągnięty")
        Me.wykres.Series("Punkt osiągnięty").MarkerColor = Color.DarkBlue
        Me.wykres.Series("Punkt osiągnięty").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Me.wykres.Series("Punkt osiągnięty").BorderWidth = 4
        Me.wykres.Series("Punkt osiągnięty").MarkerStyle = DataVisualization.Charting.MarkerStyle.Square
        Me.wykres.Series("Punkt osiągnięty").IsVisibleInLegend = True

        Me.wykres.Series("Punkt osiągnięty").Points.AddXY(0, 0)

        Me.wykres.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Me.wykres.ChartAreas(0).AxisY.MajorGrid.Enabled = False

    End Sub
    Private Sub initButton_Click(sender As Object, e As EventArgs) Handles initButton.Click

        SerialPort1.PortName = portComboBox.Text
        SerialPort1.BaudRate = baudComboBox.Text
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
        SerialPort1.Open()

        If SerialPort1.IsOpen = True Then
            run_point_button.Enabled = True
            next_button.Enabled = True
            add_n_run.Enabled = True
            ang_button.Enabled = True
        End If

        initButton.Enabled = False
        writeButton.Enabled = True
        closeButton.Enabled = True


    End Sub
    Private Sub writeButton_Click(sender As Object, e As EventArgs) Handles writeButton.Click

        SerialPort1.Write(inputTextBox.Text)

    End Sub
    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        SerialPort1.Close()
        initButton.Enabled = True
        writeButton.Enabled = False
        closeButton.Enabled = False
    End Sub
    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Try
            Dim mydata As String = ""
            mydata = SerialPort1.ReadLine()

            xyData = SplitXY(mydata)

            If outputTextBox.InvokeRequired Then
                outputTextBox.Invoke(DirectCast(Sub() outputTextBox.Text &= mydata, MethodInvoker))
            Else
                outputTextBox.Text &= mydata
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try



    End Sub
    Private Function SplitXY(strData As String) As String()

        Dim pos1 As Integer
        Dim pos2 As Integer
        Dim char_tmp As String
        Dim i As Integer

        Dim ret() As String
        Dim retCount As Integer
        ReDim ret(0)

        For i = 1 To Len(strData)

            'Get and check the character from the string
            char_tmp = Mid(strData, i, 1)
            If char_tmp = "X" Or char_tmp = "Y" Or char_tmp = "A" Then

                'Set the positions for the new range
                pos1 = pos2
                pos2 = i

                'If the range is valid then add to the results
                If pos1 > 0 Then
                    ReDim Preserve ret(retCount)
                    ret(retCount) = Mid(strData, pos1 + 1, pos2 - pos1 - 1)
                    retCount = retCount + 1
                End If

            End If
        Next i

        'Add any final string
        ReDim Preserve ret(retCount)
        ret(retCount) = Mid(strData, pos2 + 1, Len(strData) - pos2)

        SplitXY = ret


    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If logger_flag = True Then

            Me.wykres.Series("Curve1").Points.AddXY(CInt(xyData(0)), CInt(xyData(1)))
            Me.wykres.Series("Curve1").Points.AddXY(CInt(xyData(2)), CInt(xyData(3)))

            x_act.Text = xyData(2)
            y_act.Text = xyData(3)
            act_ang.Text = xyData(4)

        End If
    End Sub
    Private Sub LOG_CHECK_CheckedChanged(sender As Object, e As EventArgs) Handles LOG_CHECK.CheckedChanged

        If LOG_CHECK.Checked Then
            logger_flag = True
        Else
            logger_flag = False
        End If

    End Sub
    Private Sub next_button_Click(sender As Object, e As EventArgs) Handles next_button.Click
        SerialPort1.Write("POINT1")
    End Sub
    Private Sub save_chart_Click(sender As Object, e As EventArgs) Handles save_chart.Click
        wykres.SaveImage("C:\Users\Emil\Desktop\chart1.bmp", ChartImageFormat.Bmp)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles clearButton.Click
        outputTextBox.Clear()
    End Sub
    Private Sub outputTextBox_TextChanged(sender As Object, e As EventArgs) Handles outputTextBox.TextChanged
        outputTextBox.SelectionStart = outputTextBox.Text.Length
        outputTextBox.ScrollToCaret()
    End Sub
    Private Sub wait(ByVal seconds As Integer)
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub
    Private Sub add_buton_Click(sender As Object, e As EventArgs) Handles add_buton.Click
        number_of_points += 1
        Dim new_point_name As String = "point"  + number_of_points.ToString

        Me.wykres.Series.Add(new_point_name)

        Me.wykres.Series(new_point_name).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Me.wykres.Series(new_point_name).BorderWidth = 4
        Me.wykres.Series(new_point_name).MarkerStyle = DataVisualization.Charting.MarkerStyle.Square
        Me.wykres.Series(new_point_name).IsVisibleInLegend = False
        If realpos_check.Checked Then
            Me.wykres.Series("Punkt osiągnięty").Points.AddXY(CInt(new_x.Text), CInt(new_y.Text))
        Else
            Me.wykres.Series(new_point_name).MarkerColor = Color.Red
            Me.wykres.Series(new_point_name).Points.AddXY(CInt(new_x.Text), CInt(new_y.Text))
        End If



    End Sub
    Private Sub add_n_run_Click(sender As Object, e As EventArgs) Handles add_n_run.Click
        number_of_points += 1
        Dim new_point_name As String = "point" + number_of_points.ToString

        Me.wykres.Series.Add(new_point_name)

        Me.wykres.Series(new_point_name).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Me.wykres.Series(new_point_name).BorderWidth = 4
        Me.wykres.Series(new_point_name).MarkerStyle = DataVisualization.Charting.MarkerStyle.Square
        Me.wykres.Series(new_point_name).IsVisibleInLegend = False
        If realpos_check.Checked Then
            Me.wykres.Series.Add("Punkt osiągnięty")
            Me.wykres.Series("Punkt osiągnięty").MarkerColor = Color.DarkBlue
            Me.wykres.Series("Punkt osiągnięty").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
            Me.wykres.Series("Punkt osiągnięty").BorderWidth = 4
            Me.wykres.Series("Punkt osiągnięty").MarkerStyle = DataVisualization.Charting.MarkerStyle.Square
            Me.wykres.Series("Punkt osiągnięty").IsVisibleInLegend = True
        Else
            Me.wykres.Series(new_point_name).MarkerColor = Color.Red
        End If

        Me.wykres.Series(new_point_name).Points.AddXY(CInt(new_x.Text), CInt(new_y.Text))

        Static Dim data_frame As String


        ' If CInt(new_x.Text) < 10 Then
        ' data_frame = "NX000" + new_x.Text
        'ElseIf CInt(new_x.Text) < 100 Then
        'data_frame = "NX00" + new_x.Text
        'ElseIf CInt(new_x.Text) < 1000 Then
        'data_frame = "NX0" + new_x.Text
        'ElseIf CInt(new_x.Text) < 10000 Then
        'data_frame = "NX" + new_x.Text
        'End If

        'If Not data_frame.Length = 0 And SerialPort1.IsOpen = True Then
        'SerialPort1.Write(data_frame)
        'End If

        'wait(1)
        'If CInt(new_y.Text) < 10 Then
        ' data_frame = "NY000" + new_y.Text
        'ElseIf CInt(new_y.Text) < 100 Then
        'data_frame = "NY00" + new_y.Text
        'ElseIf CInt(new_y.Text) < 1000 Then
        'data_frame = "NY0" + new_y.Text
        'ElseIf CInt(new_y.Text) < 10000 Then
        'data_frame = "NY" + new_y.Text
        'End If

        data_frame = "$MOVE=" + new_x.Text + "," + new_y.Text + "#"

        If Not data_frame.Length = 0 And SerialPort1.IsOpen = True Then
            SerialPort1.Write(data_frame)
        End If

    End Sub
    Private Sub run_point_button_Click(sender As Object, e As EventArgs) Handles run_point_button.Click
        Static Dim data_frame As String

        If CInt(new_x.Text) < 10 Then
            data_frame = "NX000" + new_x.Text
        ElseIf CInt(new_x.Text) < 100 Then
            data_frame = "NX00" + new_x.Text
        ElseIf CInt(new_x.Text) < 1000 Then
            data_frame = "NX0" + new_x.Text
        ElseIf CInt(new_x.Text) < 10000 Then
            data_frame = "NX" + new_x.Text
        End If

        If Not data_frame.Length = 0 And SerialPort1.IsOpen = True Then
            SerialPort1.Write(data_frame)
        End If

        wait(1)
        If CInt(new_y.Text) < 10 Then
            data_frame = "NY000" + new_y.Text
        ElseIf CInt(new_y.Text) < 100 Then
            data_frame = "NY00" + new_y.Text
        ElseIf CInt(new_y.Text) < 1000 Then
            data_frame = "NY0" + new_y.Text
        ElseIf CInt(new_y.Text) < 10000 Then
            data_frame = "NY" + new_y.Text
        End If

        If Not data_frame.Length = 0 And SerialPort1.IsOpen = True Then
            SerialPort1.Write(data_frame)
        End If
    End Sub
    Private Sub ang_button_Click(sender As Object, e As EventArgs) Handles ang_button.Click
        Static Dim data_frame As String

        If CInt(new_ang.Text) > 0 Then
            If CInt(new_ang.Text) < 10 Then
                data_frame = "ANG00" + new_ang.Text
            ElseIf CInt(new_ang.Text) < 100 Then
                data_frame = "ANG0" + new_ang.Text
            ElseIf CInt(new_ang.Text) < 1000 Then
                data_frame = "ANG" + new_ang.Text
            End If
        ElseIf CInt(new_ang.Text) < 0 Then
            If CInt(new_ang.Text) > -10 Then
                data_frame = "AG-00" + Mid(new_ang.Text, 2)
            ElseIf CInt(new_ang.Text) > -100 Then
                data_frame = "AG-0" + Mid(new_ang.Text, 2)
            ElseIf CInt(new_ang.Text) > -1000 Then
                data_frame = "AG-" + Mid(new_ang.Text, 2)
            End If
        ElseIf CInt(new_ang.Text) = 0 Then
            data_frame = "ANGZER"
        End If

            If Not data_frame.Length = 0 And SerialPort1.IsOpen = True Then
            SerialPort1.Write(data_frame)
        End If
    End Sub



    Private Sub inputTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles inputTextBox.KeyPress
        Static Dim data_frame As String
        If Asc(e.KeyChar) = 119 Or Asc(e.KeyChar) = 87 Then
            data_frame = "$MOTOR=90,90#"
            SerialPort1.Write(data_frame)
        End If
        If Asc(e.KeyChar) = 115 Or Asc(e.KeyChar) = 83 Then
            data_frame = "$MOTOR=-90,-90#"
            SerialPort1.Write(data_frame)
        End If
        If Asc(e.KeyChar) = 97 Or Asc(e.KeyChar) = 65 Then
            data_frame = "$MOTOR=30,75#"
            SerialPort1.Write(data_frame)
        End If
        If Asc(e.KeyChar) = 100 Or Asc(e.KeyChar) = 68 Then
            data_frame = "$MOTOR=75,30#"
            SerialPort1.Write(data_frame)
        End If
        If Asc(e.KeyChar) = 32 Then
            data_frame = "$MOTOR=0,0#"
            SerialPort1.Write(data_frame)
        End If
        If Asc(e.KeyChar) = 113 Then
            data_frame = "$MOTOR=-75,75#"
            SerialPort1.Write(data_frame)
        End If
        If Asc(e.KeyChar) = 101 Then
            data_frame = "$MOTOR=75,-75#"
            SerialPort1.Write(data_frame)
        End If





        If Asc(e.KeyChar) = 121 Then
            data_frame = "$MOTOR=20,20#"
            SerialPort1.Write(data_frame)
        End If
        If Asc(e.KeyChar) = 106 Then
            data_frame = "$MOTOR=-20,-20#"
            SerialPort1.Write(data_frame)
        End If

        If Asc(e.KeyChar) = 104 Then
            data_frame = "$MOTOR=0,20#"
            SerialPort1.Write(data_frame)
        End If
        If Asc(e.KeyChar) = 107 Then
            data_frame = "$MOTOR=20,0#"
            SerialPort1.Write(data_frame)
        End If

        If Asc(e.KeyChar) = 116 Then
            data_frame = "$MOTOR=-20,75#"
            SerialPort1.Write(data_frame)
        End If
        If Asc(e.KeyChar) = 117 Then
            data_frame = "$MOTOR=20,-75#"
            SerialPort1.Write(data_frame)
        End If


    End Sub
End Class
