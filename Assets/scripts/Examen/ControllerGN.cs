using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGN : MonoBehaviour
{
    public int number;
    public int isGood;
    public List<int> indexValidation;
    private GoodNumber GN;
    public GameObject Target;

    private int a = 0;
    private int j = 0;
    private void Start()
    {
        GN = Target.GetComponent<GoodNumber>();
    }

    public void AddButton()
    {
        indexValidation.Add(number);
        GN.New(indexValidation);
        Debug.Log("Correct Add");
    }

    public void ButtonShow()
    {
        GN.Show(a);
    }

    public void ButtonValidate()
    {
        GN.Validate(j);
    }
}
