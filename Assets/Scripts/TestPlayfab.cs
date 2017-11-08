using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class TestPlayfab : MonoBehaviour
{

	void Start()
	{
		PlayFabClientAPI.LoginWithCustomID(
			new LoginWithCustomIDRequest()
			{
				TitleId = "CA70",
				CustomId = "8fa79815413d472d",
				CreateAccount = true
			},
			(result) =>
			{
				Debug.Log("Login result: " + result);
			},
			(error) =>
			{
				Debug.LogError("Login error: " + error);
			}
		);
	}
	
	void Update()
	{
		
	}
}
