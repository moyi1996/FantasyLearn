using Fantasy.Sphere;
using MemoryPack;

/// <summary>
/// 玩家等级变化事件
/// </summary>
[MemoryPackable]
public sealed partial class PlayerLevelChangedEvent : SphereEventArgs
{
    public long PlayerId { get; set; }
    public int OldLevel { get; set; }
    public int NewLevel { get; set; }
}