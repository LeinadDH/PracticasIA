using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recursion : MonoBehaviour
{
    public int factorialOfNumber;

    public void Button()
    {
        Debug.Log(Factorial(factorialOfNumber));
    }

    int Factorial(int n)
    {
        if (n <= 1) return n;
        n = n * Factorial(n-1);
        return n;
    }
}
