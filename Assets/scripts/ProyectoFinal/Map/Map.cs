using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private GameObject[,] _map;
    private int _height;
    private int _width;
    private Vector2 _rotX;
    private Vector2 _rotY;
    private float _offset;
    private bool _isIso;
    private int _order;

    private float _sizeX, _sizeY;

    public int Height{ get => _height; set => _height = value;}

    public int Width { get => _width; set => _width = value; }

    public GameObject[,] createMap(GameObject prefab, int scale, Sprite sprite = null, bool iso = false)
    {
        _map = new GameObject[_height, _width];
        for(int Y = 0; Y < _width; Y++)
        {
            for(int X = 0; X < _height; X++)
            {
                GameObject title = Instantiate(prefab);
                title.name = $"{X}-{Y}";

                title.transform.parent = transform;
                title.transform.localScale *= scale;
                _sizeX = title.transform.localScale.x;
                _sizeY = title.transform.localScale.y;
                title.transform.position = new Vector3(_sizeX * (0.5f + X), _sizeY * (0.5f + Y), 0);

                _map[X, Y] = title; 
            }
        }

        transform.position = new Vector3(_sizeX * (-_height / 2), _sizeY * (-_width / 2), 0);

        return _map;
    }
}
