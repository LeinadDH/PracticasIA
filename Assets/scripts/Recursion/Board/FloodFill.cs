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

        /*
        if(Input.GetKeyDown("space"))
        {
            StartCoroutine(Fill(seedX, seedY));
        }
        */
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(FillQueue(seedX, seedY));
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

    IEnumerator FillQueue(int x, int y)
    {
        Vector2 fillPos = new Vector2(x, y);
        Queue<Vector2> fill = new Queue<Vector2>();
        fill.Enqueue(fillPos);
        while (fill.Count > 0)
        {
            fill.Dequeue();
            if (x >= 0 && x < board.widht && y >= 0 && y < board.height)
            {
                SpriteRenderer currentRender = board.boardParent[x, y].GetComponent<SpriteRenderer>();
                yield return new WaitForSeconds(fillDelay);
                if (currentRender.color == Color.white || currentRender.color == Color.green)
                {
                    currentRender.color = Color.red;
                    if (x + 1 < board.widht) fill.Enqueue(new Vector2((x + 1), y));
                    if (x - 1 <= board.widht) fill.Enqueue(new Vector2((x - 1), y));
                    if (y + 1 < board.height) fill.Enqueue(new Vector2(x, (y + 1)));
                    if (y - 1 <= board.height) fill.Enqueue(new Vector2(x, (y - 1)));
                }
            }
        }
    }
}
