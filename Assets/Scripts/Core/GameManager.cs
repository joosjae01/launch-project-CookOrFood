using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public PlayerController _playerController;

    private void Awake() => SetSingleton();
}
