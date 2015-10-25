using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WarpPoint : MonoBehaviour
{
	public int id;

	public static Dictionary<int, WarpPoint> warpPoints = new Dictionary<int, WarpPoint>();
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			if (!warpPoints.ContainsKey(id))
			{
				warpPoints.Add(id, this);
			}
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			if (Input.GetKeyUp(KeyCode.Alpha1))
			{
				WarpTo(other.transform, 0);
			}
			else
			if (Input.GetKeyUp(KeyCode.Alpha2))
			{
				WarpTo(other.transform, 1);
			}
			else
			if (Input.GetKeyUp(KeyCode.Alpha3))
			{
				WarpTo(other.transform, 2);
			}
			else
			if (Input.GetKeyUp(KeyCode.Alpha4))
			{
				WarpTo(other.transform, 3);
			}
		}
	}

	public static void WarpTo(Transform t, int destinationIndex)
	{
		WarpTo(t, warpPoints[destinationIndex]);
	}

	public static void WarpTo(Transform t, WarpPoint destination)
	{
		if (destination != null)
		{
			t.position = destination.transform.position;
		}
	}

	public static void DisplayWarpPoints()
	{
		// UI Display of warp points
	}
}
