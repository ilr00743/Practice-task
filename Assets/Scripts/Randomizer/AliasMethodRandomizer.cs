using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;

public class AliasMethodRandomizer : IChestRandomizer
{
    private readonly float[] _prob;
    private readonly int[] _alias;
    private readonly int _n;

    public AliasMethodRandomizer(List<ChestConfig> configs)
    {
        _n = configs.Count;
        _prob = new float[_n];
        _alias = new int[_n];

        float[] scaledProb = new float[_n];
        List<int> small = new List<int>();
        List<int> large = new List<int>();

        float totalWeight = (float)configs.Sum(c => c.DropChance);
        for (int i = 0; i < _n; i++)
        {
            scaledProb[i] = configs[i].DropChance * _n / totalWeight;
            if (scaledProb[i] < 1.0f)
                small.Add(i);
            else
                large.Add(i);
        }

        while (small.Count > 0 && large.Count > 0)
        {
            int less = small[small.Count - 1];
            small.RemoveAt(small.Count - 1);
            int more = large[large.Count - 1];
            large.RemoveAt(large.Count - 1);

            _prob[less] = scaledProb[less];
            _alias[less] = more;

            scaledProb[more] = (scaledProb[more] + scaledProb[less]) - 1.0f;

            if (scaledProb[more] < 1.0f)
                small.Add(more);
            else
                large.Add(more);
        }

        while (large.Count > 0)
        {
            _prob[large[large.Count - 1]] = 1.0f;
            large.RemoveAt(large.Count - 1);
        }

        while (small.Count > 0)
        {
            _prob[small[small.Count - 1]] = 1.0f;
            small.RemoveAt(small.Count - 1);
        }
    }

    public int Next()
    {
        int column = UnityEngine.Random.Range(0, _n);
        bool coinToss = UnityEngine.Random.value < _prob[column];
        return coinToss ? column : _alias[column];
    }

    public ChestModel ConfigurateRandomChest(ChestsConfig chestsConfig)
    {
        var chestIndex = Next();

        var newChest = new ChestModel(chestsConfig.Chests[chestIndex].Name, chestsConfig.Chests[chestIndex].ChestPrefab, chestsConfig.Chests[chestIndex].DropChance);

        return newChest;
    }
}
