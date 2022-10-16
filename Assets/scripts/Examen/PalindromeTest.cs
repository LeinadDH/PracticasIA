using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalindromeTest : MonoBehaviour
{
    public GameObject p;
    public string myPalindrom;
    private Palindrome palindrom;
    public int indexToRemoveOrToAdd;
    public string stringToAdd;
    public int timesToMultiply;

    void Start()
    {
        palindrom = p.GetComponent<Palindrome>();
    }

    public void ShowP()
    {
        palindrom.Show();
        Debug.Log(palindrom.palindrome);
    }

    public void isPalindromP()
    {
        Debug.Log("Tu palidromo es:" + palindrom.isPalindrome());
    }

    public void NewP()
    {
        palindrom.New(myPalindrom);
        Debug.Log("Se añadio palindromo");
    }

    public void RemoveP()
    {
        palindrom.Remove(indexToRemoveOrToAdd);
    }

    public void Addp()
    {
        palindrom.Add(indexToRemoveOrToAdd, stringToAdd);
    }

    public void MultiplyP()
    {
        palindrom.Multiply(timesToMultiply);
    }
}
