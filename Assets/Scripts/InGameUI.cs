using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameUI : MonoBehaviour {

	public static int Trials = 0; //Amount of trials set by player in UI menu
	public static bool trialCountSelected = false; // Checks if the player has finished picking the amount of trials
	public static bool isTargetShowing = false; //Is the target to be matched showing?

	//Canvas containers
	public GameObject trialInputCanvas, confirmationCanvas, winnerCanvas, targetIndicatorCanvas, endGameCanvas, loserCanvas, endTrialCanvas;


	//varying texts for the different canvases
	public Text confirmationText; 
	public Text winnerText;
	public Text endGameText;

	//All buttons that coincide with trial selection amount
	public Button One, Two, Three, Four, Five, Six, Seven, Eight, Nine;
	
	bool scoreGrabbed = false;
	bool updateResults = false;

	float totalScore = 0.0f;

	int trialsPlayed = 0;

	string tempEndGameString = "";
	string tempConfirmationString = "";




	void Update()
	{

		if (isTargetShowing && trialCountSelected == true) 
		{

			targetIndicatorCanvas.SetActive(true);

		}
		else
		{

			targetIndicatorCanvas.SetActive(false);

		}



		if (TargetController.Winner == true) 
		{
			if(scoreGrabbed == false)
			{
				winnerCanvas.SetActive(true);
				winnerText.text = "You made a correct match!\n Your score for that match is: " + Mathf.Ceil(TargetController.Score) + "\n Press 'C' to continue!";
				totalScore += Mathf.Ceil(TargetController.Score);
				scoreGrabbed = true;
				TargetController.Score = 100;
			}

			if (winnerCanvas.activeSelf == true) 
			{
				Time.timeScale = 0; //Stop actions from occuring
				
				if(Input.GetKeyDown (KeyCode.C)) //If the player is prepared for the next round
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

		}

		if (TargetController.Loser == true) 
		{
			loserCanvas.SetActive(true);
			
			if (loserCanvas.activeSelf == true) 
			{
				Time.timeScale = 0; //Stop actions from occuring
				
				if(Input.GetKeyDown (KeyCode.C)) //If the player is prepared for the next round
				{
					TargetController.Loser = false;
					loserCanvas.SetActive(false);
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
			
		}

		if(TargetController.endTrial == true)
		{
			endTrialCanvas.SetActive(true);

			if (endTrialCanvas.activeSelf == true) 
			{
				Time.timeScale = 0; //Stop actions from occuring
				
				if(Input.GetKeyDown (KeyCode.C)) //If the player is prepared for the next round
				{
					TargetController.endTrial = false;
					endTrialCanvas.SetActive(false);
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

		}

		//If the player has picked their amont of trials and then proceeds to press space, they will begin gameplay
		if (confirmationCanvas.activeSelf == true && Input.GetKeyDown (KeyCode.C)) 
		{
			confirmationCanvas.SetActive(false);
			trialCountSelected = true;
			confirmationText.text = tempConfirmationString;
			Time.timeScale = 1;

		}


		if(endGameCanvas.activeSelf == true) // If the player has no more trials after hitting return, they get sent back to the trials menu
		{
			if(updateResults == true)
			{
				tempEndGameString = endGameText.text;
				endGameText.text = endGameText.text + (totalScore/trialsPlayed);
				updateResults = false;
			}	

			if(Input.GetKeyDown (KeyCode.X)) //If the player is prepared for the next round
			{
				trialsPlayed = 0;
				totalScore = 0;
				endGameCanvas.SetActive(false);
				endGameText.text = tempEndGameString;
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
		tempConfirmationString = confirmationText.text;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n\n" + confirmationText.text;
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void TwoPressed()
	{
		Trials = 2;
		tempConfirmationString = confirmationText.text;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n\n" + confirmationText.text;
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void ThreePressed()
	{
		Trials = 3;
		tempConfirmationString = confirmationText.text;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n\n" + confirmationText.text;
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void FourPressed()
	{
		Trials = 4;
		tempConfirmationString = confirmationText.text;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n\n" + confirmationText.text;
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void FivePressed()
	{
		Trials = 5;
		tempConfirmationString = confirmationText.text;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n\n" + confirmationText.text;
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void SixPressed()
	{
		Trials = 6;
		tempConfirmationString = confirmationText.text;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n\n" + confirmationText.text;
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void SevenPressed()
	{
		Trials = 7;
		tempConfirmationString = confirmationText.text;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n\n" + confirmationText.text;
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void EightPressed()
	{
		Trials = 8;
		tempConfirmationString = confirmationText.text;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n\n" + confirmationText.text;
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void NinePressed()
	{
		Trials = 9;
		tempConfirmationString = confirmationText.text;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n\n" + confirmationText.text;
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}

	
}
