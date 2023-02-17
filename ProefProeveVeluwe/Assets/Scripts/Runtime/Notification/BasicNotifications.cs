using Unity.Notifications.Android;
using UnityEngine;

public class BasicNotifications : MonoBehaviour
{
    private string DistanceNotication = "Distance_Notification";
    private void Start()
    {
        var DistanceNotificationChannel = new AndroidNotificationChannel
        {
            Id = DistanceNotication,
            Name = "Afstand Notficatie",
            Description = "Dit geeft je een notificatie waarneer je in de buurt bent van een spelletje",
            Importance = Importance.High
        };
        
        AndroidNotificationCenter.RegisterNotificationChannel(DistanceNotificationChannel);

        var ClostToWaypointNotification = new AndroidNotification
        {
            Title = "Veluwe Picknic",
            Text = "Je bent nu dichtbij een minigame",
            SmallIcon = "icon_0",
            LargeIcon = "icon_1",
        };

        AndroidNotificationCenter.SendNotification(ClostToWaypointNotification, DistanceNotication);
    }
}
