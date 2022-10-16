using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Palindrome : MonoBehaviour
{
    // Fields
    private int _size;
    private int _count;
    private string _palindrome;
    private string _TempPalindrome;
    private string _value;
    private bool _isPalindrome;
    private List<string> _addList = new List<string>();
    private List<string> _revert = new List<string>();


    // Properties
    public string palindrome
    {
        get { return _palindrome; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("No se admiten strings vacios");
            }
            _palindrome = value;
        }
    }

    public string value
    {
        get { return _value; }
        set { _value = value; }
    }

    public string Show()
    {
        return _palindrome;
    }

    public bool isPalindrome()
    {
        Revert(0);
        CheckPalindrome(0);
        return _isPalindrome;
    }

    void Revert(int i)
    {
        try
        {
            _revert.Add(_palindrome[i].ToString());
            _size = _revert.Count;
            Revert(i + 1);
        }
        catch { return; }
    }

    void CheckPalindrome(int i)
    {
        try
        {
            string letter = _palindrome[i].ToString();
            if (letter != _palindrome[_size - 1].ToString())
            {
                _isPalindrome = false;
                return;
            }
            _revert.Remove(_palindrome[i].ToString());
            _revert.Remove(_palindrome[_size - 1].ToString());
            _size--;
            _isPalindrome = true;
            CheckPalindrome(i + 1);
        }
        catch { return; }
    }

    public void New(string p)
    {
        if (string.IsNullOrEmpty(p))
        {
            Debug.LogError("No se admiten strings vacios");
        }
        _revert.Clear();
        _palindrome = p;
    }

    private void RedoPalindrome(int j)
    {
        try
        {
            _TempPalindrome = _TempPalindrome + _revert[j];
            RedoPalindrome(j + 1);
        }
        catch { return; }

    }

    public void Remove(int i)
    {
        try
        {
            Revert(0);
            _size = _revert.Count;
            _revert.RemoveAt(_size - 1 - i);
            _revert.RemoveAt(i);
            _TempPalindrome = string.Empty;
            RedoPalindrome(0);
            _palindrome = _TempPalindrome;
            _revert.Clear();
            Debug.Log(_palindrome);
        }
        catch
        {
            Debug.LogError("Su string esta vacio o el index esta fuera de rango");
        }        
    }

    private void AddToPalindrome(int i, int j, string a)
    {
        if(j <= Mathf.Abs(_size/2))
        {
            try
            {
                if (i == j)
                {
                    _addList.Add(a);
                    _addList.Add(_palindrome[i].ToString());

                }
                if (_addList.Count == _size + 1 - j)
                {
                    _addList.Add(a);
                }
                if (i != j)
                {
                    _addList.Add(_palindrome[i].ToString());
                }
                AddToPalindrome(i + 1, j, a);
            }
            catch { return; }
        }
        else
        {
            Debug.LogError("El index que desea agregar esta fuera de rango");
        }
        
    }

    private void RedoAdd(int i)
    {
        try
        {
            _TempPalindrome = _TempPalindrome + _addList[i];
            RedoAdd(i + 1);
        }
        catch { return; }
    }

    public void Add(int i, string a)
    {
        Revert(0);
        AddToPalindrome(0, i, a);
        _TempPalindrome = string.Empty;
        RedoAdd(0);
        _palindrome = _TempPalindrome;
        _addList.Clear();
        _revert.Clear();
        Debug.Log(_palindrome);
    }

    private void MultipliPalindrom(int i, int j)
    {
        if(i <= j)
        {
            _palindrome = _palindrome + _palindrome;
            MultipliPalindrom(i + 1, j);
        }
        else
        {
            return;
        }
        
    }

    public void Multiply(int i)
    {
        MultipliPalindrom(1, i);
        Debug.Log(_palindrome);
    }
}
