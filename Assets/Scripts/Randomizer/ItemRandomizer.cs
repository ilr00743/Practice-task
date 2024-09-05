using Assets.Scripts;
using System.Linq;

public class ItemRandomizer : IItemRandomizer
{
    public void AddRandomItemsToChest(ChestModel chest, ChestsConfig chestsConfig)
    {
        ChestConfig currentConfig = chestsConfig.Chests.First(c => chest.Name == c.Name);

        int itemMaxChance = currentConfig.Items.Max(i => i.DropChance);

        float itemRandomValue = UnityEngine.Random.Range(0, itemMaxChance);

        foreach (var item in currentConfig.Items)
        {
            if (itemRandomValue <= item.DropChance)
            {
                chest.AddItem(item);
            }
        }
    }
}
