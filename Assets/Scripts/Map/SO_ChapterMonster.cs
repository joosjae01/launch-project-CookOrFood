using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_ChapterMonster", menuName = "Scriptable Objects/MonsterList", order = int.MaxValue)]
public class SO_ChapterMonster : ScriptableObject
{
    [Header("소환되는 몬스터 리스트")]
    [SerializeField] private List<GameObject> monsterList;
        
    public List<GameObject> MonsterList => monsterList;
}
