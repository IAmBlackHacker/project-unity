using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeA : MonoBehaviour {
	public void play()
	{
		Application.LoadLevel (1);
		Debug.Log("Access....");
	}
	public void playa()
	{
		Application.LoadLevel (1);
	}
	public void exit()
	{
		Application.Quit ();
	}
}
