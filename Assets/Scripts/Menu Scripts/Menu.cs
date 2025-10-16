using UnityEngine;

public class Menu : MonoBehaviour, UIController
{
    [SerializeField] private UIState _state;

    [SerializeField] protected UISwitcher _switcher;

    [SerializeField] protected GameObject _panel;

    public UIState GetState() => _state;

    public void OpenMenu()
    {
        _switcher.ChangeState(_state);
    }

    public virtual void Enter()
    {
        _panel.SetActive(true);
    }

    public virtual void Exit()
    {
        _panel.SetActive(false);
    }
}
