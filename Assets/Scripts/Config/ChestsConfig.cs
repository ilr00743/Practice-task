using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "ChestsConfig", menuName = "ChestGame/ChestsConfig")]
    public class ChestsConfig : ScriptableObject
    {
        [SerializeField] private List<ChestConfig> _chests;

        public IReadOnlyList<ChestConfig> Chests => _chests;
    }
}
