using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public SpriteRenderer[] colors;

	private int colorSelect;

	public float stayLit;
	private float stayLitCounter;

	// Use this for initialization
	void Start () {
		 
	} 
	
	// Update is called once per frame
	void Update () {
		if (stayLitCounter > 0) 
		{
			stayLitCounter -= Time.deltaTime;

		} else {
			colors[colorSelect].color = new Color(colors[colorSelect].color.r, colors[colorSelect].color.g, colors[colorSelect].color.b, 0.5f); 

		} 
	}

	public void StartGame()
	{
		colorSelect = Random.Range(0, colors.Length);

		colors[colorSelect].color = new Color(colors[colorSelect].color.r,colors[colorSelect].color.g, colors[colorSelect].color.b, 1f); 

		stayLitCounter = stayLit;
	}
}  
	