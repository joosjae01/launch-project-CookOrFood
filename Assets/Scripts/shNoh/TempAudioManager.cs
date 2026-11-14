using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // 삭제

public class TempAudioManager : SingletonBehaviour<TempAudioManager>
{
    [SerializeField] private AudioSource _sfxPrefab; // 효과음 재생 프리팹
    [SerializeField] private AudioSource _bgmPrefab; // 배경음 재생 프리팹
    [SerializeField] private List<BGMData> _bgmList;
    [SerializeField] private List<SFXData> _sfxList;
    
    private Dictionary<SFXType, AudioClip> _sfxDict;
    private Dictionary<BGMType, AudioClip> _bgmDict;
    private AudioSource _sfxPlayer;
    private AudioSource _bgmPlayer;

    private void Awake()
    {
        InitFields();
        SetAudioDict();
        SetSingleton();
    }

    private void OnEnable()
    {
        _sfxPlayer = Instantiate(_sfxPrefab, transform);
        _bgmPlayer = Instantiate(_bgmPrefab, transform);
    }

    private void InitFields()
    {
        _bgmList = new();
        _sfxList = new();
        _sfxDict = new ();
        _bgmDict = new ();
    }

    private void SetAudioDict()
    {
        foreach (var sfx in _sfxList)
        {
            _sfxDict.Add(sfx.Type, sfx.Clip);
        }
        foreach (var bgm in _bgmList)
        {
            _bgmDict.Add(bgm.Type, bgm.Clip);
        }
    }

    public void RequestBGM(BGMType bgmType)
    {
        _bgmPrefab.clip = _bgmDict[bgmType];
        _bgmPrefab.Play();
    }
}
