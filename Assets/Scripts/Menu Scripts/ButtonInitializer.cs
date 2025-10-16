using UnityEngine;

public class ButtonInitializer : MonoBehaviour
{
    [SerializeField] protected GameObservableResource[] _events;

    protected ResourcesDictionary _resourcesDictionary;

    public void Initialize(ResourcesDictionary resourcesDictionary)
    {
        _resourcesDictionary = resourcesDictionary;
    }
}
