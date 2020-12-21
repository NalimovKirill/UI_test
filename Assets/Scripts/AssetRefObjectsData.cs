using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetRefObjectsData : MonoBehaviour
{
    [SerializeField] private AssetReference _sqrARef;
    [SerializeField] private List<AssetReference> _references = new List<AssetReference>();

    [SerializeField] private List<GameObject> _completedObjects = new List<GameObject>();

    private void Start()
    {
        _references.Add(_sqrARef);
        StartCoroutine(LoadAndWaitUnitlComplete());
    }
    private IEnumerator LoadAndWaitUnitlComplete()
    {
        yield return AssetRefLoader.CreateAssetsAddToList(_references,_completedObjects);
    }
}
