using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [Header("Board Dependences")]
    public int Widht;
    public int height;
    public GameObject boardParent;
    public GameObject titlePrefab;

    public void CreateBoard()
    {
        for (int i = 0; i < Widht; i++)
        {
            for (int j = 0; j < height; j++)
            {
                boardParent = Instantiate(titlePrefab);
                titlePrefab.name = $"{i}-{j}";

                titlePrefab.transform.parent = transform;
            }
        }
    }
}
