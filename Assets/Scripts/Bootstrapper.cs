using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown[] _resourcesDropDowns;

    [SerializeField] private UISwitcher _switcher;
    [SerializeField] private Menu[] _menus;

    [SerializeField] private GameObservableResource[] _gameObservableResources;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private GameObject _grid;

    [SerializeField] private ButtonInitializer[] _buttons;

    private ResourcesDictionary _resourcesDictionary;

    private void Awake()
    {
        CreateResources();

        AddOptions();

        CreateItems();

        InitializeSwitcher();

        InitilizeButtons();
    }

    private void AddOptions()
    {
        var resources = Enum.GetValues(typeof(ResourcesPool));

        List<string> options = new List<string>();

        foreach (var resource in resources)
        {
            options.Add(resource.ToString());
        }

        foreach (TMP_Dropdown dropdown in _resourcesDropDowns)
        {
            dropdown.AddOptions(options);
        }
    }

    private void InitializeSwitcher()
    {
        foreach (var menu in _menus)
        {
            _switcher.AddState(menu.GetState(), menu);
        }
    }

    private void CreateResources()
    {
        _resourcesDictionary = new ResourcesDictionary();

        foreach (string resource in Enum.GetNames(typeof(ResourcesPool)))
        {
            _resourcesDictionary.AddResource(resource, 0);
        }
    }

    private void CreateItems()
    {
        foreach (string resource in Enum.GetNames(typeof(ResourcesPool)))
        {
            print(Enum.GetNames(typeof(ResourcesPool)).Length);
            GameObject newItem = Instantiate(_itemPrefab, _grid.transform);
            ItemUI itemUI = newItem.GetComponent<ItemUI>();

            itemUI.SetResource(resource);

            foreach (var observables  in _gameObservableResources)
            {
                print(observables.ResourceName);
                print(itemUI.GetResourceName());
                if (observables.ResourceName == itemUI.GetResourceName())
                {
                    itemUI.Initialize(observables, _resourcesDictionary);
                    print("Initialized");
                    break;
                }
            }
        }
    }

    private void InitilizeButtons()
    {
        foreach (var button in _buttons)
        {
            button.Initialize(_resourcesDictionary);
        }
    }
}
