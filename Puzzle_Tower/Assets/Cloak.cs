using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cloak : MonoBehaviour
{
	public List<CloakColour> colours = new List<CloakColour>();
	public CloakColour selectedCloakColour;
	public float activationDuration = 2.0f;
	public bool isInUse = false;

	private float resetTimer = 0.0f;

	// Use this for initialization
	private void Start()
	{

	}
	
	// Update is called once per frame
	private void Update()
	{
		if (isInUse)
		{
			if (resetTimer > 0.0f)
			{
				resetTimer -= Time.deltaTime;
			}
			else
			{
				isInUse = false;
			}
		}
		else
		{
			if (Input.GetKeyUp(KeyCode.Space))
			{
				Use();
			}
		}
	}

	public void SelectCloakColour(CloakColour cloakColour)
	{
		selectedCloakColour = cloakColour;
	}

	public void AddCloakColour(CloakColour cloakColour)
	{
		colours.Add(cloakColour);
		SelectCloakColour(cloakColour);
	}

	// Use the cloak with the selected cloak colour to hide from the reset device
	public void Use()
	{
		if (selectedCloakColour != null)
		{
			// Hide from selectedCloakColour colour
			// Begin timer
			resetTimer = activationDuration;
			
			// Flag use
			isInUse = true;
		}
	}
}