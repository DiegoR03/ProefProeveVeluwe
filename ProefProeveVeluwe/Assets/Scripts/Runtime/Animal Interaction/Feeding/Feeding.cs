using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This allows the user to feed an game object with this script as long as the game object can eat it
/// </summary>
public class Feeding : MonoBehaviour
{
    [SerializeField] private Slider HungerBar;
    [SerializeField] private int FeedTime;
    [SerializeField] private GameObject[] FoodNum;
    [SerializeField] private int RequiredFoodNum;

    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        // Here we check how many hands are on the screen
        if (Input.touchCount <= 0) return;

        // Here we check if we are hitting a object with the Food tag
        _ray = _mainCamera.ScreenPointToRay(Input.touches[0].position);
        if (!Physics.Raycast(_ray, out _hit) || _hit.collider == null || !_hit.collider.CompareTag("Food")) return;

        // Here we move the object with the food tag to the new position of the finger
        var touch = Input.GetTouch(0);
        var touchPosition = _mainCamera.ScreenToWorldPoint(touch.position);
        var hitPosition = _hit.point;
        if (_hit.transform.position.x > (float)0.3249049)
        {
            _hit.transform.position = new Vector3((float)0.3249049, touchPosition.y, hitPosition.z);
            HungerBar.value += 1;
            return;
        }
        _hit.transform.position = new Vector3(hitPosition.x, touchPosition.y, hitPosition.z);
    }

    // When a food object collides with the mouth it will run this script
    private void OnTriggerStay(Collider other)
    {
        //Only the food that has been assigned to the animal will continue the script
        if (other.gameObject != FoodNum[RequiredFoodNum].gameObject) return;
        HungerBar.value += Time.deltaTime/FeedTime;
    }

    private void OnGUI()
    {
        GUI.Button(new Rect(10, 10, 150*2, 100), (transform.position.x - FoodNum[0].transform.position.x) + "," + (transform.position.y - FoodNum[0].transform.position.y) + "," + (transform.position.z - FoodNum[0].transform.position.z));
    }
}