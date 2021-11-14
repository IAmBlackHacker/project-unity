using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MovePlayer : MonoBehaviour 
{
	  /* sim [HideInInspector] use for public members to not shown in unity inspector*/
	private Rigidbody rd;
	public float speed;
	//[SerializeField]
	private int points=0;
	private float time=80;
	public Text score,timet,etext;
	public GameObject cam1,cam2;
	public GameObject gameC;
	public GameObject gameE;
	public GameObject [] box=new GameObject [9];
	bool flag=true;
	/*void Awake()  -called even if script is not active*/
    void Start()
	{
		rd = GetComponent<Rigidbody> ();
		score.text = "SCORE : " + points;
		InvokeRepeating ("active",10f,10f);
	}
	void FixedUpdate ()
	{
		float Horizontal = Input.GetAxis ("Horizontal");
		float Vertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (Horizontal,0.0f,Vertical);
		rd.AddForce (movement*speed);
		timet.text = "REMAINING TIME : " + time;
		time = time - Time.deltaTime;
		if (time <= 0 && flag) 
		{
			gameC.SetActive(false);
			gameE.SetActive(true);
			etext.text="YOUR SCORE IS : " + points;
			cam1.SetActive(false);
			cam2.SetActive(true);
			flag=false;
		}
	}
	void active()
	{
		foreach (GameObject b in box)
		{
			b.SetActive(true);
		}
	}
	/*void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Box")) 
		{
			other.gameObject.SetActive(false);
			Destroy(other.gameObject,0.0f);
		}
	}*/
	public int getpoints()
	{
		return points;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Box")) 
		{
			other.gameObject.SetActive(false);
			points += 5;
			score.text = "SCORE : " + points;
		}
	}
	/*GameObject.FindWithTag("tagName"); for finding object with tagname*/
	/*GameObject [] obj= GameObject.FindGameobjectsWithTag("tagname"); foreach (GameObject r in obj){Destroy(r.gameObject)} destroy all object with tag name*/
}
