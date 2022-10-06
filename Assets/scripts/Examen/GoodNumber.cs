using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodNumber : MonoBehaviour
{
    private int _number;
    private int _count;
    private bool _isGood;
    private List<int> _indexValidation;

    public int Number
    {
        get
        {
            return _number;
        }
        set
        {
            _number = value;
        }
    }

    public int Count
    {
        get
        {
            return _count;
        }
        set
        {
            _count = value;
        }
    }

    public bool isGood
    {
        get
        {
            return _isGood;
        }
        set
        {
            _isGood = value;
        }
    }

    public List<int> indexValidation
    {
        get
        {
            return _indexValidation;
        }
        set
        {
            _indexValidation = value;
        }
    }

    public void New(List<int> a)
    {
        indexValidation = a;
    }

    public void Show(int a)
    {
        List<int> n = indexValidation;
        if (n.Count - a == 0) Debug.Log("Elementos mostrados");
        else
        {
            Debug.Log(indexValidation[a]);
            a = a + 1;
            Show(a);
        }

    }

    public void Validate(int a)
    {
        List<int> n = indexValidation;

        if (n.Count - a == 0) Debug.Log("Elementos mostrados");
        else
        {
            int r = indexValidation[a];
            if(a % 2 == 0)
            {
               if(r % 2 == 0)
               {
                    a = a + 1;
                    Debug.Log("Es par");
                    Validate(a);
               }
               else
               {
                    Debug.Log("El contenido es incorrecto");
               }
            }
            if (a % 2 != 0)
            {
                if (r % 2 != 0)
                {
                    a = a + 1;
                    Debug.Log("Es primo");
                    Validate(a);
                }
                else
                {
                    Debug.Log("El contenido es incorrecto");
                }
            }
        }

        
    }
}
