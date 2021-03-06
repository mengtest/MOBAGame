﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.OpCode
{
    // 区分通信的操作类型
    public enum OperationCode
    {
        Default,

        #region 用户

        /// <summary>
        /// 用户登录
        /// </summary>
        UserLogin,
        /// <summary>
        /// 用户注册
        /// </summary>
        UserRegister,

        #endregion

        #region 玩家

        /// <summary>
        /// 创建玩家
        /// </summary>
        PlayerCreate,
        /// <summary>
        /// 获取玩家信息
        /// </summary>
        PlayerGetInfo,
        /// <summary>
        /// 玩家上线
        /// </summary>
        PlayerOnline,
        /// <summary>
        /// 请求添加好友
        /// </summary>
        PlayerAddRequest,
        /// <summary>
        /// 回应添加好友
        /// </summary>
        PlayerAddToClient,
        /// <summary>
        /// 添加好友的结果
        /// </summary>
        PlayerAddResult,
        /// <summary>
        /// 好友登陆状态改变
        /// </summary>
        FriendStateChange,

        #endregion

        #region 匹配

        /// <summary>
        /// 开始匹配
        /// </summary>
        StartMatch,
        /// <summary>
        /// 停止匹配
        /// </summary>
        StopMatch,
        /// <summary>
        /// 进入选人
        /// </summary>
        EnterSelect,
        /// <summary>
        /// 销毁选人的房间
        /// </summary>
        DestroySelect,
        /// <summary>
        /// 获取房间信息
        /// </summary>
        SelectGetInfo,
        /// <summary>
        /// 选人
        /// </summary>
        Selected,
        /// <summary>
        /// 准备完毕
        /// </summary>
        BeReadySelect,
        /// <summary>
        /// 在选择界面聊天
        /// </summary>
        TalkInSelect,

        #endregion

        #region 战斗

        /// <summary>
        /// 准备战斗
        /// </summary>
        ReadyBattle,
        /// <summary>
        /// 进入战斗
        /// </summary>
        EnterBattle,
        /// <summary>
        /// 初始化完成
        /// </summary>
        InitComplete,
        /// <summary>
        /// 生成小兵
        /// </summary>
        SpawnMinion,
        /// <summary>
        /// 英雄移动
        /// </summary>
        HeroMove,
        /// <summary>
        /// 使用技能
        /// </summary>
        UseSkill,
        /// <summary>
        /// 计算伤害
        /// </summary>
        Damage,
        /// <summary>
        /// 升级技能
        /// </summary>
        UpgradeSkill,
        /// <summary>
        /// 购买装备
        /// </summary>
        BuyItem,
        /// <summary>
        /// 获得奖励
        /// </summary>
        GetReward,
        /// <summary>
        /// 效果结束
        /// </summary>
        EffectEnd,
        /// <summary>
        /// 英雄复活
        /// </summary>
        HeroRebirth,

        #endregion
    }
}
