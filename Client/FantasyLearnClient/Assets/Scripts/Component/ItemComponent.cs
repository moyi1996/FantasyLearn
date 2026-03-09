using Fantasy.Entitas;
using Fantasy.Entitas.Interface;

public class ItemComponent : Entity, ISupportedMultiEntity
{
    public int ItemId { get; set; }
    public int Count { get; set; }
    public int Quality { get; set; }
}