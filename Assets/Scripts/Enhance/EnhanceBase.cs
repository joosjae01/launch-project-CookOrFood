using UnityEngine;
using UnityEngine.UI;

public abstract class EnhanceBase : ScriptableObject
{
    [Header("강화 이름")]
    public string Name;

    [Header("강화 설명")]
    public string Desc;

    [Header("강화 이미지")]
    public Image EnhanceImage;

    [Header("강화 등급")]
    public EnhanceGrade Grade;
}
