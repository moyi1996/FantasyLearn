using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Fantasy.Hotfix.Handler
{
    public class G2Player_TestRequestHandler : AddressRPC<Player, G2Player_TestRequest, Player2G_TestResponse>
    {
        protected override async FTask Run(Player player, G2Player_TestRequest request, Player2G_TestResponse response, Action reply)
        {
            // 业务逻辑处理
            Log.Debug($"收到G2的测试请求，内容: player.Name={player.Name} Age={player.Age} Tag={request.Tag}");

            // 可以在这里添加一些业务逻辑，比如根据请求Tag给Player处理一些操作

            response.ErrorCode = 0;
            response.Tag = $"Player处理了G2请求, Tag={request.Tag}";

            await FTask.CompletedTask;
        }
    }
}