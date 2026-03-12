using Fantasy.Async;
using Fantasy.Entitas;
using Fantasy.Network;
using Fantasy.Network.Interface;
using Fantasy.Platform.Net;

namespace Fantasy.Hotfix.Handler
{
    public class G2Map_CreatePlayerRequestHandler : AddressRPC<Scene, G2Map_CreatePlayerRequest, Map2G_CreatePlayerResponse>
    {
        protected override async FTask Run(Scene scene, G2Map_CreatePlayerRequest request, Map2G_CreatePlayerResponse response, Action reply)
        {
            // 业务逻辑处理
            Log.Debug($"收到服务器内消息");
            response.ErrorCode = 0;
            var player = Entity.Create<Player>(scene);
            player.Name = request.Name;
            player.Age = request.Age;

            response.PlayerAddress = player.Address;
            await FTask.CompletedTask;
        }
    }
}