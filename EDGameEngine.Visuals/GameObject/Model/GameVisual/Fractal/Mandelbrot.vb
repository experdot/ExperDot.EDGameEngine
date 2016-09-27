﻿Imports System.Numerics
Imports EDGameEngine.Core
Imports Windows.UI
''' <summary>
''' 曼德布罗集
''' </summary>
Public Class Mandelbrot

    Inherits GameBody
    Public Property Vertexs As New List(Of ColorVertex）

    Public Overrides Sub StartEx()

    End Sub

    Public Overrides Sub UpdateEx()
        'If Vertexs.Count > 0 Then Exit Sub

        'Static astart As Double = -2
        'Static bstart As Double = -2

        'Dim a, b, x, y, x1, y1 As Double
        'Dim tc As Integer = 0
        'For a = astart To 2 Step 0.005
        '    For b = bstart To 2 Step 0.005
        '        x = a
        '        y = b
        '        For n = 1 To 20
        '            x1 = x * x - y * y + a
        '            y1 = 2 * x * y + b
        '            x = x1
        '            y = y1
        '        Next
        '        If x * x + y * y < 4 Then
        '            Dim tempcolor As Color = Color.FromArgb(255, CByte(x * x * 63), CByte(x * x * 63), CByte((x * x + y * y) * 63))
        '            Vertexs.Add(New ColorVertex(New Vector2(CSng(a * 50 + Scene.Width / 2), CSng(y * 50 + Scene.Height / 2)), tempcolor))

        '        End If
        '        tc += 1
        '        bstart = -2
        '    Next

        '    If tc > 1000 Then
        '        astart = a
        '        bstart = b
        '        Exit Sub
        '    End If
        '    bstart = -2
        'Next

        Static a(,) As Double = {{0, 0, 0, 0, 0, 0, 0, 0},
                              {0, 0.195, -0.488, 0.344, 0.433, 0.4431, 0.2452, 0.25},
                              {0, 0.462, 0.414, -0.252, 0.361, 0.2511, 0.5692, 0.25},
                              {0, -0.058, -0.07, 0.453, -0.111, 0.5976, 0.0969, 0.25},
                              {0, -0.035, 0.07, -0.469, -0.022, 0.4884, 0.5069, 0.2},
                              {0, -0.637, 0, 0, 0.501, 0.8562, 0.2513, 0.05}}

        Static x0 As Double = 1, y0 As Double = 1, x1 As Double = 0, y1 As Double = 0
        Dim count As Integer = 0
        Static iStart As Integer = 1
        For i = iStart To 150000
            Dim r = Rnd.NextDouble
            If r <= 0.25 Then
                x1 = a(1, 1) * x0 + a(1, 2) * y0 + a(1, 5)
                y1 = a(1, 3) * x0 + a(1, 4) * y0 + a(1, 6)
            ElseIf r > 0.25 And r <= 0.5 Then
                x1 = a(2, 1) * x0 + a(2, 2) * y0 + a(2, 5)
                y1 = a(2, 3) * x0 + a(2, 4) * y0 + a(2, 6)
            ElseIf r > 0.5 And r <= 0.75 Then
                x1 = a(3, 1) * x0 + a(3, 2) * y0 + a(3, 5)
                y1 = a(3, 3) * x0 + a(3, 4) * y0 + a(3, 6)
            ElseIf r > 0.75 And r <= 0.95 Then
                x1 = a(4, 1) * x0 + a(4, 2) * y0 + a(4, 5)
                y1 = a(4, 3) * x0 + a(4, 4) * y0 + a(4, 6)
            ElseIf r > 0.95 And r <= 1 Then
                x1 = a(5, 1) * x0 + a(5, 2) * y0 + a(5, 5)
                y1 = a(5, 3) * x0 + a(5, 4) * y0 + a(5, 6)
            End If
            x0 = x1 : y0 = y1
            Dim myColor = Color.FromArgb(255, CByte(x0 * x0 * 200 * r), CByte(y0 * y0 * 200 * r), CByte(x0 * y0 * 255))
            Vertexs.Add(New ColorVertex(New Vector2(CSng(Scene.Width * 0.75 - x1 * Scene.Height), CSng(Scene.Height - y1 * Scene.Height)), myColor))
            count += 1
            If count > 100 Then
                'iStart = i
                'Exit For
            End If
        Next
    End Sub
End Class
