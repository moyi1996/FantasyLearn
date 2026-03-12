using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Fantasy.Hotfix.Handler
{
    public class C2G_SendPlayerMessageHandler : Message<C2G_SendPlayerMessage>
    {
        protected override async FTask Run(Session session, C2G_SendPlayerMessage message)
        {
            var playerFlagComponet = session.GetComponent<PlayerFlagComponet>();
            if (playerFlagComponet == null)
            {
                Log.Error("PlayerFlagComponent is null");
                return;
            }
            var address = playerFlagComponet.PlayerAddress;

            session.Scene.Send(address, new G2Player_TestMessage()
            {
                Tag = "创建任务成功，给Player实体发送消息"
            });

            var response = (Player2G_TestResponse)await session.Scene.Call(address, new G2Player_TestRequest()
            {
                Tag = "创建任务成功，给Player实体发送消息"
            });

            if (response.ErrorCode != 0)
            {
                Log.Error("创建任务失败，给Player实体发送消息失败");
                return;
            }
            

            await FTask.CompletedTask;
        }
    }
}