using UnityEngine;
using Math = System.Math;

public class GeoCoordToMap : MonoBehaviour
{
    [SerializeField] Vector3 _worldSize = new Vector3(100, 0, 100);
    [SerializeField] Vector3 _worldOrigin = new Vector3(10, 0, 10);

    [SerializeField] bool _originFromPlayerPosition = false;
    [SerializeField] GeoCoord _playerPosition = new GeoCoord { label = "Player 0", latitude = 48.195932, longitude = 16.339999 };

    [SerializeField] private GPSWayPointsData[] WayPoints;

#if UNITY_EDITOR
    [SerializeField] float _worldPointSize = 1f;
    [SerializeField][Min(0.01f)] float _gizmoScale = 10f;

    void OnValidate()
    {
        if (_originFromPlayerPosition)
        {
            UnityEditor.Undo.RecordObject(this, "Origin From Player Position");
            MoveOrigin(_playerPosition);
        }
    }

    void OnDrawGizmos()
    {
        Vector3 origin = transform.position;

        // draw game world bounds:
        Gizmos.DrawWireCube(_worldOrigin, _worldSize);

        Gizmos.color = Color.yellow;
        var labelStyle = new GUIStyle() { normal = new GUIStyleState() { textColor = Color.yellow } };
        for (int i = _coordinates.Length - 1; i != -1; i--)
        {
            var coord = _coordinates[i];
            // game world:
            {
                Vector3 v3point = coord.ToVector3();
                Vector3 worlPos = _worldOrigin + Vector3.Scale(v3point, _worldSize * 0.5f);

                Gizmos.color = Color.green;
                Gizmos.DrawCube(worlPos, new Vector3(_worldPointSize, _worldPointSize, _worldPointSize));
                UnityEditor.Handles.Label(worlPos, coord.ToString(), labelStyle);
            }
        }
    }

#endif
    void MoveOrigin(GeoCoord coord) => _worldOrigin = -Vector3.Scale(coord.ToVector3(), _worldSize * 1.5f);

    [SerializeField] private GeoCoord[] _coordinates = new GeoCoord[]
    {
         new GeoCoord {},
    };


    [System.Serializable]
    public struct GeoCoord
    {
        public string label;
        public double latitude;
        public double longitude;
        public override string ToString() => this.label;
        public Vector2 ToVector2() => new Vector2((float)Math.Sin(this.longitude * Deg2Rad * 0.5), (float)Math.Sin(this.latitude * Deg2Rad));
        public Vector3 ToVector3(float elevation = 0) => new Vector3((float)Math.Sin(this.longitude * Deg2Rad * 0.5), elevation, (float)Math.Sin(this.latitude * Deg2Rad));
        public Vector3 ToVector3UnitSphere() => Quaternion.Euler(0, -(float)this.longitude, 0) * (Quaternion.Euler(-(float)this.latitude, 0, 0) * Vector3.forward);
        const double Deg2Rad = Math.PI / 180.0;
    }
}
