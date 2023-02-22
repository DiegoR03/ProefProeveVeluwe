using UnityEngine;
using UnityEngine.UI;

public class Petting : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Slider HappinessBar;
    [SerializeField] private GameObject PetHand;
    [SerializeField] private int PetTime;

    private Ray _ray;
    private RaycastHit _hit;

    private void Start()
    {
        HappinessBar.value = 0f;
    }

    private void Update()
    {
        if (Input.touchCount <= 0)
        {
            PetHand.SetActive(false);
            return;
        }

        _ray = MainCamera.ScreenPointToRay(Input.touches[0].position);
        // It will hit the background so specify the hit
        if (!Physics.Raycast(_ray, out _hit) || _hit.collider == null) return;
        
        HappinessBar.value += Time.deltaTime/PetTime;
        PetHand.SetActive(true);
    }
}