using Fantasy;
using Fantasy.Async;
using Fantasy.Entitas;
using Fantasy.Helper;
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
        // var response = (G2C_TestResponse)await _session.Call(new C2G_TestRequest() { Tag = "Hello, Fantasy!" });
        // if (response.ErrorCode != 0)
        // {
        //     Debug.LogError("response: " + response.ErrorCode);
        // }
        // else
        // { 
        //     Debug.Log("response: " + response.Tag);
        // }

        // var response2 = await _session.C2G_TestRequest("Hello, Fantasy!");
        // Debug.Log("response2: " + response2.Tag + " ErrorCode: " + response2.ErrorCode);

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


    public void TestECS()
    {
        var player = Entity.Create<Player>(_scene, isPool: true, isRunEvent: true);

        #region 添加Buff组件
        // 方式 1：自动生成 ID
        var buff1 = player.AddComponent<BuffComponent>();
        buff1.BuffType = 1001;
        buff1.ExpireTime = TimeHelper.Now + 10000;

        var buff2 = player.AddComponent<BuffComponent>();
        buff2.BuffType = 1002;
        buff2.ExpireTime = TimeHelper.Now + 20000;

        Log.Info($"Buff1 ID: {buff1.Id}");  // 例如: 1001
        Log.Info($"Buff2 ID: {buff2.Id}");  // 例如: 1002

        // 方式 2：指定 ID（需要确保唯一性）
        var buff3 = player.AddComponent<BuffComponent>(id: 9999);
        Log.Info($"Buff3 ID: {buff3.Id}");  // 输出: 9999
        #endregion

        #region 查找和访问组件
        // 通过 ID 获取
        var buff = player.GetComponent<BuffComponent>(buff1.Id);

        // 检查是否存在
        if (player.HasComponent<BuffComponent>(buff1.Id))
        {
            Log.Info("Buff exists!");
        }

        // 遍历所有多实例组件
        foreach (var entity in player.ForEachMultiEntity)
        {
            if (entity is BuffComponent buffEntity)
            {
                Log.Info($"BuffType: {buffEntity.BuffType}, ExpireTime: {buffEntity.ExpireTime}");
            }
        }
        #endregion

        #region 移除组件
        // 删除指定 ID 的组件
        player.RemoveComponent<BuffComponent>(buff1.Id);

        // 删除但不销毁（只是解除父子关系）
        player.RemoveComponent<BuffComponent>(buff2.Id, isDispose: false);
        #endregion

    }
    public void AddBuff(Player player, int buffId, int buffType, float value, long duration)
    {
        var buff = player.AddComponent<BuffComponent>();
        buff.BuffId = buffId;
        buff.BuffType = buffType;
        buff.Value = value;
        buff.ExpireTime = TimeHelper.Now + duration;
    }
    // 添加物品
    public void AddItem(Player player, int itemId, int count)
    {
        var inventory = player.GetOrAddComponent<InventoryComponent>();

        var item = player.AddComponent<ItemComponent>();
        item.ItemId = itemId;
        item.Count = count;

        Log.Info($"Added item {itemId} x{count}, ItemEntity ID: {item.Id}");
    }
    // 查找物品
    public ItemComponent FindItemById(Player player, int itemId)
    {
        foreach (var entity in player.ForEachMultiEntity)
        {
            if (entity is ItemComponent item && item.ItemId == itemId)
            {
                return item;
            }
        }
        return null;
    }

    // 学习技能
    public void LearnSkill(Player player, int skillId, int level)
    {
        var skill = player.AddComponent<SkillComponent>();
        skill.SkillId = skillId;
        skill.Level = level;
        skill.CooldownEndTime = 0;
    }

    // 使用技能
    public bool UseSkill(Player player, long skillEntityId)
    {
        var skill = player.GetComponent<SkillComponent>(skillEntityId);
        if (skill == null)
        {
            Log.Error("Skill not found!");
            return false;
        }

        if (TimeHelper.Now < skill.CooldownEndTime)
        {
            Log.Warning("Skill is on cooldown!");
            return false;
        }

        // 执行技能逻辑
        // ExecuteSkill(skill);

        // 设置冷却时间
        // skill.CooldownEndTime = TimeHelper.Now + GetSkillCooldown(skill.SkillId);
        return true;
    }
}