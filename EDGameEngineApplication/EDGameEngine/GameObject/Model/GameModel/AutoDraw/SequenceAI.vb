﻿Imports System.Numerics
''' <summary>
''' 表示自动循迹并生成绘制序列的AI
''' </summary>
Public Class SequenceAI
    ''' <summary>
    ''' 线条序列List
    ''' </summary>
    ''' <returns></returns>
    Public Property Sequences As List(Of PointSequence)
    ''' <summary>
    ''' 扫描方式
    ''' </summary>
    Public Property ScanMode As ScanMode = ScanMode.Rect
    Dim xArray() As Integer = {-1, 0, 1, 1, 1, 0, -1, -1}
    Dim yArray() As Integer = {-1, -1, -1, 0, 1, 1, 1, 0}
    Dim NewStart As Boolean
    ''' <summary>
    ''' 创建并初始化一个可自动生成绘制序列AI的实例
    ''' </summary>
    Public Sub New(BolArr(,) As Integer)
        Sequences = New List(Of PointSequence)
        CalculateSequence(BolArr)
        For Each SubItem In Sequences
            SubItem.CalcSize()
        Next
    End Sub
    ''' <summary>
    ''' 新增一个序列
    ''' </summary>
    Private Sub CreateNewSequence()
        Sequences.Add(New PointSequence)
    End Sub
    ''' <summary>
    ''' 在序列List末尾项新增一个点
    ''' </summary>
    Private Sub AddPoint(point As Vector2)
        Sequences.Last.Points.Add(point)
    End Sub
    ''' <summary>
    ''' 计算序列
    ''' </summary>
    Private Sub CalculateSequence(BolArr(,) As Integer)
        If ScanMode = ScanMode.Rect Then
            ScanRect(BolArr)
        Else
            ScanCircle(BolArr)
        End If
    End Sub
    ''' <summary>
    ''' 圆形扫描
    ''' </summary>
    ''' <param name="BolArr"></param>
    Private Sub ScanCircle(BolArr(,) As Integer)
        Dim xCount As Integer = BolArr.GetUpperBound(0)
        Dim yCount As Integer = BolArr.GetUpperBound(1)
        Dim CP As New Point(xCount / 2, yCount / 2)
        Dim R As Integer = 0
        For R = 0 To If(xCount > yCount, xCount, yCount)
            For Theat = 0 To Math.PI * 2 Step 1 / R
                Dim dx As Integer = CP.X + R * Math.Cos(Theat)
                Dim dy As Integer = CP.Y + R * Math.Sin(Theat)
                If Not (dx > 0 And dy > 0 And dx < xCount And dy < yCount) Then Continue For
                If BolArr(dx, dy) = 1 Then
                    BolArr(dx, dy) = 0
                    Me.CreateNewSequence()
                    Me.AddPoint(New Vector2(dx, dy))
                    CheckMove(BolArr, dx, dy, 0)
                    NewStart = True
                End If
            Next
        Next
    End Sub
    ''' <summary>
    ''' 矩形扫描
    ''' </summary>
    ''' <param name="BolArr"></param>
    Private Sub ScanRect(BolArr(,) As Integer)
        Dim xCount As Integer = BolArr.GetUpperBound(0)
        Dim yCount As Integer = BolArr.GetUpperBound(1)
        For i = 0 To xCount - 1
            For j = 0 To yCount - 1
                Dim dx As Integer = i
                Dim dy As Integer = j
                If Not (dx > 0 And dy > 0 And dx < xCount And dy < yCount) Then Continue For
                If BolArr(dx, dy) = 1 Then
                    BolArr(dx, dy) = 0
                    Me.CreateNewSequence()
                    Me.AddPoint(New Vector2(dx, dy))
                    CheckMove(BolArr, dx, dy, 0)
                    NewStart = True
                End If
            Next
        Next
    End Sub
    ''' <summary>
    ''' 递归循迹算法
    ''' </summary>
    Private Sub CheckMove(ByRef bolArr(,) As Integer, ByVal x As Integer, ByVal y As Integer, ByVal StepNum As Integer)
        If StepNum > 1000 Then Return
        Dim xBound As Integer = bolArr.GetUpperBound(0)
        Dim yBound As Integer = bolArr.GetUpperBound(1)
        Dim dx, dy As Integer
        Dim AroundValue As Integer = GetAroundValue(bolArr, x, y)
        '根据点权值轨迹将在当前点断开
        'If AroundValue > 2 AndAlso AroundValue < 8 Then
        'Return
        'End If
        For i = 0 To 7
            dx = x + xArray(i)
            dy = y + yArray(i)
            If Not (dx > 0 And dy > 0 And dx < xBound And dy < yBound) Then
                Return
            ElseIf bolArr(dx, dy) = 1 Then
                bolArr(dx, dy) = 0
                If NewStart = True Then
                    Me.CreateNewSequence()
                    Me.AddPoint(New Vector2(dx, dy))
                    NewStart = False
                Else
                    Me.AddPoint(New Vector2(dx, dy))
                End If
                CheckMove(bolArr, dx, dy, StepNum + 1)
                NewStart = True
            End If
        Next
    End Sub
    ''' <summary>
    ''' 返回点权值
    ''' </summary>
    Private Function GetAroundValue(ByRef BolArr(,) As Integer, ByVal x As Integer, ByVal y As Integer) As Integer
        Dim dx, dy, ResultValue As Integer
        Dim xBound As Integer = BolArr.GetUpperBound(0)
        Dim yBound As Integer = BolArr.GetUpperBound(1)
        For i = 0 To 7
            dx = x + xArray(i)
            dy = y + yArray(i)
            If dx > 0 And dy > 0 And dx < xBound And dy < yBound Then
                If BolArr(dx, dy) = 1 Then
                    ResultValue += 1
                End If
            End If
        Next
        Return ResultValue
    End Function
End Class
