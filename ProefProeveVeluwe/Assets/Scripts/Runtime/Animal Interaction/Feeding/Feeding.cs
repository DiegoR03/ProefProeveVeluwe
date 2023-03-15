using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This allows the user to feed an game object with this script as long as the game object can eat it
/// </summary>
public class Feeding : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    // [SerializeField] private Slider HungerBar;
    // [SerializeField] private int FeedTime;
    [SerializeField] private GameObject[] FoodNum;
    [SerializeField] private int RequiredFoodNum;

    private Ray _ray;
    private RaycastHit _hit;
    // private Camera _camera;
    private string _test;
    // Here we assign the _camera to the main camera in the scene
    private void Awake()
    {
        // _camera = Camera.main;
        _test = "Start";
    }

    private void Update()
    {
        // Here we check how many hands are on the screen
        if (Input.touchCount <= 0) return;

        // Here we check if we are hitting a object with the Food tag
        _ray = MainCamera.ScreenPointToRay(Input.touches[0].position);
        if (!Physics.Raycast(_ray, out _hit) || _hit.collider == null || !_hit.collider.CompareTag("Food")) return;

        // Here we move the object with the food tag to the new position of the finger
        var touch = Input.GetTouch(0);
        var touchPosition = MainCamera.ScreenToWorldPoint(touch.position);
        var position = _hit.transform.position;
        position = new Vector3(position.x, touchPosition.y, position.z);
        _hit.transform.position = position;
        _test = touchPosition.y.ToString();
    }

    // When a food object collides with the mouth it will run this script
    private void OnTriggerStay(Collider other)
    {
        //Only the food that has been assigned to the animal will continue the script
        if (other.gameObject != FoodNum[RequiredFoodNum].gameObject) return;
        // HungerBar.value += Time.deltaTime/FeedTime;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), _test))
        {
            print("F");
        }
    }
}