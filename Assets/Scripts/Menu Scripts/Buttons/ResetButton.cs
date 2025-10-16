using System;
using UnityEngine.UI;
public class ResettButton : ButtonInitializer
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(() => ResetValues());
    }

    private void ResetValues()
    {
        foreach (string resource in Enum.GetNames(typeof(ResourcesPool)))
        {
            _resourcesDictionary.RemoveResource(resource, _resourcesDictionary.GetResourceValueByName(resource));
        }

        foreach (var currentEvent in _events)
        {
            currentEvent.Notify();
        }
    }
}
