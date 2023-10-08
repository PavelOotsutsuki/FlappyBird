using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenButton : MonoBehaviour, IPointerClickHandler, IInitiazable<GameActivator>
{
    private GameActivator _gameActivator;

    public void Init(GameActivator gameActivator)
    {
        _gameActivator = gameActivator;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _gameActivator.ResetGame();
    }
}
