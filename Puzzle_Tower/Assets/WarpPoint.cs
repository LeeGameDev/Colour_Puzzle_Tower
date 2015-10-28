using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

public class WarpPoint : MonoBehaviour
{
	public int id;
	public WarpMaster master;
	public string warpName;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			if (master != null)
			{
				master.AddWarpPoint(id, this);
				master.ShowWarpPoints(true, id);
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.tag.Equals("Player"))
		{
			if (master != null)
			{
				master.ShowWarpPoints(false, id);
			}
		}
	}
}