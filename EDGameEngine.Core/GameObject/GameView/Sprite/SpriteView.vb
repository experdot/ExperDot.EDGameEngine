﻿Imports Microsoft.Graphics.Canvas

Public Class SpriteView
    Inherits TypedGameView(Of ISprite)
    Public Sub New(Target As ISprite)
        MyBase.New(Target)
    End Sub
    Public Overrides Sub OnDraw(drawingSession As CanvasDrawingSession)
        If Target.Image IsNot Nothing Then
            drawingSession.DrawImage(Target.Image)
        End If
    End Sub
End Class
