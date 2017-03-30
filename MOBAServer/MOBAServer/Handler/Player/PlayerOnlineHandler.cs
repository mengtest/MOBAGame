﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Code;
using Common.OpCode;
using LitJson;
using MOBAServer.Cache;
using MOBAServer.DataBase.Manager;
using Photon.SocketServer;

namespace MOBAServer.Handler.Player
{
    // 本来玩家和角色是一对多的关系
    // 这里简化这个过程 直接选择第一个角色
    // 反正也没创建第二个角色的界面
    class PlayerOnlineHandler : BaseHandler
    {
        public override void OnOperationRequest(OperationRequest request, SendParameters sendParameters, MobaPeer peer)
        {
            MobaServer.LogInfo("处理玩家上线的请求");

            // 获取自身的Player数据
            DataBase.Model.Player player = UserManager.GetPlayer(peer.Username);
            if (player == null)
            {
                MobaServer.LogError(">>>>>>>>>> 数据异常 : PlayerOnlineHandler");
                return;
            }

            // 防止重复上线
            if (Caches.Player.IsOnline(player.Identification))
            {
                MobaServer.LogError(">>>>>>>>> Player:" + player.Name + " 已上线");
                return;
            }

            Caches.Player.Online(player.Identification, peer);

            OperationResponse response = new OperationResponse();

            #region 上线时 通知好友

            if (!String.IsNullOrEmpty(player.FriendIdList))
            {
                string[] friends = player.FriendIdList.Split(',');
                MobaPeer tempPeer = null;
                response.OperationCode = (byte)OperationCode.FriendOnline;
                foreach (string friend in friends)
                {
                    if (string.IsNullOrEmpty(friend))
                        continue;
                    int id = int.Parse(friend);
                    if (!Caches.Player.IsOnline(id))
                        continue;
                    tempPeer = Caches.Player.GetPeer(id);

                    // 发送好友上线的消息
                    response.Parameters = new Dictionary<byte, object>();
                    response[(byte)ParameterCode.FriendId] = id;
                    tempPeer.SendOperationResponse(response, sendParameters);
                }
            }

            #endregion

            // 发送自身的玩家数据给客户端
            response.OperationCode = request.OperationCode;
            response.Parameters = new Dictionary<byte, object>();
            response[(byte)ParameterCode.PlayerDot] = JsonMapper.ToJson(player.ConvertToDot());
            peer.SendOperationResponse(response, sendParameters);
        }
    }
}
