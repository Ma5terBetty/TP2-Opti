using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UnityAction OnLevelReload;

    public bool IsPaused { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EnablePause();
    }
    public void DisablePause()
    {
        IsPaused = false;
    }
    public void EnablePause()
    {
        IsPaused = true;
    }

    public void ReloadLevel()
    {
        OnLevelReload?.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
