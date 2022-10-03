using System.Text.RegularExpressions;
using UnityEngine;

public class Title : MonoBehaviour
{
    private SpriteRenderer render;
    private FloodFill fill;
    private string[] substrings;
    private int x, y;

    private void Start()
    {
        render = this.gameObject.GetComponent<SpriteRenderer>();
        fill = GetComponentInParent<FloodFill>();
    }
    private void OnMouseOver()
    {
        if(render.color == Color.white) render.color = Color.gray;

        if(fill.seedEnable)
        {
            if (Input.GetMouseButton(0))
            {
                substrings = Regex.Split(this.gameObject.name, "-");
                x = int.Parse(substrings[0]);
                y = int.Parse(substrings[1]);
                fill.seedX = x;
                fill.seedY = y;
                render.color = Color.green;
            }
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

}
