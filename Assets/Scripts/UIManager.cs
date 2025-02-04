using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    [Header("Elements")]
    //[SerializeField] private GameObject menuPanel;
    //[SerializeField] private GameObject gamePanel;
    
    [SerializeField] private PogressBar progressBar;
    [SerializeField] bool isGamePlaying = false;

    //[SerializeField] private TextMeshProUGUI levelText;

    private void Start()
    {
        isGamePlaying = false;
    }
    //private void Start() 
    //{
    //    progressBar.value = 0;
    //    gamePanel.SetActive(false);
    //    UpdateLevelText();
    //}

    private void Update()
    {   if(!isGamePlaying)return; 
        progressBar.SetFill(ChunkManager.instance.GetPlayerProgress());
    }

    //public void PlayButtonPressed() 
    //{
    //    menuPanel.SetActive(false);
    //    gamePanel.SetActive(true);
    //    GameManager.instance.SetGameState(GameManager.GameState.Game);
    //}

    //private void UpdateProgressBar() 
    //{
    //    float progress = ChunkManager.instance.GetPlayerProgress();
    //    progressBar.value = progress;
    //}

    //private void UpdateLevelText() 
    //{
    //    levelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);
    //}
}