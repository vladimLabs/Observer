using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    MainMenu,
    AddMenu,
    RemoveMenu
}

public class UISwitcher : MonoBehaviour
{
    private Dictionary<UIState, UIController> _states = new Dictionary<UIState, UIController>();
    private UIController _active;

    public void AddState(UIState state, UIController controller)
    {
        _states.Add(state, controller);
    }

    public void ChangeState(UIState newState)
    {
        _active?.Exit();

        _active = _states[newState];

        _active.Enter();
    }
}
