using System;
using Unity.Services.Core;
using UnityEngine;

public class Import : MonoBehaviour
{
	async void Awake()
	{
		try
		{
			await UnityServices.InitializeAsync();
		}
		catch (Exception e)
		{
			Debug.Log("import exception");
			Debug.LogException(e);
		}
	}
}