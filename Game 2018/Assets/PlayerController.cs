using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour 
{
	  /* sim [HideInInspector] use for public members to not shown in unity inspector*/
	private Rigidbody rd;
	public float speed;
	//[SerializeField]
	private int points=0;
	private float time=80;
	public Text score,timet,etext;
	public GameObject cam1;//,cam2;
	// public GameObject gameC;
	// public GameObject gameE;
	public GameObject speedup_single;
	public GameObject endpanel;
	//public GameObject [] speedup=new GameObject [15];
	// public GameObject [] box=new GameObject [9];
	bool flag=true;
	/*void Awake()  -called even if script is not active*/
    void Start()
	{
		rd = GetComponent<Rigidbody> ();
		score.text = ""+points;
		timet.text = ""+time;
		// InvokeRepeating ("active",10f,10f);
		make_speedup();
		InvokeRepeating("updatescore1",5f,5f);
		etext.text="YOUR FINAL SCORE IS : " + points;
	}
	void make_speedup(){
		GameObject new_object;
		// new_object = Object.Instatiate(speedup_single);
	}
	void FixedUpdate ()
	{
		float Horizontal = Input.GetAxis ("Horizontal");
		float Vertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (Horizontal,0.0f,Vertical);
		rd.AddForce (movement*speed);
		if(flag){
			timet.text = ""+time;
			score.text = ""+points;
			time = time - Time.deltaTime;
		}
		if (time <= 0 && flag) 
		{
			// gameC.SetActive(false);
			// gameE.SetActive(true);
			
			// cam1.SetActive(false);
			// cam2.SetActive(true);
			endgame();
		}
	}
	void updatescore1(){
		if(flag){
			points=points+5;
		}
	}
	void active()
	{
		// foreach (GameObject b in speedup)
		// {
		// 	b.SetActive(true);
		// }
	}
	void endgame(){
		flag=false;
		etext.text="YOUR FINAL SCORE IS : " + points;
		endpanel.SetActive(true);
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("powerspeed") && flag) 
		{
			speed=(1.5f)*speed;
			points=points+100;
			other.gameObject.SetActive(false);
			Destroy(other.gameObject,0.0f);
		}
		else if(other.gameObject.CompareTag("powertime") && flag){
			points=points+50;
			time=time+30;
			other.gameObject.SetActive(false);
			Destroy(other.gameObject,0.0f);
		}
		else if(other.gameObject.CompareTag("treasure") && flag){
			points = (int)time*10+2000;
			other.gameObject.SetActive(false);
			Destroy(other.gameObject,0.0f);
			endgame();
		}
	}
	public int getpoints()
	{
		return points;
	}
	// void OnTriggerEnter(Collider other)
	// {
	// 	if (other.gameObject.CompareTag("Box")) 
	// 	{
	// 		other.gameObject.SetActive(false);
	// 		points += 5;
	// 		score.text = "SCORE : " + points;
	// 	}
	// }
	/*GameObject.FindWithTag("tagName"); for finding object with tagname*/
	/*GameObject [] obj= GameObject.FindGameobjectsWithTag("tagname"); foreach (GameObject r in obj){Destroy(r.gameObject)} destroy all object with tag name*/
}
