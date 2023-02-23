using UnityEngine;

public class FeedAnimal : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount <= 0) return;

        Touch touch = Input.GetTouch(0);
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        transform.position = new Vector3(touchPosition.x,touchPosition.y, transform.position.z);

        if ()
        {
            
        }
    }
}