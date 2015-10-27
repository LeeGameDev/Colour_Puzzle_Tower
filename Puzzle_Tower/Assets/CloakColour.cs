using UnityEngine;
using System.Collections;

public class CloakColour : MonoBehaviour
{
	public Material cloakMat;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{

	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			Cloak playerCloak = other.GetComponent<Cloak>();
			if (playerCloak != null)
			{
				playerCloak.AddCloakColour(this);
				DisableRenderer();
			}
		}
	}

	void DisableRenderer()
	{
		gameObject.SetActive(false);
	}
}