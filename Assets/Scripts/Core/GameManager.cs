using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.AppUI.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] private InputActionReference _backAction;
    public PlayerController _playerController;
    public Panel _pausePanel; // 일시정지 판넬
    public Panel _quitPanel; // 게임 종료 판넬

    private void Awake() => SetSingleton();

    private void Start()
    {
        Screen.fullScreen = false;
    }

    private void OnEnable()
    {
        _backAction.action.Enable();
    }

    private void OnNavigationButton(InputAction.CallbackContext ctx)
    {
        _backAction.action.performed += QuitGame;
    }
    
    // [씬 이동] -----------------------------------------
    public void LoadLobbyScene() // 로비
    {
        // SceneManager.LoadScene("Lobby");
    }
    
    public void LoadMainGameScene() // 메인게임
    {
        // SceneManager.LoadScene("MainGame");
    }
    
    // [게임 정지/재생] ---------------------------------
    public void PauseGame() // 게임 정지
    {
        Time.timeScale = 0;
    }
    
    public void ResumeGame() // 게임 재생
    {
        Time.timeScale = 1;
    }
    
    // [게임 종료] -------------------------------------------
    public void QuitGame(InputAction.CallbackContext ctx) // 게임 종료
    {
        if (_quitPanel != null)
        {
            // _quitPanel 활성화
            Debug.Log("Quit : 활성화 시도");
        }
    }
    
    // [게임이 백그라운드로 내려갔을 때] ----------------------------------
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            if (_pausePanel != null)
            {
                PauseGame();
                // _pausePanel 활성화
            }
        }
    }
    
    // [게임이 포커스를 잃었을 때] -----------------------------------------
    private void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
        {
            Debug.Log("Focus : 게임에 들어옴");
        }
        else
        {
            if (_pausePanel != null)
            {
                PauseGame();
                // _pausePanel 활성화
            }
        }
    }
}
