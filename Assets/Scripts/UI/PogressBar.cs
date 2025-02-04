using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PogressBar : MonoBehaviour
{
    
    [SerializeField] private Image fillBarImage;

    private void Start()
    {
        if (fillBarImage == null)
        {
            //Debug.LogError($"FillBar Image is Null");
            FindFillBarImage().fillAmount=0;
            
        }
        else
        {
            fillBarImage.fillAmount = 0;
        }
    }

    public Image FindFillBarImage()
    {                   
        fillBarImage = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
        return fillBarImage;
    }
    public void SetFill(float fillAmount)
    {
        fillBarImage.fillAmount = fillAmount;
    }



}
