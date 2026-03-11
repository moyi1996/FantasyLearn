using System;
using Fantasy.Async;
using Fantasy.Network;
using Fantasy.Network.Interface;

namespace Fantasy.Gate;

public sealed class C2G_TestRequestHandler : MessageRPC<C2G_TestRequest, G2C_TestResponse>
{
    protected override async FTask Run(Session session, C2G_TestRequest request,
                                       G2C_TestResponse response, Action reply)
    {
        // 业务逻辑处理
        Log.Debug($"收到 RPC 请求: Tag={request.Tag}");

        var players = await session.Scene.World.Database.Query<Player>(p => p.Name == request.Tag);
        if (players.Count == 0)
        {
            response.ErrorCode = 1;
            response.Tag = "玩家不存在";
        }
        else
        {
            response.ErrorCode = 0;
            var player = players[0];
            response.Tag = $"玩家: {player.Name} 等级: {player.Level} 金币: {player.Gold}";
        }

        // // 填充响应数据
        // response.ErrorCode = 0;  // 0 表示成功
        // response.Tag = $"服务器响应: {request.Tag + 1}";

        // reply() 会在 finally 块自动调用，通常不需要手动调用
        // 如果需要提前返回响应，可以调用 reply()

        await FTask.CompletedTask;
    }
}