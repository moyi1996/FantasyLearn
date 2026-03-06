using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using UnityEngine;

public class QuickStart : MonoBehaviour
{
    private Scene _scene;
    private Session _session;

    private void Start()
    {
        StartAsync().Coroutine();
    }

    private async FTask StartAsync()
    {
        // 1. 初始化 Fantasy 框架
        await Fantasy.Platform.Unity.Entry.Initialize();

        // 2. 创建一个 Scene (客户端场景)
        // Scene 是 Fantasy 框架的核心容器,所有功能都在 Scene 下运行
        // SceneRuntimeMode.MainThread 表示在 Unity 主线程运行
        _scene = await Scene.Create(SceneRuntimeMode.MainThread);

        _session = _scene.Connect(
            "127.0.0.1:20000",                    // 服务器地址和端口
            NetworkProtocolType.KCP,              // 网络协议类型（TCP/KCP/WebSocket）
            OnConnectComplete,                    // 连接成功回调
            OnConnectFail,                        // 连接失败回调
            OnConnectDisconnect,                  // 连接断开回调
            false,                                // 是否HTTPS请求（仅用于WebSocket）
            5000);                                // 连接超时时间（毫秒）
        // 方式1
        // _session.Send(new C2G_TestMessage() { Tag = "Hello, Fantasy!" });
        // 方式2
        _session.C2G_TestMessage("Hello, Fantasy!");

        //发送一个RPC消息
        var response = (G2C_TestResponse)await _session.Call(new C2G_TestRequest() { Tag = "Hello, Fantasy!" });
        if (response.ErrorCode != 0)
        {
            Debug.LogError("response: " + response.ErrorCode);
        }
        else
        { 
            Debug.Log("response: " + response.Tag);
        }

        var response2 = await _session.C2G_TestRequest("Hello, Fantasy!");
        Debug.Log("response2: " + response2.Tag + " ErrorCode: " + response2.ErrorCode);

        Debug.Log("Fantasy 框架初始化完成!");
    }
    private void OnConnectComplete()
    {
        Log.Debug("连接成功");

        // 可选：添加心跳组件
        _session.AddComponent<SessionHeartbeatComponent>().Start(2000);

        // 开始通信
        SendMessage();
    }

    private void OnConnectFail()
    {
        Log.Debug("连接失败");
    }

    private void OnConnectDisconnect()
    {
        Log.Debug("连接断开");
    }

    private void SendMessage()
    {
        // 发送消息...
    }
    private void OnDestroy()
    {
        // 销毁 Scene,释放所有资源
        _scene?.Dispose();
    }
}