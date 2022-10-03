using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    private SpriteRenderer render;

    private void Start()
    {
        render = this.gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnMouseOver()
    {
        if(render.color == Color.white) render.color = Color.gray;
        if (Input.GetMouseButton(0))
        {
            render.color = Color.red;
        }
        if (Input.GetMouseButton(1))
        {
            render.color = Color.blue;
        }
    }

    private void OnMouseExit()
    {
        if(render.color == Color.gray) render.color = Color.white;        
    }

    private void OnMouseDown()
    {
        

    }
}
