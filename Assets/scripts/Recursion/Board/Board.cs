using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Board Dependences")]
    public int widht;
    public int height;
    public int scale;
    public GameObject[,] boardParent;
    public GameObject titlePrefab;

    private float sizeX, sizeY;

    private void Start()
    {
        CreateBoard();
    }

    public void CreateBoard()
    {
        boardParent = new GameObject[height, widht];

        for (int Y = 0; Y < widht; Y++)
        {
            for (int X = 0; X < height; X++)
            {
                GameObject title = Instantiate(titlePrefab);
                title.name = $"{X}-{Y}";

                title.transform.parent = transform;
                title.transform.localScale *= scale;
                sizeX = title.transform.localScale.x;
                sizeY = title.transform.localScale.y;
                title.transform.position = new Vector3(sizeX * (0.5f + X), sizeY * (0.5f + Y), 0);
                
                boardParent[X, Y] = title;
            }
        }

        transform.position = new Vector3(sizeX * (-height / 2), sizeY * (-widht / 2), 0);
    }
}
