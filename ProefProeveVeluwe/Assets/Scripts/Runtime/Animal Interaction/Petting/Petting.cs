using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Cache = UnityEngine.Cache;

/// <summary>
/// This allows the user to pet an gameobject with the Pettable tag
/// </summary>
public class Petting : MonoBehaviour
{
    [SerializeField] private Slider HappinessBar;
    [SerializeField] private GameObject HandCursor;
    [SerializeField] private int PetTime = 5;
    
    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;

    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
        HappinessBar.value = 0f;
    }

    private void Update()
    {
        // Here we check how many hands are on the screen
        if (Input.touchCount <= 0)
        {
            HandCursor.SetActive(false);
            return;
        }

        //Here we check if we are hitting a object with the Pettable tag
        _ray = _mainCamera.ScreenPointToRay(Input.touches[0].position);
        if (!Physics.Raycast(_ray, out _hit) || _hit.collider == null || !_hit.collider.CompareTag("Pettable")) return;
        
        //Here we increase the happiness bar value by a specified amount of time
        HappinessBar.value += Time.deltaTime/PetTime;
        
        //Here we position a 2D hand to visualize the animal getting petted
        var hitPosition = _hit.point;
        HandCursor.transform.position = new Vector3(hitPosition.x, hitPosition.y, HandCursor.transform.position.z);
        
        HandCursor.SetActive(true);
    }
}