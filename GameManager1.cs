using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour {
	
	public SpriteRenderer[] colors;
	public AudioSource[] buttonSounds;

	private int colorSelect;

	public float stayLit;
	private float stayLitCounter;

	public float waitBetweenLights;
	private float waitBetweenCounter;

	private bool shouldbeLit;
	private bool shouldbeDark;

	public List <int> activeSequence;
	private int positionInSequence;

	private bool gameActive;
	private int inputInSequence;

	public AudioSource correct;
	public AudioSource incorrect;



	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (shouldbeLit) 
		{
			stayLitCounter -= Time.deltaTime;

			if (stayLitCounter < 0)
			{
				colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r, colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 0.5f); 
				buttonSounds[activeSequence[positionInSequence]].Stop();
				shouldbeLit = false;

				shouldbeDark = true;
				waitBetweenCounter = waitBetweenLights;

				positionInSequence++;
			}
		}

		if (shouldbeDark) 
		{
			waitBetweenCounter -= Time.deltaTime;

			if (positionInSequence >= activeSequence.Count)
			{
				shouldbeDark = false;
				gameActive = true;
			} else {
				if (waitBetweenCounter < 0) 
				{


					colors [activeSequence [positionInSequence]].color = new Color (colors [activeSequence [positionInSequence]].color.r, colors [activeSequence [positionInSequence]].color.g, colors [activeSequence [positionInSequence]].color.b, 1f); 
					buttonSounds[activeSequence[positionInSequence]].Play();

					stayLitCounter = stayLit;
					shouldbeLit = true;
					shouldbeDark = false;
				}
			}
		}
	}

	public void StartGame()
	{
		activeSequence.Clear ();

		positionInSequence = 0;
		inputInSequence = 0;

		colorSelect = Random.Range (0, colors.Length);

		activeSequence.Add(colorSelect);
			
		colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r, colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 1f); 
		buttonSounds[activeSequence[positionInSequence]].Play();

		stayLitCounter = stayLit;
		shouldbeLit = true;
	}

	public void ColorPressed(int whichButton)
	{
		if(gameActive)
		{
			
			if (activeSequence[inputInSequence] == whichButton)
			{
				Debug.Log ("Correct");
			

				inputInSequence++;

				if (inputInSequence >= activeSequence.Count) 
				{
					positionInSequence = 0;
					inputInSequence = 0;

					colorSelect = Random.Range (0, colors.Length);

					activeSequence.Add(colorSelect);

					colors[activeSequence[positionInSequence]].color = new Color(colors[activeSequence[positionInSequence]].color.r, colors[activeSequence[positionInSequence]].color.g, colors[activeSequence[positionInSequence]].color.b, 1f); 
					buttonSounds[activeSequence[positionInSequence]].Play();

					stayLitCounter = stayLit;
					shouldbeLit = true;

					gameActive = false;

					correct.Play ();
				}

			} else {
				Debug.Log ("Wrong");
				incorrect.Play();
				gameActive = false;
			}
		}
	}
}
