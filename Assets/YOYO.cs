// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using DG.Tweening;
// public class YOYO : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         YoYoMovment();
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyUp(KeyCode.S))
//         {
//             Time.timeScale = .1f;
//
//         }
//         else if (Input.GetKeyUp(KeyCode.N))
//         {
//             Time.timeScale = 1f;
//         }
//     }
//
//     private void YoYoMovment()
//     {
//         transform.DOMoveY(4, .4f).SetLoops(-1,LoopType.Yoyo);
//         transform.DOMoveX(2, .4f).SetLoops(-1,LoopType.Yoyo);
//     }
//
// }
