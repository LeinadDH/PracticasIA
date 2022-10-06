using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FloodFill : MonoBehaviour
{
    public float fillDelay;
    private Board board;
    [HideInInspector]
    public int seedX, seedY;
    [HideInInspector]
    public bool seedEnable;
    public bool queueFill;

    private GameObject[,] _grid;

    private void Start()
    {
        board = GetComponent<Board>();
        seedEnable = true;
    }

    private void Update()
    {
        foreach (var renders in board.boardParent)
        {
            if(renders.GetComponent<SpriteRenderer>().color == Color.green)
            {
                seedEnable = false;
            }
        }


        if(Input.GetKeyDown("space"))
        {
            if(!queueFill)
            {
                StartCoroutine(Fill(seedX, seedY));
            }
            if (queueFill)
            {
                StartCoroutine(FillQueue(new Vector2(seedX, seedY)));
            }
        }
    }

    IEnumerator Fill(int x, int y)
    {
        WaitForSeconds wait = new WaitForSeconds(fillDelay);

        if(x >= 0 &&  x < board.height && y >= 0 && y < board.widht)
        {
            yield return wait;
            SpriteRenderer currentRender = board.boardParent[x,y].GetComponent<SpriteRenderer>();
            if(currentRender.color == Color.white || currentRender.color == Color.green)
            {
                currentRender.color = Color.red;
                StartCoroutine(Fill(x + 1, y));
                StartCoroutine(Fill(x - 1, y));
                StartCoroutine(Fill(x, y + 1));
                StartCoroutine(Fill(x, y - 1));
            }
        }
    }

    IEnumerator FillQueue(Vector2 postile)
    {
        Queue<Vector2> fill = new Queue<Vector2>();
        fill.Enqueue(postile);
        while (fill.Count > 0)
        {
            postile = fill.Dequeue();
            if (postile.x >= 0 && postile.x < board.height && postile.y >= 0 && postile.y < board.widht)
            {
                SpriteRenderer currentRender = board.boardParent[(int)postile.x, (int)postile.y].GetComponent<SpriteRenderer>();
                yield return new WaitForSeconds(fillDelay);
                if (currentRender.color == Color.white || currentRender.color == Color.green)
                {
                    currentRender.color = Color.red;
                    if (postile.x + 1 < board.height) fill.Enqueue(new Vector2((postile.x + 1), postile.y));
                    if (postile.x - 1 <= board.height) fill.Enqueue(new Vector2((postile.x - 1), postile.y));
                    if (postile.y + 1 < board.widht) fill.Enqueue(new Vector2(postile.x, (postile.y + 1)));
                    if (postile.y - 1 <= board.widht) fill.Enqueue(new Vector2(postile.x,(postile.y - 1)));
                }
            }
        }
    }
}
