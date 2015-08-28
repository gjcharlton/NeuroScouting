using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameUI : MonoBehaviour {

	public static int Trials; //Amount of trials set by player in UI menu
	public static bool trialCountSelected; // Checks if the player has finished picking the amount of trials
	public static bool isTargetShowing;
	public bool scoreGrabbed = false;

	public GameObject trialInputCanvas, confirmationCanvas, winnerCanvas, targetIndicatorCanvas, endGameCanvas;

	//All buttons that coincide with trial selection amount
	public Button One, Two, Three, Four, Five, Six, Seven, Eight, Nine;

	public float totalScore = 0.0f;
	public int trialsPlayed = 0;

    public Text confirmationText; // Text for the confirmation once the player has chosen the amount of trials
	public Text winnerText;
	public Text endGameText;

	string tempString;

	public bool updateResults = false;


	void Update()
	{

		if (TargetController.Winner == true) 
		{
			if(scoreGrabbed == false)
			{
				winnerCanvas.SetActive(true);
				winnerText.text = "You made a correct match!\n Your score for that match is: " + Mathf.Ceil(TargetController.Score) + "\n Press return/enter to continue!";
				totalScore += Mathf.Ceil(TargetController.Score);
				scoreGrabbed = true;
				TargetController.Score = 100;
			}

		}

		if (isTargetShowing && trialCountSelected == true) 
		{
			targetIndicatorCanvas.SetActive(true);
		}
		else
		{
			targetIndicatorCanvas.SetActive(false);
		}


		//If the player has picked their amont of trials and then proceeds to press space, they will begin gameplay
		if (confirmationCanvas.activeSelf == true && Input.GetKeyDown (KeyCode.Return)) 
		{
			confirmationCanvas.SetActive(false);
			trialCountSelected = true;
			Time.timeScale = 1;
		}
		if (winnerCanvas.activeSelf == true) 
		{
			Time.timeScale = 0; //Stop actions from occuring

			if(Input.GetKeyDown (KeyCode.Return)) //If the player is prepared for the next round
			{
				TargetController.Winner = false;
				winnerCanvas.SetActive(false);
				scoreGrabbed = false;
				trialsPlayed++;

				if(Trials == 0)
				{
					updateResults = true;
					endGameCanvas.SetActive(true);

				}
				else
				{
					Time.timeScale = 1;
				}

			}

		}	

		if(endGameCanvas.activeSelf == true) // If the player has no more trials after hitting return, they get sent back to the trials menu
		{
			if(updateResults == true)
			{
				tempString = endGameText.text;
				endGameText.text = endGameText.text + (totalScore/trialsPlayed);
				updateResults = false;
			}	

			if(Input.GetKeyDown (KeyCode.Space)) //If the player is prepared for the next round
			{
				trialsPlayed = 0;
				totalScore = 0;
				endGameCanvas.SetActive(false);
				endGameText.text = tempString;
				trialCountSelected = false;
				trialInputCanvas.SetActive(true);
			}

		}
	

	

	}

	//All of these functions are UI functions that will change the text of the confirmation window depending on which you press.
	//Each will change the int "Trials" appropriately
	//Each will also turn off the trial input canvas once a number icon has been pressed, thus turning on the confirmation panel
	public void OnePressed()
	{
		Trials = 1;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the return to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void TwoPressed()
	{
		Trials = 2;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the return to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void ThreePressed()
	{
		Trials = 3;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the return to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void FourPressed()
	{
		Trials = 4;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the return to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void FivePressed()
	{
		Trials = 5;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the return to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void SixPressed()
	{
		Trials = 6;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the return to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void SevenPressed()
	{
		Trials = 7;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the return to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void EightPressed()
	{
		Trials = 8;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the return to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void NinePressed()
	{
		Trials = 9;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the return to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}

	
}
