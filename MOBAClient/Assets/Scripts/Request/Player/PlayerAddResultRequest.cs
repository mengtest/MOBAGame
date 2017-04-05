﻿using System;
using System.Collections;
using System.Collections.Generic;
using Common.OpCode;
using ExitGames.Client.Photon;
using UnityEngine;

/// <summary>
/// 得到是否同意添加好友的结果
/// 不需要请求
/// </summary>
public class PlayerAddResultRequest : BaseRequest
{
    private MainMenuPanel m_MainPanel;

    public override void Start()
    {
        this.OpCode = OperationCode.PlayerAddResult;
        base.Start();
        m_MainPanel = GetComponent<MainMenuPanel>();
    }

    // 不需要
    public override void DefalutRequest()
    {
    }

    /// <summary>
    /// 处理是否添加好友的结果 
    /// </summary>
    /// <param name="response"></param>
    public override void OnOperationResponse(OperationResponse response)
    {
        m_MainPanel.OnAddResult(response);
    }
}