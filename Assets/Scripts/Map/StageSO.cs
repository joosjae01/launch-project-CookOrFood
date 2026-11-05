using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Scriptable Objects/Stage", order = int.MaxValue)]
public class StageSO : ScriptableObject
{
    [Header("소환되는 몬스터 리스트")]
    [SerializeField] private GameObject[] monsterList;
    
    public GameObject[] MonsterList => monsterList;
}
