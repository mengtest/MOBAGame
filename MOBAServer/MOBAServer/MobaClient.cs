﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extension;
using Common.OpCode;
using MOBAServer.Handler;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace MOBAServer
{
    public class MobaClient : ClientPeer
    {
        public string Username;
        public MobaClient(InitRequest initRequest) : base(initRequest)
        {

        }

        // 处理客户端请求
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            BaseHandler handler = MobaServer.Instance.HandlerDict.TryGetEx((OperationCode) operationRequest.OperationCode);
            if (handler != null)
            {
                handler.OnOperationRequest(operationRequest, sendParameters, this);
            }
            else
            {
                MobaServer.LogError("找不到请求的对应处理");
            }
        }

        // 客户端断开连接
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            if (Username != null)
            {
                MobaServer.LogInfo("客户端断开, Username : " + Username);
            }
            else
            {
                MobaServer.LogInfo("未知客户端断开");
            }
        }
    }
}
