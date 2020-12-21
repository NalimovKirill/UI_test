using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAvatar : MonoBehaviour
{
    [SerializeField] private string _url = "https://i.pinimg.com/originals/9e/1d/d6/9e1dd6458c89b03c506b384f537423d9.jpg";
    [SerializeField] private RawImage _avatarPicture;

    
    private void Start()
    {
        StartCoroutine(LoadFromLikeCoroutine());
    }

    private IEnumerator LoadFromLikeCoroutine()
    {
        WWW wwwLoader = new WWW(_url);   
        yield return wwwLoader;         

        _avatarPicture.texture = wwwLoader.texture; 
    }
}