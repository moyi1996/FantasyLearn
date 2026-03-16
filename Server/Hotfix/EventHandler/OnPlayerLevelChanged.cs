using Fantasy.Sphere;
using Fantasy.Async;
using Fantasy;

/// <summary>
/// 处理玩家等级变化事件
/// </summary>
public sealed class OnPlayerLevelChanged : SphereEventSystem<PlayerLevelChangedEvent>
{
    protected override async FTask Handler(Scene scene, PlayerLevelChangedEvent args)
    {
        Log.Info($"[Map] 收到玩家等级变化: PlayerId={args.PlayerId}, {args.OldLevel} -> {args.NewLevel}");

        // 业务逻辑 1: 更新地图内的玩家信息

        // 业务逻辑 2: 触发地图内的特效
        await ShowLevelUpEffect(scene, args.PlayerId);

        // 业务逻辑 3: 检查是否解锁新区域
        await CheckUnlockMapArea(scene, args.PlayerId, args.NewLevel);
    }

    private async FTask ShowLevelUpEffect(Scene scene, long playerId)
    {
        // 显示升级特效逻辑
        await FTask.CompletedTask;
    }

    private async FTask CheckUnlockMapArea(Scene scene, long playerId, int level)
    {
        // 检查解锁地图区域逻辑
        await FTask.CompletedTask;
    }
}