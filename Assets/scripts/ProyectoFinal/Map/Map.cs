using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Map : MonoBehaviour
{
    private GameObject[,] _map;
    private int _height;
    private int _width;
    private Vector2 _rotX;
    private Vector2 _rotY;
    private float _offsetx;
    private float _offsety;
    private bool _isIso;
    private int _order;
    private Block _start;
    private Block _goal;

    private float _sizeX, _sizeY;

    public GameObject[,]  Mapa { get => _map; set => _map = value; }
    public int Height { get => _height; set => _height = value;}

    public int Width { get => _width; set => _width = value; }

    public float OffsetX { get => _offsetx; set => _offsetx = value; }
    public float OffsetY { get => _offsety; set => _offsety = value; }

    public bool IsIso { get => _isIso; set => _isIso = value; }

    public Block Start { get => _start; set => _start = value; }

    public Block Goal { get => _goal; set => _goal = value; }

    public GameObject[,] createMap(GameObject prefab, float scale = 1, Sprite sprite = null, bool iso = false)
    {
        _map = new GameObject[_width, _height];

        for(int Y = 0; Y < _height; Y++)
        {
            for(int X = 0; X < _width; X++)
            {
                GameObject title = Instantiate(prefab);

                AddMissingComponent(title);
                Block block = title.GetComponent<Block>();
                block.X = X;
                block.Y = Y;

                title.name = $"{X}-{Y}";
                title.transform.parent = transform;
                title.transform.localScale *= scale;
                _sizeX = title.transform.localScale.x;
                _sizeY = title.transform.localScale.y;
                title.transform.position = new Vector3(_sizeX * (0.5f + X), _sizeY * (0.5f + Y), 0);

                if (_isIso)
                {
                    createIsoMap(title, title.GetComponent<SpriteRenderer>(), block.X, block.Y);
                }

                _map[X, Y] = title; 
            }
        }

        CenterMap();

        return _map;
    }

    private void AddMissingComponent(GameObject gameObject)
    {
        if (gameObject.GetComponent<Block>() == null) { gameObject.AddComponent<Block>(); }
    }

    public void createIsoMap(GameObject gameObject, SpriteRenderer render, int x, int y)
    {
        _rotX = new Vector2(0.5f * (render.bounds.size.x + _offsetx), 0.25f * (render.bounds.size.y + _offsety));
        _rotY = new Vector2(-0.5f * (render.bounds.size.x + _offsetx), 0.25f * (render.bounds.size.y + _offsety));

        Vector2 rotate = (x * _rotX) + (y * _rotY);
        gameObject.transform.position = rotate;

        render.sortingOrder = _order;
        _order -= 1;
    }

    public void CenterMap()
    {
        if(!_isIso) transform.position = new Vector3(_sizeX * (-_width / 2), _sizeY * (-_height / 2), 0);
        else transform.position = new Vector3(0, _sizeY * (-_height * 2f - (0.4f * _height)), 0);
    }
}
