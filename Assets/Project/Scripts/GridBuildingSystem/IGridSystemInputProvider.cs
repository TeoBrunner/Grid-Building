using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridSystemInputProvider 
{
    public event Action<int> buildingChoosed;
    public event Action placingButtonPressed;
    public event Action demolishButtonPressed;

    public event Action<Vector2> pointerMovedInWorldSpace;
    public event Action pointerDownOnGrid;
}
