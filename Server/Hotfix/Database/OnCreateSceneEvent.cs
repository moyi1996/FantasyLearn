using Fantasy;
using Fantasy.Event;
using Fantasy.Async;
using Fantasy.Database;
using Fantasy.Entitas;
using Fantasy.Entitas.Interface;
using Fantasy.SeparateTable;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;


// 定义可持久化的实体
public class Player : Entity, ISupportedSerialize
{
    public string Name { get; set; }
    public int Level { get; set; }
    public long Gold { get; set; }
    public string Age { get; set; }
}
public class ItemData
{
    public int ItemId { get; set; }
    public int Count { get; set; }
}
public class EquipmentData
{
    public int EquipId { get; set; }
}
public class QuestProgress
{
    public int QuestId { get; set; }
    public int Progress { get; set; }
}
// 背包分表
[SeparateTable(typeof(Player), "PlayerInventory")]
public class PlayerInventoryEntity : Entity
{
    public List<ItemData> Items { get; set; }
}

// 装备分表
[SeparateTable(typeof(Player), "PlayerEquipment")]
public class PlayerEquipmentEntity : Entity
{
    [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
    public Dictionary<int, EquipmentData> Equipments { get; set; }
}

// 好友分表
[SeparateTable(typeof(Player), "PlayerFriends")]
public class PlayerFriendsEntity : Entity
{
    public List<long> FriendIds { get; set; }
}

// 任务分表
[SeparateTable(typeof(Player), "PlayerQuests")]
public class PlayerQuestsEntity : Entity
{
    [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
    public Dictionary<int, QuestProgress> ActiveQuests { get; set; }
}

public sealed class OnCreateSceneEvent : AsyncEventSystem<OnCreateScene>
{
    protected override async FTask Handler(OnCreateScene self)
    {
        var scene = self.Scene;

        // 根据 SceneType 执行不同的初始化逻辑
        switch (scene.SceneType)
        {
            case SceneType.Gate:
                Log.Info($"Gate Scene 启动: {scene.RuntimeId}");
                var database = scene.World.Database;
                // Gate 初始化逻辑

                // var player = Entity.Create<Player>(scene, isPool: true, isRunEvent: true);
                // player.Name = "李四";
                // player.Level = 1;
                // player.Gold = 100;
                // await database.Save(player);
                // var players = await database.Query<Player>(p => p.Name == "李四");
                // if (players.Count > 0)
                // {
                //     Log.Info($"Player found: {players.Count}");
                //     Log.Info($"Player: {players[0].Name}");
                //     players[0].Deserialize(scene);
                //     await database.Remove<Player>(1, p => p.Name == "李四");
                // }
                // else
                // {
                //     Log.Info("Player not found");
                // }
                var player = await database.Query<Player>(644451596689997837);
                if (player != null)
                {
                    player.Deserialize(scene);
                    Log.Info($"Player: {player.Name}");
                }


                #region 分表
                // 创建主实体
                // var player = Entity.Create<Player>(scene, isPool: true, isRunEvent: true);
                // player.Name = "玩家001";
                // player.Level = 50;

                // // 添加分表组件
                // var inventory = player.AddComponent<PlayerInventoryEntity>();
                // inventory.Items = new List<ItemData>
                // {
                //     new ItemData { ItemId = 1001, Count = 10 },
                //     new ItemData { ItemId = 1002, Count = 5 }
                // };

                // var equipment = player.AddComponent<PlayerEquipmentEntity>();
                // equipment.Equipments = new Dictionary<int, EquipmentData>
                // {
                //     { 1, new EquipmentData { EquipId = 2001 } },
                //     { 2, new EquipmentData { EquipId = 2002 } }
                // };

                // // 方式 1: 保存聚合根及所有分表组件（默认）
                // await player.PersistAggregate(database);

                // // // 方式 2: 只保存分表组件，不保存聚合根本身
                // // await player.PersistAggregate(isSaveSelf: false, database);

                // 加载聚合实体
                // var player = await database.LoadWithSeparateTables<Player>(p => p.Name == "玩家001");
                // if (player != null)
                // {
                //     player.Deserialize(scene);
                //     var inventory = player.GetComponent<PlayerInventoryEntity>();
                //     var equipment = player.GetComponent<PlayerEquipmentEntity>();
                //     var friends = player.GetComponent<PlayerFriendsEntity>();
                //     var quests = player.GetComponent<PlayerQuestsEntity>();
                //     Log.Info($"Inventory: {inventory.Items.Count}");
                //     Log.Info($"Equipment: {equipment.Equipments.Count}");
                //     Log.Info($"Friends: {(friends != null ? friends.FriendIds.Count : 0)}");
                //     Log.Info($"Quests: {(quests != null ? quests.ActiveQuests.Count : 0)}");
                // }



#endregion

                break;
        }

        await FTask.CompletedTask;
    }
}