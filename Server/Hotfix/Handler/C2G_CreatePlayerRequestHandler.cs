using Fantasy.Async;
using Fantasy.Entitas;
using Fantasy.Network;
using Fantasy.Network.Interface;
using Fantasy.Platform.Net;

namespace Fantasy.Hotfix.Handler
{
    public class C2G_CreatePlayerRequestHandler : MessageRPC<C2G_CreatePlayerRequest, G2C_CreatePlayerResponse>
    {
        protected override async FTask Run(Session session, C2G_CreatePlayerRequest request, G2C_CreatePlayerResponse response, Action reply)
        {
            // 业务逻辑处理
            Log.Debug($"收到客户端消息");

            // 获取目标Scene
            var aGSceneConfig = SceneConfigData.Instance.GetSceneBySceneType(SceneType.AGMap)[0];
            // 获取目标Scene的Address
            var address = aGSceneConfig.Address;

            // 发送服务器之间的消息
            var createPlayerResponse = (Map2G_CreatePlayerResponse)await session.Scene.Call(address,
                new G2Map_CreatePlayerRequest()
            {
                Name = "Fantasy",
                Age = "18"
            });

            if (createPlayerResponse.ErrorCode != 0)
            {
                Log.Error($"无法发送到AGMap服务器: {createPlayerResponse.ErrorCode}");
            }
            else
            {
                Log.Debug($"发送到AGMap服务器成功");
                // 使用组件模式挂载到session上保存
                session.AddComponent<PlayerFlagComponet>().PlayerAddress = createPlayerResponse.PlayerAddress;

            }

            await FTask.CompletedTask;
        }
    }
}