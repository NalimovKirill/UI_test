using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapterConnected : MonoBehaviour
{
    [SerializeField] private RectTransform _prefab;
    [SerializeField] private RectTransform _content;
    private int modelsCount = 100;

    private void Awake()
    {
        UpdateItems();
    }
    public void UpdateItems()
    {
        string url = "http://127.0.0.1:6006?count=" + modelsCount;
        WWW www = new WWW(url);
        StartCoroutine(GetItems(www, results => OnReceivedModels(results)));
    }

    private void OnReceivedModels(TestItemModel[] models)
    {
        foreach (Transform child in _content)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(_prefab.gameObject) as GameObject;
            instance.transform.SetParent(_content, false);
            InitializeItemView(instance, model);
        }
    }
        
    private void InitializeItemView(GameObject viewGameObject, TestItemModel model)
    {
        TestItemView view = new TestItemView(viewGameObject.transform);
        view.labelText.text = model.label;
        view.countOfProductText.text = "x" + model.countOfProduct;
        view.priceText.text = model.price;
       
               
    }

    private IEnumerator GetItems(WWW www, System.Action<TestItemModel[]> callback)
    {
        yield return www;

        if (www.error == null)
        {
            TestItemModel[] mList = JsonHelper.GetJsonArray<TestItemModel>(www.text);
            Debug.Log("WWW Success: " + www.text);
            callback(mList);
        }
        else
        {
            TestItemModel[] errList = new TestItemModel[1];
            errList[0] = new TestItemModel
            {
                label = www.error,
            };
            Debug.Log("WWW Error: " + www.error);
            callback(errList);
        }
    }

    public class TestItemView
    {
        public TMP_Text countOfProductText;
        public TMP_Text labelText;
        public TMP_Text priceText;

        public TestItemView(Transform rootView)
        {
            labelText = rootView.Find("LabelText").GetComponent<TMP_Text>();
            countOfProductText = rootView.Find("CountOfProductText").GetComponent<TMP_Text>();
            priceText = rootView.Find("PriceText").GetComponent<TMP_Text>();
           
        }
    }

    [System.Serializable]
    public class TestItemModel
    {
        public string countOfProduct;
        public string label;
        public string price;
       
       
    }

    public class JsonHelper
    {
        public static T[] GetJsonArray<T>(string json)
        {
            string newJson = "{ \"array\": " + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
            return wrapper.array;
        }

        public static string ArrayToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>
            {
                array = array
            };
            return JsonUtility.ToJson(wrapper);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }
    }
}