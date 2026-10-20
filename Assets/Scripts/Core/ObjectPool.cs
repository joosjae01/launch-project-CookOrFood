using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private float _poolSize;
    [SerializeField] private IPoolable _prefab;
    private Stack<IPoolable> _pool;

    private void Start() => Init();

    private void Init()
    {
        for(int i = 0; i < _poolSize; i++)
        {
            GameObject temp = Instantiate(_prefab.GameObject);
            temp.SetActive(false);
            _pool.Push(temp.GetComponent<IPoolable>());
        }
    }

    public IPoolable Take()
    {
        IPoolable temp = _pool.Pop();
        temp.GameObject.SetActive(true);
        return temp;
    }

    public void Push(IPoolable pool)
    {
        pool.GameObject.SetActive(false);
        _pool.Push(pool);
    }
}
