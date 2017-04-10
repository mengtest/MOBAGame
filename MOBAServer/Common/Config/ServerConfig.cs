﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Config
{
    public class ServerConfig
    {
        /// <summary>
        /// 进入选择房间的等待时间
        /// </summary>
        public const int SelectRoomTimeOff = 10;

        #region 英雄

        /// <summary>
        /// 英雄的初始id
        /// </summary>
        public const int HeroId = 0;
        /// <summary>
        /// 技能的初始id
        /// 英雄技能id：heroId *　skillId + num
        /// </summary>
        public const int SkillId = 1000;

        #endregion


        #region 建筑

        /// <summary>
        /// 队伍1建筑的初始id
        /// </summary>
        public const int TeamOneBuildId = -100;
        /// <summary>
        /// 队伍2建筑的初始id
        /// </summary>
        public const int TeamTwoBuildId = -200;
        /// <summary>
        /// 防御塔数量
        /// </summary>
        public const int TowerCount = 3;

        /// <summary>
        /// 小兵的初始id
        /// </summary>
        public const int MinionId = -1000;


        /// <summary>
        /// 基地
        /// </summary>
        public const int MainBaseId = 1;
        /// <summary>
        /// 兵营
        /// </summary>
        public const int CampId = 2;
        /// <summary>
        /// 炮塔 
        /// </summary>
        public const int TowerId = 3;

        #endregion

    }
}