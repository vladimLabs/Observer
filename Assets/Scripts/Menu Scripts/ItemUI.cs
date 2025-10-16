using TMPro;
using UnityEngine;

public class ItemUI : MonoBehaviour, IGameEventListener
{
    [SerializeField] private TextMeshProUGUI _value;
    [SerializeField] private TextMeshProUGUI _name;

    private string _observableResourceName;
    private GameObservableResource _resourceEventSystem;
    private ResourcesDictionary _resourcesDictionary;

    public void SetResource(string resource)
    {
        _observableResourceName = resource;

        _name.text = resource;
    }

    public void Initialize(GameObservableResource eventSystem, ResourcesDictionary resourcesDictionary)
    {
        _resourceEventSystem = eventSystem;

        _resourcesDictionary = resourcesDictionary;

        eventSystem.RegisterObserver(OnObservableChanged);
        print($"Initialize - _resourceEventSystem = {_resourceEventSystem}, _resourcesDictionary = {_resourcesDictionary}");
    }

    public string GetResourceName() => _observableResourceName;

    public void OnObservableChanged()
    {
        print("OnObservableChanged");
        _value.text = _resourcesDictionary.GetResourceValueByName(_observableResourceName).ToString();
    }
}
