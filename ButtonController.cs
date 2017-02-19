using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	private SpriteRenderer theSprite;

	public int thisButtonNumber;

	private GameManager1 theGM1;

	private AudioSource theSound;

	// Use this for initialization
	void Start () {
		theSprite = GetComponent<SpriteRenderer>();
		theGM1 = FindObjectOfType<GameManager1>();
		theSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		theSprite.color = new Color (theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);
		theSound.Play();
	}

	void OnMouseUp()
	{
		theSprite.color = new Color (theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.5f);
		theGM1.ColorPressed (thisButtonNumber);
		theSound.Stop();
	}
}  
