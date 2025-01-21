using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class DotweenManagedr : MonoBehaviour
{
    public GameObject target;
    public Ease ease;
    public LoopType loopType;
    public int index;

    public static event Action<int> itemClicked;
    private void Start()
    {

    }

    private void Update()
    {
            
     
    }
    private void OnMouseEnter()
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(target.transform.DOScale(Vector3.one *2, .3f)).SetEase(ease);
        

    }
    private void OnMouseUp()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(target.transform.DOScale(Vector3.one * 0, .3f)).SetEase(ease);
        mySequence.OnComplete(PrintSomeValue);
    }
    private void OnMouseExit()
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(target.transform.DOScale(Vector3.one , .3f)).SetEase(ease);

    }


    private  void PrintSomeValue()
    {
        itemClicked?.Invoke(index);
    }


}
