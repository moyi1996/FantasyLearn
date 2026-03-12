using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Fantasy.Hotfix.Handler
{
    public class G2Player_TestMessageHandler : Address<Player, G2Player_TestMessage>
    {
        protected override async FTask Run(Player player, G2Player_TestMessage message)
        {
            // 业务逻辑处理
            Log.Debug($"收到来自G2的测试消息，内容: player.Name={player.Name} Age={player.Age} Tag={message.Tag}");
            await FTask.CompletedTask;
        }
    }
}