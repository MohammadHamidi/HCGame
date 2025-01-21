using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CowdCounter : MonoBehaviour
{

    [SerializeField] Transform runnerParent;
    [SerializeField] TextMeshProUGUI text;

    private void Update()
    {
        int runnersCount=runnerParent.childCount;
        text.text= runnersCount.ToString();
    }
}
