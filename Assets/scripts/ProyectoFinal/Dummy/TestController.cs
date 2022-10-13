using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public int height, width;
    private Map map;
    public GameObject prefab;
    public int scale;

    private void Start()
    {
        map = this.gameObject.GetComponent<Map>();
        map.Height = height;
        map.Width = width;
        

        map.createMap(prefab, scale);
    }
}
