using Assets.Scripts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private ChestsConfig _config;
    [SerializeField] private int _requiredChestQuantity = 3;
    [SerializeField] private Player _player;
    [SerializeField] private Button _continueButton;

    private List<ChestController> _chestsControllers;

    private IChestsProvider _chestsProvider;

    private void Start()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClicked);
        _continueButton.gameObject.SetActive(false);

        _chestsProvider = new ChestsProvider(new RouletteRandomizer(), new ItemRandomizer());

        _chestsControllers = new List<ChestController>();

        var configuratedChests = _chestsProvider.GetConfiguratedChests(_requiredChestQuantity, _config);

        SpawnChests(configuratedChests);
    }

    private void SpawnChests(List<ChestModel> chestsData)
    {
        int offset = 0;

        foreach (var chest in chestsData)
        {
            var chestView = Instantiate(chest.ChestPrefab, new Vector2(offset, 0), Quaternion.identity);

            ChestController chestController = new ChestController(chest, chestView.GetComponent<ChestView>());

            chestController.ChestView.Clicked += () => OnChestClicked(chestController);

            _chestsControllers.Add(chestController);

            offset++;
        }
    }

    private async void OnChestClicked(ChestController chestController)
    {
        chestController.Open();

        _player.AddItemsToInventory(chestController.GetItems());

        DisableColliderInChests();

        await Task.Delay(2500);

        if (_continueButton != null)
        {
            _continueButton.gameObject.SetActive(true);
        }
    }

    private void OnContinueButtonClicked()
    {
        DestroyAllChests();

        _chestsControllers.Clear();

        var configuratedChests = _chestsProvider.GetConfiguratedChests(_requiredChestQuantity, _config);

        SpawnChests(configuratedChests);

        _continueButton.gameObject.SetActive(false);
    }

    private void DisableColliderInChests()
    {
        foreach (var chest in _chestsControllers)
        {
            chest.DisableCollider();
        }
    }

    private void DestroyAllChests()
    {
        foreach (var chest in _chestsControllers)
        {
            var chestView = chest.ChestView;

            Destroy(chestView.gameObject);
        }
    }
}

