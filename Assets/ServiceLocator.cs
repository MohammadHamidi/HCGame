using System;
using UnityEngine;

public class ServiceLocator:MonoBehaviour
{
    public static ServiceLocator Instance;
    private SaveSystem _saveSystem;
    private AudioSystem _audioSystem;
    private AnimationSystem _animationSystem;

    public int LastSaveLevel { get; set; }
  

    

    private void Awake()
    {
        Instance = this;
        _audioSystem = new AudioSystem();
        _saveSystem = new SaveSystem();
        _animationSystem = new AnimationSystem();
        
    }

    public T Get<T>() where T : class
    {
        if (typeof(T)==typeof(SaveSystem))
        {
            return _saveSystem as T;
        }
        else if (typeof(T)==typeof(AudioSystem))
        {
            return _audioSystem as T;
        }
        else if (typeof(T)==typeof(AnimationSystem))
        {
            return _animationSystem as T;
        }
        
        return null as T;
    }


}