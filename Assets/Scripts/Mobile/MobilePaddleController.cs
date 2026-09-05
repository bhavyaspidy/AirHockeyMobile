using UnityEngine;
using UnityEngine.EventSystems;

public class MobilePaddleController :
    MonoBehaviour,
    IPointerDownHandler,
    IDragHandler,
    IPointerUpHandler
{
    [SerializeField] private PaddleController paddle;

    public void OnPointerDown(PointerEventData eventData)
    {
        paddle.SetTouchPosition(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        paddle.SetTouchPosition(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        paddle.StopTouch();
    }
}