using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Screen : MonoBehaviour, IInitiazable<GameActivator>
{
    private CanvasGroup _canvasGroup;
    private ScreenButton _button;

    public virtual void Init(GameActivator gameActivator)
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _button = GetComponentInChildren<ScreenButton>();
        _button.Init(gameActivator);
        Close();
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
        _button.gameObject.SetActive(true);
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        Time.timeScale = 1;
        _button.gameObject.SetActive(false);
    }
}
