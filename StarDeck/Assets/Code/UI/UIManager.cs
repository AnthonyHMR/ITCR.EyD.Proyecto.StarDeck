using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Windows
    [SerializeField] private GameObject[] _windows;
    private int _pivot;

    public void SwitchTo(int newPivot)
    {
        _windows[_pivot].SetActive(false);
        _pivot = newPivot;
        _windows[_pivot].SetActive(true);
    }
}
