using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // 삭제

public class TempAudioManager : SingletonBehaviour<TempAudioManager>
{
    [SerializeField] private AudioSource _sfxPrefab; // 효과음 재생 프리팹
    [SerializeField] private AudioSource _bgmPrefab; // 배경음 재생 프리팹
    [SerializeField] private List<AudioInfo> _audioInfo = new();
    
    private Dictionary<SFXType, AudioClip> _sfxDict;
    private Dictionary<BGMType, AudioClip> _bgmDict;
    private AudioSource _sfxPlayer;
    private AudioSource _bgmPlayer;

    private void Awake()
    {
        SetSingleton();
        _sfxDict = new ();
        _bgmDict = new ();
    }

    private void OnEnable()
    {
        _sfxPlayer = Instantiate(_sfxPrefab, transform);
        _bgmPlayer = Instantiate(_bgmPrefab, transform);
    }

    private void Start()
    {
    }

    public void RequestBGM(BGMType bgmType)
    {
        _bgmPrefab.clip = _bgmDict[bgmType];
        _bgmPrefab.Play();
    }
}
