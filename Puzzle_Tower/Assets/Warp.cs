using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Warp : MonoBehaviour
{
	public static List<WarpPoint> destinations = new List<WarpPoint>();

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void AddWarpPoint(WarpPoint warpPoint)
	{
		destinations.Add(warpPoint);
	}

	public void ShowDestinations()
	{

	}

	public void WarpTo(int destinationIndex)
	{
		WarpTo(destinations[destinationIndex]);
	}

	public void WarpTo(WarpPoint destination)
	{

	}
}
