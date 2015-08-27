using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetController : MonoBehaviour {
	
	public static float Score;//Players score
	public static bool Winner;

	bool Visible = true; //Used to communicate that the object is completely visible
	bool Invisible = false; //Used to communicate that the object is completely invisible

	bool isSwapping = false;

	public Sprite targetSprite; //This is the Icon the player will be matching
	public Sprite Football, soccerBall, golfBall, Bow, Basketball, Volleyball, Nothing; //These are the icons that will be used interchangeable for matching purposes

	public List<Sprite> sportIcons;//List of sports icons
	bool emptyList = false; 
	bool showTarget = true; //Used to determine when the target should be shown

	void Awake()
	{
		//Make sure the game doesn't start playing while picking trials. This essentially pauses the game temporarily.
		Time.timeScale = 0;

		//Adds my icons to the list
		sportIcons.Add (Football);
		sportIcons.Add (soccerBall);
		sportIcons.Add (golfBall);
		sportIcons.Add (Bow);
		sportIcons.Add (Basketball);
		sportIcons.Add (Volleyball);
		sportIcons.Add (Nothing);

		//Sets the target icon to be equal to a random one of the elements in my list
		targetSprite = sportIcons [Random.Range (0, sportIcons.Count - 1)];
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = targetSprite;
		//Debug.Log (targetSprite.name);


	}
	// Use this for initialization
	void Start () 
	{
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		Score = 100.0f;
	}

	// Update is called once per frame
	void Update () 
	{
	
		if(InGameUI.trialCountSelected == true && InGameUI.Trials > 0 && emptyList == false)
		{

			if (this.gameObject.GetComponent<SpriteRenderer> ().color.a >= .99f) 
			{
				//Debug.Log("Should be Visible");
				Visible = true;
				Invisible = false;

			if(showTarget)
				{
					showTarget = false;
				}

			} 

			if (this.gameObject.GetComponent<SpriteRenderer> ().color.a <= .01f && isSwapping == false) 
			{	
				Score = 100.0f;
				isSwapping = true;

				if(sportIcons.Count == 0)
					emptyList = true;

				if(showTarget == true)
				{
					Visible = false;
					Invisible = true;
				}
				else
				StartCoroutine ("SpriteSwapCoroutine");
				
			} 
			else if (this.gameObject.GetComponent<SpriteRenderer> ().color.a > .1f)
			{

				Score -= (18*Time.deltaTime);
				Debug.Log((int)Score);

				if(isSwapping == true)
				{
					isSwapping = false;
				}

			}
		

			if (!Invisible) 
			{
				this.gameObject.GetComponent<SpriteRenderer> ().color -= new Color (0, 0, 0, (.5f * Time.deltaTime));
			}
			if (!Visible) 
			{
				this.gameObject.GetComponent<SpriteRenderer> ().color += new Color (0, 0, 0, (.5f * Time.deltaTime));
			}
		

		
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				if (TargetChecker () == true) 
				{
					Winner = true;
					InGameUI.Trials--;
					ResetTarget();
					emptyList = false;
					StartCoroutine ("SpriteSwapCoroutine");
				} 
				else 
				{
					//Winner = false;
					//InGameUI.Trials--;
					//ResetTarget();
					//emptyList = false;
					//StartCoroutine ("SpriteSwapCoroutine");
				}
			}
		
		

		} 
		else if(emptyList == true)//If the list is empty, the amount of trials left is deducted and the game is reset
		{
			InGameUI.Trials--;
			ResetTarget();
			emptyList = false;
			StartCoroutine ("SpriteSwapCoroutine");
		}
		else 
		{

			//Debug.Log ("You Lost Because you ran out of items!!");
			//This is where I will run in some canvas stuff and make the player see that 
			//they had lost and will need to select whether they would liek to try again

			//Also, they will be able to press space in order to continue their trials.
		}


	}

	//Used to allow for a pause between icon transitions
	IEnumerator SpriteSwapCoroutine()
	{

		yield return new WaitForSeconds (1.0f);

		SpriteSwap ();
		Visible = false;
		Invisible = true;

	}

	//Swaps the current sprite with another random element in the list of sprites that are remaining
	void SpriteSwap()
	{
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = sportIcons [Random.Range (0, sportIcons.Count)];
		sportIcons.Remove(this.gameObject.GetComponent<SpriteRenderer> ().sprite);
	}

	void ShowTarget(Sprite Target)
	{

	}

	//If the player still has trials left, the list will be reset, and a new target will be chosen
	void ResetTarget()
	{
		//Winner = false;

		sportIcons.Add (Football);
		sportIcons.Add (soccerBall);
		sportIcons.Add (golfBall);
		sportIcons.Add (Bow);
		sportIcons.Add (Basketball);
		sportIcons.Add (Volleyball);
		sportIcons.Add (Nothing);

		targetSprite = sportIcons [Random.Range (0, sportIcons.Count - 1)];
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = targetSprite;
		//Debug.Log (targetSprite.name);

	}

	//float ScoreAlgorithm()
	//{

	//}

	//If the player hits space, this function will compare names of the target's sprite and the current sprite assigned to the game object
	//and will return true or false accordingly
	bool TargetChecker()
	{
		if (targetSprite.name == this.gameObject.GetComponent<SpriteRenderer> ().sprite.name) 
		{
			return true;
		} 
		else
			return false;

	}


}













