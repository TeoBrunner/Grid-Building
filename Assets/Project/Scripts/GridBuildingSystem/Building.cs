using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] SpriteRenderer mainRenderer;

    public void TurnGhost(bool available)
    {
        if(available)
        {
            mainRenderer.color = new Color(0, 1, 0, 0.75f); //transparent green
        }
        else
        {
            mainRenderer.color = new Color(1, 0, 0, 0.75f); //transparent red
        }
    }
    public void TurnSolid()
    {
        mainRenderer.color = Color.white;
    }
}
