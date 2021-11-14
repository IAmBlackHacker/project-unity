using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	public float x,y,z;
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3(x,y,z)*Time.deltaTime);
		//transform.Translate (Time.deltaTime,0,0);
	}
}
