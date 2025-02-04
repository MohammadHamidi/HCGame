using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] Button _button;


    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Play);
    }

    private void Play()
    {
        GameManager.instance.SetGameState(GameState.Game);
        gameObject.SetActive(false);
    }

}
