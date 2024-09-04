using Assets.Scripts;
using System.Collections.Generic;

public class ChestsProvider : IChestsProvider
{
    private IChestRandomizer _chestRandomize;
    private IItemRandomizer _itemRandomize;

    public ChestsProvider(IChestRandomizer chestRandomize, IItemRandomizer itemRandomize)
    {
        _chestRandomize = chestRandomize;
        _itemRandomize = itemRandomize;
    }

    public List<ChestModel> GetConfiguratedChests(int requiredQuantity, ChestsConfig chestsConfig)
    {
        var configuratedChests = new List<ChestModel>();

        for (int i = 0; i < requiredQuantity; i++)
        {
            var chestData = _chestRandomize.ConfigurateRandomChest(chestsConfig);

            _itemRandomize.AddRandomItemsToChest(chestData, chestsConfig);

            configuratedChests.Add(chestData);
        }

        return configuratedChests;
    }
}
