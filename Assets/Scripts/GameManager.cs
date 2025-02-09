using System;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem
{
    public int Load( string saveName )
    {
        return PlayerPrefs.GetInt(saveName, 0);
    }

    public void Save(int save, string saveName)
    {
        PlayerPrefs.SetInt(saveName, save);
    }
}
// State Pattern 

public abstract class BaseGameState
{
    // Setup
    public abstract void OnEnter();
    //Decision
    public abstract void onUpdate();
    //Cleanup
    public abstract void OnExit();
}

public class MenuState : BaseGameState
{


    public MenuState(BaseGameState _nextState,RectTransform menu,Button PlayButton)
    {
        
        nextState=_nextState;
        this.ManuRecTransform = menu;
        this.PlayButton = PlayButton;
        this.PlayButton.onClick.AddListener(ChangeState);
        StateChanged = false;
    }

    private void ChangeState()
    {
        StateChanged = true;
    }

    public Button PlayButton;
    public SaveSystem saveSystem;
    public BaseGameState nextState;
    public RectTransform ManuRecTransform;
    public bool StateChanged;
    public override void OnEnter()
    {
        // if (saveSystem == null)
        // {
        //     saveSystem = new SaveSystem();
        // }
        //
        // saveSystem.Load("PlayerProgress");
        ManuRecTransform.gameObject.SetActive(true);
        

    }

    public override void onUpdate()
    {
        if (StateChanged==true)
        {
            OnExit();
            nextState.OnEnter();
            
        }
    }

    public override void OnExit()
    {
        ManuRecTransform.gameObject.SetActive(false);
    }
}
public class LevelState : BaseGameState
{


    public LevelState(int _levelNumber,RectTransform GameMenu)
    {
        levelNumber=_levelNumber;    
        this.ManuRecTransform = GameMenu;
    }
    public SaveSystem saveSystem;
    public int levelNumber ;
    public RectTransform ManuRecTransform;
    public bool StateChanged;
    public override void OnEnter()
    {
      

      
        ManuRecTransform.gameObject.SetActive(true);
        // Create The Level 
        // Start Runner Running 
        //....

    }

    public override void onUpdate()
    {
        // If State Changed 
    }

    public override void OnExit()
    {
        // Turn on UI Element
    }
}

public enum GameState
{
    Menu,
    Game,
    LevelComplete,
    GameOver
}
public class GameManager : MonoBehaviour 
{
    public Button PlayButton;
    public RectTransform GameMenu;
    public RectTransform levelUI;
    public static GameManager instance;
    BaseGameState currentState=null;

    private void Start()
    {
        var levelstate = new LevelState(0, levelUI);
        var menuState=new MenuState(levelstate,GameMenu,PlayButton);
        currentState=menuState;
        currentState.OnEnter();
    }

    private void Update()
    {
        if (currentState==null)return;
        
        currentState.onUpdate();
    }

    private GameState gameState;

    public static Action<GameState> onGameStateChanged;


    public void LevelCompleted(int levelNumber)
    {
        PlayerPrefs.SetInt("Last Saved Level",levelNumber);
    }

    private int LoadProgress()
    {
        var lastUnlockedLevel=PlayerPrefs.GetInt("Last Saved Level");
        return lastUnlockedLevel;
    }

    private void Awake() 
    {
        if (instance != null) 
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
        }
    }

    public void SetGameState(GameState state) 
    {
        gameState = state;
        onGameStateChanged?.Invoke(state);
    }

    public bool IsGameState() 
    {
        return gameState == GameState.Game;
    }
}