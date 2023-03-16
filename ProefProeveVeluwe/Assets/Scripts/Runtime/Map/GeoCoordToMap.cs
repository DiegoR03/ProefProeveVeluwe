using UnityEngine;
using Math = System.Math;

public class GeoCoordToMap : MonoBehaviour
{
    [Header("Gizmo, editor only")]
    //world gizmo variables
    [SerializeField] private Vector3 WorldSize = new Vector3(1000,0,1000);
    private Vector3 _worldOrigin = new Vector3(0,0,0);
    
    [Space]
    //marker gizmo variables
    [SerializeField] private float MarkerSize = 1f;

    
    [Header("Gameplay")] 
    //Player object variables
    [SerializeField] private GPS GpsData;

    [SerializeField] private GeoCoord[] Coordinates;
    [SerializeField] private Vector2 PlayerLocation;
    
    [Space]
    //Visual object variables
    [SerializeField] private GameObject PlayerMarker;
    [SerializeField] private GameObject MarkerObject;

    private void Start()
    {
        PlaceMarkers();
    }
    
    private void PlaceMarkers()
    {
        for (int i = 0; i < Coordinates.Length; i++)
        {
            Vector3 v3point = Coordinates[i].ToVector3();
            Vector3 worlPos = _worldOrigin + Vector3.Scale(v3point,WorldSize*0.5f);
            Instantiate(MarkerObject, worlPos, Quaternion.identity);
        }
    }
    
    
#if UNITY_EDITOR
    void OnDrawGizmos ()
    {
        Vector3 origin = transform.position;

        // draw game world bounds:
        Gizmos.DrawWireCube( _worldOrigin , WorldSize );

        Gizmos.color = Color.yellow;
        var labelStyle = new GUIStyle(){ normal = new GUIStyleState(){ textColor = Color.yellow } };
        for( int i=Coordinates.Length-1 ; i!=-1 ; i-- )
        {
            var coord = Coordinates[i];

            // game world:
            {
                Vector3 v3point = coord.ToVector3();
                Vector3 worlPos = _worldOrigin + Vector3.Scale(v3point,WorldSize*0.5f);

                Gizmos.color = Color.green;
                Gizmos.DrawCube( worlPos , new Vector3(MarkerSize,MarkerSize,MarkerSize) );
                UnityEditor.Handles.Label( worlPos , coord.ToString() , labelStyle );
            }
        }
    }
    #endif

    //private void MoveOrigin ( GeoCoord coord ) => _worldOrigin = -Vector3.Scale( coord.ToVector3() , WorldSize*0.5f );
    //[SerializeField] GeoCoord[] _coordinates = new GeoCoord[] {new GeoCoord{ label="" , latitude=0 , longitude=0 } ,};
}


[System.Serializable]
public struct GeoCoord
{
    public string label;
    public double latitude;
    public double longitude;
    public override string ToString () => this.label;
    public Vector2 ToVector2 () => new Vector2( (float) Math.Sin( this.longitude * Deg2Rad * 0.5 ) , (float) Math.Sin( this.latitude * Deg2Rad ) );
    public Vector3 ToVector3 ( float elevation = 0 ) => new Vector3( (float) Math.Sin( this.longitude * Deg2Rad * 0.5 ) , elevation , (float) Math.Sin( this.latitude * Deg2Rad ) );
    public Vector3 ToVector3UnitSphere () => Quaternion.Euler(0,-(float)this.longitude,0) * ( Quaternion.Euler(-(float)this.latitude,0,0) * Vector3.forward );
    const double Deg2Rad = Math.PI / 180.0;
}

