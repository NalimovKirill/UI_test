using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Scrollbar _scrollBar;

    [SerializeField] private Button _scrollToRight;
    [SerializeField] private Button _scrollToLeft;
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;

    }

    public void Exit()
    {
        Application.Quit(0);
    }

    public void OnValueChanged(int value, int maxValue)
    {
        _scrollBar.value = (float)value / maxValue;
        
    }
    private void OnScrollToRightButtonClick()
    {
        if (_scrollBar.value < 1)
        {
            _scrollBar.value += .2f;
        }
        
    }
    private void OnScrollToLeftButtonClick()
    {
        if (_scrollBar.value > 0)
        {
            _scrollBar.value -= .2f;
        }
        
    }
    private void OnEnable()
    {
        _scrollToRight.onClick.AddListener(OnScrollToRightButtonClick);
        _scrollToLeft.onClick.AddListener(OnScrollToLeftButtonClick);
    }

    private void OnDisable()
    {
        _scrollToRight.onClick.RemoveListener(OnScrollToRightButtonClick);
        _scrollToLeft.onClick.RemoveListener(OnScrollToLeftButtonClick);
    }
}