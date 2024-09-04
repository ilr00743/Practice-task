using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;

public class RouletteRandomizer : IChestRandomizer
{
    public ChestModel ConfigurateRandomChest(ChestsConfig chestsConfig)
    {
        var availableChests = new List<ChestConfig>(chestsConfig.Chests);

        float totalChance = availableChests.Sum(chest => chest.DropChance);
        float randomValue = UnityEngine.Random.Range(0, totalChance);

        foreach (var chest in availableChests)
        {
            randomValue -= chest.DropChance;

            if (randomValue <= 0)
            {
                var newChest = new ChestModel(chest.Name, chest.ChestPrefab, chest.DropChance);

                return newChest;
            }
        }

        ChestModel defaultChest = new ChestModel(
            availableChests.First().Name,
            availableChests.First().ChestPrefab,
            availableChests.First().DropChance);

        return defaultChest;
    }
}
