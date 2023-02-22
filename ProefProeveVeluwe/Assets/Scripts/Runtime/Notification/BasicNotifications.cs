using Unity.Notifications.Android;
using UnityEngine;

/// <summary>
/// BasicNotifications sends notifications to the user
/// </summary>
public class BasicNotifications : MonoBehaviour
{
    // Creates a channel to allow notifications to be send to the phone notification network
    private void Start()
    {
        var DistanceNotificationChannel = new AndroidNotificationChannel
        {
            Id = "Distance_Notification",
            Name = "Afstand Notficatie",
            Description = "Dit geeft je een notificatie waarneer je in de buurt bent van een spelletje",
            Importance = Importance.High
        };
        
        AndroidNotificationCenter.RegisterNotificationChannel(DistanceNotificationChannel);
    }

    // Makes a notification on call to send ot the phone notificaiton in the Distance Notification Channel
    public static void Notification(string title, string text)
    {
        var ClostToWaypointNotification = new AndroidNotification
        {
            Title = title,
            Text = text,
            SmallIcon = "icon_0",
            LargeIcon = "icon_1",
        };
    
        AndroidNotificationCenter.SendNotification(ClostToWaypointNotification, "Distance_Notification");
    }
}
