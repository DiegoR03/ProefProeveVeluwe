using UnityEngine;
using UnityEngine.UI;

public class MoveFood : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Slider HungerBar;
    [SerializeField] private int FeedTime;
    [SerializeField] private int FoodNum;
    
    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        if (Input.touchCount <= 0) return;
        
        _ray = MainCamera.ScreenPointToRay(Input.touches[0].position);
        if (!Physics.Raycast(_ray, out _hit) || _hit.collider == null) return;

        Touch touch = Input.GetTouch(0);
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        transform.position = new Vector3(touchPosition.x,touchPosition.y, transform.position.z);
    }

    private void OnTriggerStay(Collider other)
    {
        HungerBar.value += Time.deltaTime/FeedTime;
    }
}