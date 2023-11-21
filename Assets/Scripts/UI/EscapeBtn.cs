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
        if (!isclicked)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void KeyBoardBtnClick()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isclicked)
        {
            panel.transform.DOScaleX(panelXScale, panelOpenTime).SetUpdate(true);   
        }
        if(Input.GetKeyDown(KeyCode.Escape) && !isclicked)
        {
            panel.transform.DOScaleX(0f, panelOpenTime).SetUpdate(true);            
        }
    }
}
