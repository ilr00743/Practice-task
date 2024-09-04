using Assets.Scripts;
using System.Collections.Generic;

public interface IChestsProvider
{
    public List<ChestModel> GetConfiguratedChests(int requiredQuantity, ChestsConfig chestsConfig);
}
