using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using UnityStandardAssets.Cameras;

public class WarpMaster : MonoBehaviour
{
	public Dictionary<int, WarpPoint> warpPoints = new Dictionary<int, WarpPoint>();
	public GameObject warpMenuPanel;
	public GameObject warpButtonPrefab;
	public GameObject player;

	public void AddWarpPoint(int id, WarpPoint warpPoint)
	{
		if (!warpPoints.ContainsKey(id))
		{
			warpPoints.Add(id, warpPoint);
			AddWarpButton(warpPoint);
		}
	}

	public void AddWarpButton(WarpPoint warpPoint)
	{
		GameObject clone = GameObject.Instantiate<GameObject>(warpButtonPrefab);

		Text cloneText = clone.GetComponentInChildren<Text>();
		if (cloneText != null)
		{
			cloneText.text = warpPoint.warpName;
		}

		WarpButton warpButton = clone.GetComponentInChildren<WarpButton>();
		if (warpButton != null)
		{
			warpButton.player = player;
			warpButton.warpPoint = warpPoint;
		}

		clone.transform.SetParent(warpMenuPanel.transform);
		clone.transform.localScale = Vector3.one;
	}

	public void ShowWarpPoints(bool show, int indexHide)
	{
		// Disable mouse rotation
		EnableSimpleMouseRotator(!show);

		// Unlock the cursor when showing warp points
		LockCursor(!show);

		// Show the warp menu
		if (warpPoints.Count > 1)
		{
			warpMenuPanel.SetActive(show);
		}

		// Hide the warp point that the player is standing in
		warpMenuPanel.transform.GetChild(indexHide).gameObject.SetActive(!show);
	}
	
	public static void EnableSimpleMouseRotator(bool enable)
	{
		SimpleMouseRotator smr = Camera.main.GetComponentInParent<SimpleMouseRotator>();
		if (smr != null)
		{
			smr.rotationSpeed = (enable ? 10.0f : 0.0f);
		}
	}

	public static void LockCursor(bool lockState)
	{
		Cursor.lockState = lockState ? CursorLockMode.Locked : CursorLockMode.None;
		Cursor.visible = !lockState;
	}
	
	public void WarpTo(GameObject go, int index)
	{
		WarpTo(go, warpPoints[index]);
	}
	
	public void WarpTo(GameObject go, WarpPoint warpPoint)
	{
		if (warpPoint != null)
		{
			go.transform.position = warpPoint.transform.position;
		}
	}
}