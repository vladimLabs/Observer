using System.Collections.Generic;
public class ResourcesDictionary
{
    private Dictionary<string, int> _resources = new Dictionary<string, int>();

    public int GetResourceValueByName(string name)
    {
        if (_resources.ContainsKey(name))
        {
            return _resources[name];
        }

        return 0;
    }

    public void AddResource(string name, int value)
    {
        if (_resources.ContainsKey(name))
        {
            _resources[name] += value;
        }
        else
        {
            _resources.Add(name, value);
        }
    }

    public void RemoveResource(string name, int value)
    {
        if (_resources[name] - value < 0)
        {
            return;
        }
        
        _resources[name] -= value;
    }

    public int GetCount() => _resources.Count;
}
