using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class TestPlayfab : MonoBehaviour
{

	void Start()
	{
		StartCoroutine(RunTest());
	}

	private IEnumerator RunTest()
	{
		Debug.Log("Start testing...");
		yield return TestLogin();
		yield return TestGetTitle();
		Debug.Log("Testing done!");
	}

	private IEnumerator TestLogin()
	{
		Debug.Log("[TestLogin]");
		var busy = true;

		PlayFabClientAPI.LoginWithCustomID(
			new LoginWithCustomIDRequest()
			{
				TitleId = "CA70",
				CustomId = "8fa79815413d472d",
				CreateAccount = true
			},
			(result) =>
			{
				Debug.Log("TestLogin result: " + result);
				busy = false;
			},
			(error) =>
			{
				Debug.LogError("TestLogin error: " + error);
			}
		);

		yield return new WaitWhile(() => busy);
	}
	
	private IEnumerator TestGetTitle()
	{
		Debug.Log("[TestGetTitle]");
		var busy = true;

		PlayFabClientAPI.GetTitleData(
			new GetTitleDataRequest()
			{
				Keys = null
			},
			(result) =>
			{
				Debug.Log("TestGetTitle result: ");
				foreach(var keyVal in result.Data)
				{
					Debug.LogFormat("Key = {0}, Value = {1}", keyVal.Key, keyVal.Value);
				}
			},
			(error) =>
			{
				Debug.LogError("TestGetTitle error: " + error);
			}
		);

		yield return new WaitWhile(() => busy);
	}
}
