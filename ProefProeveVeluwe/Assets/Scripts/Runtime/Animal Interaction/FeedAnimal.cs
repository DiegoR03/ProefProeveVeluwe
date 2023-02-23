using UnityEngine;
using UnityEngine.EventSystems;

public class FeedAnimal : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
}