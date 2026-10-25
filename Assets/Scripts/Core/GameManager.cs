using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public PlayerController _playerController;

    private void Awake() => SetSingleton();
    
    // TODO : 게임 매니저가 해야되는 일들
    
    // 씬 이동 기능
    // pulbic Load 로비 씬 (타이틀, 메인게임 씬에서)
    // public Load 메인게임 씬 (로비 씬에서)
    
    // public 게임 정지 (일시정지 누르면, 게임 오버 되면)
    // Time.timeScale = 0
    
    // public 게임 재생 (일시정지에서, 게임 오버에서)
    // Time.timeScale = 1
    
    // TODO(제안사항) : 핸드폰에서 게임 외적으로 생기는 일들
    
    // 게임 중 홈화면으로 나가거나, 다른 앱으로 전환했을 때 게임 일시정지
    // OnApplicationPause(bool pauseStatus)가 실행된다고 한다.
    // 게임 정지 > 일시정지 창 Active(true)
    
    // 게임 중 전화가 와 팝업이 뜨거나, 상단 알림창 등을 내렸을 때처럼
    // 게임 바깥으로 '포커스'가 벗어났을 때 게임 일시 정지
    // OnApplicationFocus(bool focusStatus)가 실행된다고 한다.
    // 게임 정지 > 일시정지 창 Active(true)
}
