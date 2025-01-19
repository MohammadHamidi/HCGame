using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrowdCounter : MonoBehaviour
{
    [SerializeField] private Transform RunnerParent;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    private void Update()
    {
        _textMeshProUGUI.text = RunnerParent.childCount.ToString();
    }
}
