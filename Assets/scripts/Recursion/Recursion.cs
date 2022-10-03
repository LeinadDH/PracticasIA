using System.Collections.Generic;
using UnityEngine;

public class Recursion : MonoBehaviour
{
    [Header ("Recursion Dependencies")]
    public int factorial;
    public int fibbonacci;
    public int[] array;
    public List<float> list;

    public void Button()
    {
        Debug.Log("Factorial de " + factorial + ": " + Factorial(factorial));
        Debug.Log("Fibbonacci de " + fibbonacci + ": " + Fibbonacci(fibbonacci));
        Debug.Log("El array contiene: " + ArrayCount(array) + " elementos");
        Debug.Log("La suma del contenido de la lista es: " + SumOfTheList(list));
    }

    int Factorial(int n)
    {
        if (n <= 1) return 1;
        return n * (Factorial(n - 1));
    }

    int Fibbonacci(int n)
    {
        if(n <= 0) return 0;
        if (n == 1) return 1;
        if (n == 2) return 2;
        return Fibbonacci(n - 1) + Fibbonacci(n  - 2) + 1;
    }

    int ArrayCount(int[] n)
    {
        if (n.Length == 0) return 0;
        return 1 + ArrayCount(n[1..]);
    }

    private float SumOfTheList(List<float> n)
    {
        if (n.Count == 0) return 0;
        return n[0] + SumOfTheList(n.GetRange(1, n.Count - 1));
    }
}
