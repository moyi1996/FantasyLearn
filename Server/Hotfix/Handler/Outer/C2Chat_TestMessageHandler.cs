using Fantasy;
using Fantasy.Async;
using Fantasy.Network.Interface;
using Fantasy.Network.Roaming;

public class C2Chat_TestMessageHandler : Roaming<Terminus, C2Chat_TestMessage>
{
    protected override async FTask Run(Terminus terminus, C2Chat_TestMessage message)
    {
        Log.Debug($"收到客户端发送的Roaming消息: {message.Tag}");

        await FTask.CompletedTask;
    }
}