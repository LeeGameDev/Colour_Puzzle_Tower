using UnityEngine;
using System.Collections;

public class ResetDevice : MonoBehaviour
{
	public CloakColour invisibleToMe;
	public Transform warpTo;

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
		WarpVisiblePlayer(other);
	}

	void OnTriggerStay(Collider other)
	{
		WarpVisiblePlayer(other);
	}

	bool IsVisible(Collider other)
	{
		Cloak playerCloak = other.GetComponent<Cloak>();
		if (playerCloak != null)
		{
			return !playerCloak.isInUse || (playerCloak.activeColour != invisibleToMe);
		}
		return true;
	}

	void WarpVisiblePlayer(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			if (IsVisible(other))
			{
				WarpPlayer(other);
			}
		}
	}

	void WarpPlayer(Collider other)
	{
		other.transform.position = warpTo.transform.position;
	}
}
