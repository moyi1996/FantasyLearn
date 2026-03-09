using Fantasy;
using Fantasy.Entitas.Interface;
using Fantasy.Helper;

public class BuffSystem : UpdateSystem<BuffComponent>
{
    protected override void Update(BuffComponent self)
    {
        // 检查 Buff 是否过期
        if (TimeHelper.Now >= self.ExpireTime)
        {
            Log.Info($"Buff {self.BuffId} expired!");
            self.Dispose();
        }
    }
}