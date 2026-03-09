using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Fantasy.Hotfix.Handler
{
    public class C2G_TestMessageHandler : Message<C2G_TestMessage>
    {
        protected override async FTask Run(Session session, C2G_TestMessage message)
        {
            // 业务逻辑处理
            Log.Debug($"收到客户端消息: Tag={message.Tag}");

            // 可以通过 session 回复消息
            session.Send(new G2C_TestMessage()
            {
                Message = $"服务器收到了你的消息: {message.Tag}"
            });

            await FTask.CompletedTask;
        }
    }
}