﻿Imports System.Numerics
''' <summary>
''' 游戏角色接口
''' </summary>
Public Interface ICharacter
    Inherits ITransform, ICollision, IUpdateable
    ''' <summary>
    ''' 名称
    ''' </summary>
    ''' <returns></returns>
    Property Name As String
    ''' <summary>
    ''' 人物贴图
    ''' </summary>
    Property Image As ResourceId
    ''' <summary>
    ''' 生命值
    ''' </summary>
    Property HP As RemainingCounter
    ''' <summary>
    ''' 能力管理器
    ''' </summary>
    Property AbilityManager As AbilityManager
End Interface
