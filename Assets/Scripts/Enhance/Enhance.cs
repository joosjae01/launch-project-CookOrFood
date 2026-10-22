using UnityEngine;

public abstract class Enhance : ScriptableObject
{
    [Header("강화 이름")]
    public string Name;

    [Header("강화 등급")]
    public EnhanceGrade Grade;
}
