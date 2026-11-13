using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // 삭제

public class TempAudioManager : SingletonBehaviour<TempAudioManager>
{
    [SerializeField] private AudioSource _sfxPrefab;
    
    private Dictionary<SFXType, AudioClip> _sfxDict;
    private AudioSource _sfxPlayer;

    public static TempAudioManager instance;
    public AudioClip[] SFXList;

    private void Awake()
    {
        SetSingleton();
        _sfxDict = new Dictionary<SFXType, AudioClip>();
    }

    private void OnEnable()
    {
        _sfxDict.Add(SFXType.PlayerHit, SFXList[0]);
        _sfxDict.Add(SFXType.PlayerThrowWeapon, SFXList[1]);
        _sfxDict.Add(SFXType.MonsterHit, SFXList[2]);
        _sfxPlayer = Instantiate(_sfxPrefab, transform);
    }

    private void Start()
    {
        Debug.Log($"효과음 사전 {0}번에 저장된 사운드: {_sfxDict[SFXType.PlayerHit].name}");
        Debug.Log($"효과음 사전 {1}번에 저장된 사운드: {_sfxDict[SFXType.PlayerThrowWeapon].name}");
        Debug.Log($"효과음 사전 {2}번에 저장된 사운드: {_sfxDict[SFXType.MonsterHit].name}");
        _sfxPlayer.clip = SFXList[0];
        _sfxPlayer.loop = true;
    }

    public void PlaySFX(InputAction.CallbackContext ctx)
    {
        _sfxPlayer.PlayOneShot(_sfxDict[SFXType.PlayerHit]);
        _sfxPlayer.PlayOneShot(_sfxDict[SFXType.PlayerThrowWeapon]);
        // _sfxPlayer.PlayOneShot(_sfxDict[SFXType.MonsterHit]);
    }
}
