using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;




public class AudioSystem
{
}

public class AnimationSystem
{
}


public class TestSaveManger : MonoBehaviour
{
    
    int currentLevel = 0;
    [SerializeField] private TextMeshProUGUI text;
    SaveSystem saveSystem = new SaveSystem();
    private SaveSystem _saveSystem;
    private AudioSystem _audioSystem;
    private AnimationSystem _animationSystem;
    private string saveKey = "TestSaveManger";
    private void Start()
    {
        saveSystem = ServiceLocator.Instance.Get<SaveSystem>();
        _audioSystem = ServiceLocator.Instance.Get<AudioSystem>();
        _animationSystem = ServiceLocator.Instance.Get<AnimationSystem>();

        var _name=ServiceLocator.Instance.name;
        
        currentLevel = LoadProgress();
        UpdateText();
    }

    public void LevelCompleted()
    {
        currentLevel++;
        UpdateText();
        LevelCompleted(currentLevel);
    }

    private void UpdateText()
    {
        text.text = $" Current Level: {currentLevel}";
    }

    public void LevelCompleted(int levelNumber)
    {
       saveSystem.Save(levelNumber,saveKey);
    }

    private int LoadProgress()
    {
        return saveSystem.Load( saveKey );
    }


}
