using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayerMapping : MonoBehaviour
{
    // your texture e.g. from a public field via the inspector
    [SerializeField] RectTransform mapRectTransform;
    [SerializeField] RectTransform markerRectTransform;
    [SerializeField] private double mapWidth, mapHeight;
    private double mapLatitude, mapLongitude;
    public Texture2D texture;
    public Image userMarker;

    // define which pixel coordinates to use for this sprite also via the inspector
    public Rect pixelCoordinates;

    private void Update()
    {
        var newSprite = Sprite.Create(texture, pixelCoordinates, Vector2.one / 2f);

        GetComponent<Image>().sprite = newSprite;

        // Get the user's latitude and longitude
        double latitude = Input.location.lastData.latitude;
        double longitude = Input.location.lastData.longitude;

        print(latitude);
        print(longitude);

        // Convert the GPS coordinates to 2D coordinates on the map
        Vector2 position = GPSConverter.ConvertGPSToXY(latitude, longitude, mapLatitude, mapLongitude, mapWidth, mapHeight);

        // Update the position of the user marker image
        userMarker.rectTransform.anchoredPosition = position;
        position = pixelCoordinates.position;
    }

    // called everytime something is changed in the Inspector
    private void OnValidate()
    {
        if (!texture)
        {
            pixelCoordinates = new Rect();

            return;
        }

        // reset to valid rect values
        pixelCoordinates.x = Mathf.Clamp(pixelCoordinates.x, 0, texture.width);
        pixelCoordinates.y = Mathf.Clamp(pixelCoordinates.y, 0, texture.height);
        pixelCoordinates.width = Mathf.Clamp(pixelCoordinates.width, 0, pixelCoordinates.x + texture.width);
        pixelCoordinates.height = Mathf.Clamp(pixelCoordinates.height, 0, pixelCoordinates.y + texture.height);
    }
}
