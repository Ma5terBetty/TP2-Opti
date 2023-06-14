using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject splashScreen;
    [SerializeField] private float splashScreenTime;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject pauseMenu;

    private float _currentTime;
    private bool _hasSplashEnded;

    private GameObject _currentCanvas;

    private void Start()
    {
        splashScreen.SetActive(true);
        mainMenu.SetActive(false);

        _currentCanvas = splashScreen;
    }

    private void Update()
    {
        if (splashScreenTime > 0)
        {
            splashScreenTime -= Time.deltaTime;
            if (splashScreenTime <= 0)
            {
                _hasSplashEnded = true;
                splashScreen.SetActive(false);
                GoToMainMenu();
            }
        }
    }

    public void SkipSplash()
    {
        if (_hasSplashEnded) return;
        splashScreenTime = 0.01f;
    }

    public void GoToMainMenu()
    {
        _currentCanvas.SetActive(false);
        _currentCanvas = mainMenu;
        _currentCanvas.SetActive(true);
        GameManager.Instance.ReloadLevel();
    }

    public void Play()
    {
        _currentCanvas.SetActive(false);
        _currentCanvas = null;
        GameManager.Instance.DisablePause();
    }

    public void GoToPause()
    {
        _currentCanvas = pauseMenu;
        _currentCanvas.SetActive(true);
        GameManager.Instance.EnablePause();
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
