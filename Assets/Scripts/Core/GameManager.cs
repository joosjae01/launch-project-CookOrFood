using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.AppUI.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameManager : SingletonBehaviour<GameManager>
{
    public PlayerController CurrentPlayer;
    public PlayerData CurrentPlayerData;

    private void Awake() => SetSingleton();
    
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
    public void QuitGame() // 게임 종료
    {
        Application.Quit();
    }
}
