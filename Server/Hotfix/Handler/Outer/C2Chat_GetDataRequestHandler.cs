using Fantasy;
using Fantasy.Async;
using Fantasy.Network.Interface;
using Fantasy.Network.Roaming;

public class C2Chat_GetDataRequestHandler : RoamingRPC<Terminus, C2Chat_GetDataRequest, Chat2C_GetDataResponse>
{ 
    protected override async FTask Run(Terminus terminus, C2Chat_GetDataRequest request, Chat2C_GetDataResponse response, Action reply)
    {
        Log.Debug($"收到客户端发送的RoamingRPC消息: {request.PlayerId}");
        response.ChatData = "Fantasy";

        await FTask.CompletedTask;
    }
}