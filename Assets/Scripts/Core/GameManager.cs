using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public PlayerController CurrentPlayer;
    public PlayerData CurrentPlayerData;
    public WeaponData CurrentWeaponData;

    // ---------- Event Method ----------
    
    private void Awake()
    {
        SetSingleton();
    }
    
    // ----------------------------------

    
    public void LoadLobbyScene() // 로비
    {
        // SceneManager.LoadScene("Lobby");
    }
    
    public void LoadMainGameScene() // 메인게임
    {
        // SceneManager.LoadScene("MainGame");
    }
    
    
    public void PauseGame() // 게임 정지
    {
        Time.timeScale = 0;
    }
    
    public void ResumeGame() // 게임 재생
    {
        Time.timeScale = 1;
    }
    
    
    public void QuitGame() // 게임 종료
    {
        Application.Quit();
    }
}
