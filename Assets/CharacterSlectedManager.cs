// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using DG.Tweening;
// public class CharacterSlectedManager : MonoBehaviour
// {
//     public GameObject[] items;
//     private void OnEnable()
//     {
//         DotweenManagedr.itemClicked += ChangeItem;
//     }
//     private void OnDisable()
//     {
//         DotweenManagedr.itemClicked -= ChangeItem;
//     }
//     private void ChangeItem(int index)
//     {
//         foreach (var item in items)
//         {
//             items[index].transform.localScale = Vector3.zero;
//             item.gameObject.SetActive(false);
//         }
//         items[index].gameObject.SetActive(true);
//         
//         // items[index].transform.DOScale(Vector3.one*3, .3f);
//     }
//
//
// }
