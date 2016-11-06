﻿Imports System.Numerics
Imports Windows.UI
''' <summary>
''' 可视化文字
''' </summary>
Public Interface IVisualText
    Inherits IGameBody
    ''' <summary>
    ''' 文字
    ''' </summary>
    Property Text As String
    ''' <summary>
    ''' 偏移
    ''' </summary>
    Property Offset As Vector2
    ''' <summary>
    ''' 颜色
    ''' </summary>
    Property Color As Color
End Interface
