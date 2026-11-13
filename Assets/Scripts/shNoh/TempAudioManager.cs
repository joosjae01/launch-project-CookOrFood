using System.Collections.Generic;
using UnityEngine;

public class TempAudioManager : SingletonBehaviour<TempAudioManager>
{
    private Dictionary<SFXType, AudioClip> _sfxDict;
}
