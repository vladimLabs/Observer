using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AddButton : ButtonInitializer
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Dropdown _dropdown;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(() => AddValue());
    }

    private void AddValue()
    {
        string currentOption = _dropdown.options[_dropdown.value].text;

        if (currentOption != null)
        {
            if (int.TryParse(_inputField.text, out int result))
            {
                _resourcesDictionary.AddResource(currentOption, result);

                foreach (var currentEvent  in _events)
                {
                    if (currentEvent.ResourceName == currentOption)
                    {
                        currentEvent.Notify();
                        break;
                    }
                }
            }
        } 
    }
}
