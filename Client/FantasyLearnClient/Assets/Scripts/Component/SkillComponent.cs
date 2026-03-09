using Fantasy.Entitas;
using Fantasy.Entitas.Interface;

public class SkillComponent : Entity, ISupportedMultiEntity
{
    public int SkillId { get; set; }
    public int Level { get; set; }
    public long CooldownEndTime { get; set; }
}