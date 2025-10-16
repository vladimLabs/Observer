using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameObservableResource", menuName = "Scriptable Objects/GameObservableResource")]
public class GameObservableResource : ScriptableObject, IObservable
{
    public string ResourceName;

    public event Action OnChanged;

    public void RegisterObserver(Action listener) => OnChanged += listener;

    public void RemoveObserver(Action listener) => OnChanged -= listener;

    public void Notify() => OnChanged?.Invoke();
}
