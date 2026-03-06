using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fantasy;
using Fantasy.Async;
using Fantasy.Network;

public class GameEntry : MonoBehaviour
{
    private Scene _scene;
    private void Start()
    {
        StartAsync().Coroutine();
    }

    private void OnDestroy()
    {
        // 销毁 Scene,清理所有网络和 Fantasy 相关资源
        _scene?.Dispose();
    }

    private async FTask StartAsync()
    {
        // 1. 初始化 Fantasy 框架
        // 此方法会自动:
        //   - 初始化日志系统(UnityLog)
        //   - 初始化序列化系统
        //   - 创建 Fantasy GameObject(DontDestroyOnLoad)
        //   - 注册 Update/LateUpdate 循环
        //   - WebGL 平台下初始化线程同步上下文
        await Fantasy.Platform.Unity.Entry.Initialize();

        // 2. 创建客户端 Scene
        // Scene 是客户端的核心容器,管理所有实体、组件和网络连接
        // 参数 arg: 传递给 OnSceneCreate 事件的自定义参数
        // 参数 sceneRuntimeMode: 场景运行模式(MainThread/MultiThread/ThreadPool)
        _scene = await Fantasy.Platform.Unity.Entry.CreateScene(
            arg: null,
            sceneRuntimeMode: SceneRuntimeMode.MainThread
        );

        Log.Debug("Fantasy 初始化完成!");
    }
}
