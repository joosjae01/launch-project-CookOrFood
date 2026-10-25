using System;
using UnityEngine;

[Serializable]
public class ObservableProperty<T>
{
    private Action<T> _onValueChanged;

    [SerializeField] private T _value;

    public T Value
    {
        get => _value;

        set
        {
            _value = value;
            Notify();
        }
    }

    public ObservableProperty(T initialValue)
    {
        _value = initialValue;
    }
    
    public void Notify()
    {
        _onValueChanged?.Invoke(_value);
    }

    public void AddListener(Action<T> onValueChanged)
    {
        _onValueChanged += onValueChanged;
    }

    public void RemoveListener(Action<T> onValueChanged)
    {
        _onValueChanged -= onValueChanged;
    }

    public void RemoveAllListeners()
    {
        _onValueChanged = null;
    }
}
