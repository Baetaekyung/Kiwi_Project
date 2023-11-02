using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottonClick : MonoBehaviour
{
    public GameObject panel;
    public Image image;
    public bool isclicked = false;
    public float panelOpenTime;
    public string bottonName;
    public WaitForSeconds wfs;

    public void IsClicked()
    {
        isclicked = !isclicked;
    }
}
