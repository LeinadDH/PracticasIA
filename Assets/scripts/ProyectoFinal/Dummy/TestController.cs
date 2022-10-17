using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public int height, width;
    private Map map;
    public GameObject prefab;
    public float scale;
    public bool iso;
    public float offsetx;
    public float offsety;

    private void Start()
    {
        map = this.gameObject.GetComponent<Map>();
        map.Height = height;
        map.Width = width;
        map.IsIso = iso;
        map.OffsetX = offsetx;
        map.OffsetY = offsety;
        map.createMap(prefab, scale);
    }
}
