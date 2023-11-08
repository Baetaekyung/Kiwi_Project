using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EscapeBtn : BottonClick, IBottonClick
{
    [SerializeField]
    private float panelXScale;

    public void BottonClickEvent()
    {
        if (!isclicked)
        {
            panel.transform.DOScaleX(0f, panelOpenTime);
            isclicked = true;
        }
    }

    private void Start()
    {
        panel.transform.DOScaleX(0f, panelOpenTime);
        isclicked = false;        
    }
    private void Update()
    {
        KeyBoardBtnClick();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isclicked = !isclicked;
        }
    }

    public void KeyBoardBtnClick()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isclicked)
        {
            panel.transform.DOScaleX(panelXScale, panelOpenTime);
        }
        if(Input.GetKeyDown(KeyCode.Escape) && !isclicked)
        {
            panel.transform.DOScaleX(0f, panelOpenTime);
        }
    }
}
