using Fantasy.Entitas;
using Fantasy.Entitas.Interface;

// 实现 ISupportedMultiEntity 接口
public class BuffComponent : Entity, ISupportedMultiEntity
{
    public int BuffId { get; set; }
    public int BuffType { get; set; }
    public float Value { get; set; }
    public long ExpireTime { get; set; }
}