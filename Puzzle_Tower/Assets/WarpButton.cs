using UnityEngine;
using System.Collections;

public class WarpButton : MonoBehaviour
{
	public GameObject player;
	public WarpPoint warpPoint;

	public void Warp()
	{
		warpPoint.master.WarpTo(player, warpPoint.master.warpPoints[warpPoint.id]);
	}
}