using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Handler
{
    public class G2C_TestMessageHandler : Message<G2C_TestMessage>
    {
        protected override async FTask Run(Session session, G2C_TestMessage message)
        {
            // 业务逻辑处理
            Log.Debug($"接收到服务器传来的消息: Tag={message.Message}");

            await FTask.CompletedTask;
        }
    }
}