using UnityEngine;
using UnityEngine.UI;

public class Petting : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Slider HappinessBar;

    private Ray _ray;
    private RaycastHit _hit;

    private void Start()
    {
        HappinessBar.value = 0f;
    }

    private void Update()
    {
        if (Input.touchCount <= 0 && Input.touches[0].phase != TouchPhase.Began) return;
        _ray = MainCamera.ScreenPointToRay(Input.touches[0].position);
        
        if (!Physics.Raycast(_ray, out _hit)) return;
        if (_hit.collider == null) return;
        
        HappinessBar.value += 0.05f;
    }
}
