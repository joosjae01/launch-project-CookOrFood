using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Stack<IPoolable> _pool = new();
    private int _currentCount;
    private int _size;
    public void Init(int size, GameObject prefab, Transform parent)
    {
        _size = size;
        IPoolable temp;

        for (int i = 0; i < _size; i++)
        {
            if (!Instantiate(prefab, parent).TryGetComponent<IPoolable>(out temp)) return;
            temp.GameObject.SetActive(false);
            temp.Source = this;
            _pool.Push(temp);
            _currentCount++;
        }
    }

    public IPoolable Take()
    {
        if (_currentCount == 0) return null;

        IPoolable temp = _pool.Pop();
        temp.GameObject.SetActive(true);
        _currentCount--;

        return temp;
    }

    public void Push(IPoolable pool) {
        if (_currentCount == _size) return;

        pool.GameObject.SetActive(false);
        _pool.Push(pool);
        _currentCount++;
    }
}
