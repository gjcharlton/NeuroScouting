using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetController : MonoBehaviour {
	
	public static float Score = 100;//Players score
	public static bool Winner = false; //Determines if the player has won a round by making a match. This is also used in InGameUI.cs
	public static bool Loser = false; //Determines if the player has lost a round. This is also used in InGameUI.cs
	public static bool endTrial = false;

	public List<Sprite> sportIcons;//List of sports icons

	public Sprite targetSprite; //This is the Icon the player will be matching
	public Sprite Nothing; //This is what the target sprite will swap with if it is determined to be invisible this round
	public Sprite Football, soccerBall, golfBall, Bow, Basketball, Volleyball; //These are the icons that will be used interchangeably for matching purposes

	public bool Visible = true; //Used to communicate that the object is completely visible
	public bool Invisible = false; //Used to communicate that the object is completely invisible
	public bool hideTarget = false; //Determines whether this trial will hide the target
	public bool isSwapping = false; //Determines whether or not the object has hit the point which it is swapping out sprites
	public bool emptyList = false; //Determines if the list of sprites has become empty
	public bool showTarget = true; //Used to make sure that a coroutine isn't called to swap the target sprite immediately since the object starts with an alpha of 0
	public bool stopRoutine = false; //Used to stop coroutine from being called more than it should
	public bool lastIcon = false;	

	public int swapCounter = 0; //Keeps track of how many times a swpa has been made in a trial

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

		//Alogrithm to randomly determine whether or not the target should be invisible this round.
		if(Random.Range(0,6).Equals(0))
		{
			hideTarget = true;
			sportIcons.Remove (this.gameObject.GetComponent<SpriteRenderer> ().sprite);
		}
		else 
		{
			hideTarget = false;
			sportIcons.Remove(Nothing);
		}
	

	}

	// Use this for initialization
	void Start () 
	{
		//Starts the Target off with an alpha of 0 and lets the game know that it is supposed to be invisible, with an alpha of zero.
		showTarget = true;
		Visible = false;
		Invisible = true;
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);

		Score = 100.0f;

	}

	// Update is called once per frame
	void Update () 
	{
	

		//Ensures that the player has selected a number of trials, tha they still have trials and that the list of icons isn't empty
		if(InGameUI.trialCountSelected == true && InGameUI.Trials > 0 && emptyList == false)
		{
		

			//Used for showing UI showing the player that the target is currently up
			if(swapCounter == 0)
			{

				InGameUI.isTargetShowing = true;

			}
			else
			{

				InGameUI.isTargetShowing = false;

			}



			if (this.gameObject.GetComponent<SpriteRenderer> ().color.a <= .1f && isSwapping == false) 
			{		
				//this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
				isSwapping = true;
			
				//if this is the last object and it gets to a low alpha, this is what will help transition us to a loss screen.
				if(sportIcons.Count == 0)
				{
					Invoke("EmptyList", 2.5f);

				}

				//used to ensure that the current sprite isn't the target and that the routine only gets run once
				if(showTarget == false && stopRoutine == false)// !stopRoutine)
				{

					stopRoutine = true;
					StartCoroutine ("SpriteSwapCoroutine");

				}
			
			} 
			else if (this.gameObject.GetComponent<SpriteRenderer> ().color.a > .1f); //This entails that it is becoming visible again
			{
				//Subtract from the score because once the player can see it, and do not press space, they lose some of their score
				Score -= (10*Time.deltaTime);

				//Once the pbject hits its "max" visibility
				if (this.gameObject.GetComponent<SpriteRenderer> ().color.a >= .99f) 
				{

					//tell the game that it is in fact 100% visible
					Visible = true;
					Invisible = false;

					//used the first time an icon comes to full alpha. Will only get used on the target and this ensures that the coroutine will run now
					if(showTarget == true)
					{

						showTarget = false;

					}

					stopRoutine = false;
					
				} 
				//showTarget = false;
			
				//if the alpha is increasing, then the swapping is over
				if(isSwapping == true)
				{

					isSwapping = false;

				}

			}

			// if the sprite is registered as visible, start to make it invisible. Also ensures that it cannot go below a value of 0
			if (!Invisible) 
			{

				if(this.gameObject.GetComponent<SpriteRenderer> ().color.a >= 0)
				{

					this.gameObject.GetComponent<SpriteRenderer> ().color -= new Color (0, 0, 0, (1 * Time.deltaTime));

				}

			}
			// if the sprite is registered as invisible, start to make it visible. 
			if (!Visible) 
			{

				this.gameObject.GetComponent<SpriteRenderer> ().color += new Color (0, 0, 0, (1 * Time.deltaTime));

			}

			//once the player hits space to make a match
			if (Input.GetKeyDown (KeyCode.Space)) 
			{

				//check if the target matches the current sprite, if so, take away from how many trials are left, reset the list and other variable, and show the winner popup
				if(hideTarget == true && this.gameObject.GetComponent<SpriteRenderer>().sprite == Nothing )
				{
					CancelInvoke();
					InGameUI.Trials--;
					ResetTarget();
					Winner = true;

				}
				//This is used in a case that the target sprite doesn't get shown during the trial and the player manages to make the match by realizing this
				if (TargetChecker () == true && Winner == false) 
				{

					CancelInvoke();
					InGameUI.Trials--;
					ResetTarget();
					Winner = true;

				} 
				else if(TargetChecker () == false && Loser == false && swapCounter > 0) //If the player messess up, the loser window pops up. A trial is also subtracted
				{

					CancelInvoke();
					InGameUI.Trials--;
					ResetTarget();
					Loser = true;

				}

			}

		} 
		else if(emptyList == true && swapCounter == 6)//If the list is empty, the amount of trials left is deducted and the game is reset
		{

			InGameUI.Trials--;
			ResetTarget();
			endTrial = true;

		}
	}

	//Used to allow for a pause between icon transitions
	IEnumerator SpriteSwapCoroutine()
	{

		yield return new WaitForSeconds (1.0f);

		SpriteSwap();

		Visible = false;
		Invisible = true;


		swapCounter++;
		Score = 100;
	
	}

	//Swaps the current sprite with another random element in the list of sprites that are remaining
	void SpriteSwap()
	{
		//if(hideTarget == false)

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = sportIcons [Random.Range (0, sportIcons.Count)];
		sportIcons.Remove(this.gameObject.GetComponent<SpriteRenderer> ().sprite);
	}

	//If the player still has trials left, the list will be reset, and a new target will be chosen
	void ResetTarget()
	{

		Visible = false;
		Invisible = true;

		swapCounter = 0;

		sportIcons.Clear ();

		showTarget = true;
		 
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);

		sportIcons.Add (Football);
		sportIcons.Add (soccerBall);
		sportIcons.Add (golfBall);
		sportIcons.Add (Bow);
		sportIcons.Add (Basketball);
		sportIcons.Add (Volleyball);
		sportIcons.Add (Nothing);

		emptyList = false; 

		targetSprite = sportIcons [Random.Range (0, sportIcons.Count - 1)];
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = targetSprite;

		if(Random.Range(0,4).Equals(1))
		{
			hideTarget = true;
			sportIcons.Remove (this.gameObject.GetComponent<SpriteRenderer> ().sprite);
		}
		else 
		{
			hideTarget = false;
			sportIcons.Remove(Nothing);
		}

	}

	//If the player hits space, this function will compare names of the target's sprite and the current sprite assigned to the game object
	//and will return true or false accordingly
	bool TargetChecker()
	{
		if (targetSprite.name == this.gameObject.GetComponent<SpriteRenderer> ().sprite.name && swapCounter > 0) 
		{
			return true;
		} 
		else
			return false;

	}

	void EmptyList()
	{
		emptyList = true;
	}


}













