using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RouteSelector : MonoBehaviour
{
    [SerializeField] private GPSRoutes[] routes;
    public List<GameObject> routeImage = new List<GameObject>();
    //private RouteInformation routeInformation;
    private float routeIndex;

    public GPSRoutes[] GetAllRoutes()
    {
        return routes;
    }

    public void Selected(int imageIndex)
    {
        for (int i = 0; i < routeImage.Count; i++)
        {
            routeImage[i].SetActive(true);
        }
    }
}
