using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	private Vector3 offset;
	public GameObject Player;
	// Use this for initialization
	void Start () 
	{
		offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Player.transform.position + offset;
	}
}
