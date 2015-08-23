using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetController : MonoBehaviour {

	public bool Visible = true;
	public bool Invisible = false;

	public Sprite TargetSprite, Football, soccerBall, golfBall, Bow, Basketball, Volleyball, Nothing ; 

	public List<Sprite> sportIcons;

	// Use this for initialization
	void Start () 
	{
	

		sportIcons.Add (TargetSprite);
		sportIcons.Add (Football);
		sportIcons.Add (soccerBall);
		sportIcons.Add (golfBall);
		sportIcons.Add (Bow);
		sportIcons.Add (Basketball);
		sportIcons.Add (Volleyball);
		sportIcons.Add (Nothing);


		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);


	}
	
	// Update is called once per frame
	void Update () {
	
		if (this.gameObject.GetComponent<SpriteRenderer> ().color.a >= .99f) 
		{
			Debug.Log("Should be Visible");
			Visible = true;
			Invisible = false;
		} 
		else if (this.gameObject.GetComponent<SpriteRenderer> ().color.a <= .01f) 
		{	
			StartCoroutine("SpriteSwapCoroutine");
		}

		if (!Invisible) 
		{
			this.gameObject.GetComponent<SpriteRenderer> ().color -= new Color (0, 0, 0, (.5f * Time.deltaTime));
		}

		if (!Visible) 
		{
			this.gameObject.GetComponent<SpriteRenderer> ().color += new Color (0, 0, 0, (.5f * Time.deltaTime));
		}



	}

	IEnumerator SpriteSwapCoroutine()
	{
		SpriteSwap ();
		yield return new WaitForSeconds (1.0f);
		Visible = false;
		Invisible = true;

	}

	void SpriteSwap()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = sportIcons [Random.Range (0, sportIcons.Count)];
	}






}
