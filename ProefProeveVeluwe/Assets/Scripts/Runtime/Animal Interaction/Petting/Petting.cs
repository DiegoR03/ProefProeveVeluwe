using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This allows the user to pet an gameobject with the Pettable tag
/// </summary>
public class Petting : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Slider HappinessBar;
    [SerializeField] private GameObject PetHand;
    [SerializeField] private int PetTime;
    
    private Ray _ray;
    private RaycastHit _hit;

    private void Awake()
    {
        HappinessBar.value = 0f;
    }

    private void Update()
    {
        // Here we check how many hands are on the screen
        if (Input.touchCount <= 0)
        {
            PetHand.SetActive(false);
            return;
        }

        //Here we check if we are hitting a object with the Pettable tag
        _ray = MainCamera.ScreenPointToRay(Input.touches[0].position);
        if (!Physics.Raycast(_ray, out _hit) || _hit.collider == null || !_hit.collider.CompareTag("Pettable")) return;
        
        //Here we increase the happiness bar value by a specified amount of time
        HappinessBar.value += Time.deltaTime/PetTime;
        
        //Here we position a 2D hand to visualize the animal getting petted
        var hitPosition = _hit.point;
        PetHand.transform.position = new Vector3(hitPosition.x, hitPosition.y, PetHand.transform.position.z);
        
        PetHand.SetActive(true);
    }
}