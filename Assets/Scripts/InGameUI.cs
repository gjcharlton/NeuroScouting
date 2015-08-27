using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameUI : MonoBehaviour {

	public static int Trials; //Amount of trials set by player in UI menu
	public static bool trialCountSelected; // Checks if the player has finished picking the amount of trials

	public GameObject trialInputCanvas; 
	public GameObject confirmationCanvas;
	public GameObject winnerCanvas;

	//All buttons that coincide with trial amount
    public Button One;
    public Button Two;
    public Button Three;
    public Button Four;
    public Button Five;
    public Button Six;
    public Button Seven;
    public Button Eight;
    public Button Nine;

    public Text confirmationText; // Text for the confirmation once the player has chosen the amount of trials
	public Text winnerText;
	void Update()
	{
		if (TargetController.Winner == true) 
		{
			winnerCanvas.SetActive(true);
			winnerText.text = "You made a correct match!\n Your score for that match is: " + TargetController.Score;

		}

		//If the player has picked their amont of trials and then proceeds to press space, they will begin gameplay
		if (confirmationCanvas.activeSelf == true && Input.GetKeyDown (KeyCode.Space)) 
		{
			confirmationCanvas.SetActive(false);
			trialCountSelected = true;
			Time.timeScale = 1;
		}

		if (winnerCanvas.activeSelf == true) 
		{

			Time.timeScale = 0;
		}
	}

	//All of these functions are UI functions that will change the text of the confirmation window depending on which you press.
	//Each will change the int "Trials" appropriately
	//Each will also turn off the trial input canvas once a number icon has been pressed, thus turning on the confirmation panel
	public void OnePressed()
	{
		Trials = 1;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the spacebar to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void TwoPressed()
	{
		Trials = 2;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the spacebar to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void ThreePressed()
	{
		Trials = 3;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the spacebar to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void FourPressed()
	{
		Trials = 4;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the spacebar to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void FivePressed()
	{
		Trials = 5;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the spacebar to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void SixPressed()
	{
		Trials = 6;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the spacebar to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void SevenPressed()
	{
		Trials = 7;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the spacebar to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void EightPressed()
	{
		Trials = 8;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the spacebar to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}
	public void NinePressed()
	{
		Trials = 9;
		confirmationText.text = "You have chosen " + Trials + " trial(s) to play.\n Press the spacebar to continue!";
		trialInputCanvas.SetActive (false);
		confirmationCanvas.SetActive (true);
	}

	
}
