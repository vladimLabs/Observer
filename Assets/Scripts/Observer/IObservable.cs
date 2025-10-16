using System;
public interface IObservable
{
    void RegisterObserver(Action listener);

    void RemoveObserver(Action listener);

    void Notify();
}
