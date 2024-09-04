using System;
using UnityEngine;

public class PlayerInput
{
    private IInput _input;
    private Camera _camera;

    public PlayerInput(Camera camera, IInput input)
    {
        _camera = camera;
        _input = input;
        _input.Clicked += OnClicked;
    }

    private void OnClicked(Vector3 position)
    {
        Ray ray = _camera.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<ChestView>(out var target))
            {
                target.HandleClick();
            }
        }
    }

    public void Update()
    {
        _input.Click();
    }
}
