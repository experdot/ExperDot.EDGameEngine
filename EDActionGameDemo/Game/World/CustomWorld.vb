﻿Imports EDGameEngine.Core
''' <summary>
''' 用户游戏世界
''' </summary>
Public Class CustomWorld
    Inherits World
    Public Sub New(aw#, ah#)
        MyBase.New(aw, ah)
    End Sub
    Public Overrides Sub Start()
        Scenes.Add("Main", New Scene1(Me, New Size(Width, Height)))
        SwitchScene("Main")
    End Sub

End Class