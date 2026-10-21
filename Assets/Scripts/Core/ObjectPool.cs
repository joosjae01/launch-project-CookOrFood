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
        IPoolable temp;

        for (int i = 0; i < _poolSize; i++)
        {
            if (!Instantiate(_prefab.GameObject).TryGetComponent<IPoolable>(out temp)) return;
            temp.GameObject.SetActive(false);
            temp.Source = this;
            _pool.Push(temp);
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
