using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private FloatingText _popupPrefab;

    public event Action Clicked;

    public void Open()
    {
        _animator.SetTrigger("Open");
    }

    public void HandleClick()
    {
        Clicked?.Invoke();
    }

    public void SpawnAddedItemText(List<Item> addedItems)
    {
        StartCoroutine(SpawnAddedItemTextCoroutine(addedItems));
    }

    private IEnumerator SpawnAddedItemTextCoroutine(List<Item> addedItems)
    {
        yield return new WaitForSeconds(0.5f);

        foreach (var item in addedItems)
        {
            var textPopup = Instantiate(_popupPrefab);
            textPopup.SetText(item.ItemType, item.Quantity);
            textPopup.PlayAnimation(transform);

            yield return new WaitForSeconds(0.3f);
        }
    }
}
