using System;
using Unity.Mathematics;
using UnityEngine;
using Math = System.Math;

public class GeoCoordToMap : MonoBehaviour
{
    [SerializeField] private Vector3 _worldSize = new Vector3(1000, 0, 1000);
    [SerializeField] private Vector3 _worldOrigin = new Vector3(10, 0, 10);

    [SerializeField] private bool _originFromPlayerPosition = false;
    [SerializeField] private GeoCoord _playerPosition;
    private GPS _gps;
    
    [SerializeField] private GPSWayPointsData[] wayPoints;
    [SerializeField] private Vector2[] _coordinatesWaypoints;
    
    //debug
    private Vector3 worlPos;

#if UNITY_EDITOR
    [SerializeField] private GameObject CoordinateMarker;
    [SerializeField] private float CoordinateMarkerSize = 0.003f;
    [SerializeField][Min(0.01f)] private float _gizmoScale = 10f;

    private void Start()
    {
        _coordinatesWaypoints = new Vector2[3];
        SetCoordinates();
        SetCoordinateMarkers();
    }

    void OnValidate()
    {
        if (_originFromPlayerPosition)
        {
            UnityEditor.Undo.RecordObject(this, "Origin From Player Position");
            _playerPosition = new GeoCoord { label = "Player", latitude = _gps.CurrentLatitude, longitude = _gps.CurrentLongitude };
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
                worlPos = _worldOrigin + Vector3.Scale(v3point, _worldSize * 0.5f);

                //add cube
                Gizmos.color = Color.green;
                Gizmos.DrawCube(worlPos, new Vector3(CoordinateMarkerSize, CoordinateMarkerSize, CoordinateMarkerSize));
                UnityEditor.Handles.Label(worlPos, coord.ToString(), labelStyle);
            }
        }
    }

    private void SetCoordinateMarkers()
    {
        for (int i = _coordinatesWaypoints.Length - 1; i != -1; i--)
        {
            Vector3 v3Coords = _coordinatesWaypoints[i];
            // game world:
            {
                worlPos = _worldOrigin + Vector3.Scale(v3Coords, _worldSize * 0.5f);

                Instantiate(CoordinateMarker, worlPos, Quaternion.identity);
            }
        }
    }

    void SetCoordinates()
    {
        for (int i = 0; i < wayPoints.Length -1; i++)
        { 
            const double Deg2Rad = Math.PI / 180.0;
            _coordinatesWaypoints[i] =  new Vector2 ((float)Math.Sin(wayPoints[i].LongitudeValue * Deg2Rad * 0.5), (float)Math.Sin(wayPoints[i].LatitudeValue * Deg2Rad));
        }
    }
    
#endif
    void MoveOrigin(GeoCoord coord) => _worldOrigin = -Vector3.Scale(coord.ToVector3(), _worldSize * 1.5f);
    
    [SerializeField] private GeoCoord[] _coordinates = new GeoCoord[]
    {
         new GeoCoord {label = "MediaCollege", latitude = 52.390590795145535, longitude = 4.856635387647801},
         new GeoCoord {label = "IsolatorWeg", latitude = 52.39513410665035, longitude = 4.850442772070887},
         new GeoCoord {label = "Sloterdijk", latitude = 52.38907973708026, longitude = 4.837972750375134},
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
