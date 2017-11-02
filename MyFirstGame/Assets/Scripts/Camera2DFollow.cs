using UnityEngine;

public class Camera2DFollow : MonoBehaviour {

    public Transform target;
    private int offsetZ;
	// Use this for initialization
	void Start () {
        offsetZ = -10;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position + Vector3.forward * offsetZ;
	}
}
