using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int _x;
    private int _y;
    private SpriteRenderer _render;
    private Color _color;
    //private MapManager _manager;
    private int _obstacle;
    private int _moveCost;

    public int X { get => _x; set => _x = value; }
    public int Y { get => _y; set => _y = value; }

    private void Awake()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnMouseOver()
    {
        
    }

    private void OnMouseExit()
    {
        
    }
}

