using System.Collections;
using UnityEngine;

public class FloodFill : MonoBehaviour
{
    public float fillDelay;
    private Board board;
    [HideInInspector]
    public int seedX, seedY;
    [HideInInspector]
    public bool seedEnable;

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
            StartCoroutine(Fill(seedX, seedY));
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
}
