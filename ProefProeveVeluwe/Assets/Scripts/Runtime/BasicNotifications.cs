using Unity.Notifications.Android;
using UnityEngine;

public class BasicNotifications : MonoBehaviour
{
    private void Start()
    {
        var channel = new AndroidNotificationChannel
        {
            Id = "template",
            Name = "Test",
            Description = "Looks like it is working",
            Importance = Importance.Default
        };
        
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification = new AndroidNotification
        {
            Title = "Looks like it isn't working as expected",
            Text = "Looks like it really isn't working as expected",
            SmallIcon = "icon_0",
            LargeIcon = "icon_1",
            FireTime = System.DateTime.Now.AddSeconds(5)
        };

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
}
