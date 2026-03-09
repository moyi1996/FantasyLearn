// Awake 事件（实体创建时触发）
using Fantasy;
using Fantasy.Entitas.Interface;

public class PlayerAwakeSystem : AwakeSystem<Player>
{
    protected override void Awake(Player self)
    {
        Log.Info("Player created!");
    }
}

// Update 事件（每帧触发）
public class PlayerUpdateSystem : UpdateSystem<Player>
{
    protected override void Update(Player self)
    {
        // 每帧逻辑
    }
}

// Destroy 事件（实体销毁时触发）
public class PlayerDestroySystem : DestroySystem<Player>
{
    protected override void Destroy(Player self)
    {
        Log.Info("Player destroyed!");
    }
}

// Deserialize 事件（从数据库加载时触发）
public class PlayerDeserializeSystem : DeserializeSystem<Player>
{
    protected override void Deserialize(Player self)
    {
        // 反序列化后的初始化逻辑
    }
}