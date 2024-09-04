using System;
using UnityEngine;

public class MouseInput : IInput
{
    private readonly int _leftButton = 0;

    public event Action<Vector3> Clicked;

    public void Click()
    {
        if (Input.GetMouseButtonDown(_leftButton))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}