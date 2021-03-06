﻿Imports EDGameEngine.Core
Imports EDGameEngine.Core.Graphics
Imports Microsoft.Graphics.Canvas
''' <summary>
''' 分形的视图
''' </summary>
Public Class FractalView
    Inherits TypedCanvasView(Of IFractal)

    Public Overrides Sub OnDraw(session As CanvasDrawingSession)
        Dim tempPoint As New Vertex
        While Target.Vertexs.TryDequeue(tempPoint)
            'DrawingSession.DrawCircle(tempPoint.Position, tempPoint.Size, tempPoint.Color)
            Dim size = tempPoint.Size / 2
            session.DrawRectangle(New Rect(tempPoint.Position.X - size, tempPoint.Position.Y - size, tempPoint.Size, tempPoint.Size), tempPoint.Color)
        End While
    End Sub
End Class
