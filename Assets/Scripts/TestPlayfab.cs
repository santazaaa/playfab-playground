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
		yield return TestGetStatistic();
		yield return TestGetCatalogItems();
		yield return TestPurchaseItem();
		yield return TestGetUserInventory();
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
				busy = false;
			},
			(error) =>
			{
				Debug.LogError("TestGetTitle error: " + error);
			}
		);

		yield return new WaitWhile(() => busy);
	}

	private IEnumerator TestGetStatistic()
	{
		Debug.Log("[TestGetStatistic]");
		var busy = true;

		PlayFabClientAPI.GetPlayerStatistics(
			new GetPlayerStatisticsRequest()
			{
				StatisticNames = null
			},
			(result) =>
			{
				Debug.Log("TestGetStatistic result: ");
				foreach(var keyVal in result.Statistics)
				{
					Debug.LogFormat("Key = {0}, Value = {1}, Version = {2}", keyVal.StatisticName, keyVal.Value, keyVal.Version);
				}
				busy = false;
			},
			(error) =>
			{
				Debug.LogError("TestGetStatistic error: " + error);
			}
		);

		yield return new WaitWhile(() => busy);
	}

	private IEnumerator TestGetCatalogItems()
	{
		Debug.Log("[TestGetCatalogItems]");
		var busy = true;

		PlayFabClientAPI.GetCatalogItems(
			new GetCatalogItemsRequest()
			{
				CatalogVersion = null
			},
			(result) =>
			{
				Debug.Log("TestGetCatalogItems result: ");
				foreach(var keyVal in result.Catalog)
				{
					Debug.LogFormat("Display name = {0}", keyVal.DisplayName);
				}
				busy = false;
			},
			(error) =>
			{
				Debug.LogError("TestGetCatalogItems error: " + error);
			}
		);

		yield return new WaitWhile(() => busy);
	}

	private IEnumerator TestPurchaseItem()
	{
		Debug.Log("[TestPurchaseItem]");
		var busy = true;

		PlayFabClientAPI.PurchaseItem(
			new PurchaseItemRequest()
			{
				CatalogVersion = null,
				ItemId = "apple",
				VirtualCurrency = "GO",
				Price = 5
			},
			(result) =>
			{
				Debug.Log("TestPurchaseItem result: OK");
				busy = false;
			},
			(error) =>
			{
				Debug.LogError("TestPurchaseItem error: " + error);
			}
		);

		yield return new WaitWhile(() => busy);
	}

	private IEnumerator TestGetUserInventory()
	{
		Debug.Log("[TestGetUserInventory]");
		var busy = true;

		PlayFabClientAPI.GetUserInventory(
			new GetUserInventoryRequest()
			{

			},
			(result) =>
			{
				Debug.Log("TestGetUserInventory result: ");
				foreach(var keyVal in result.Inventory)
				{
					Debug.LogFormat("Display name = {0}", keyVal.DisplayName);
				}
				busy = false;
			},
			(error) =>
			{
				Debug.LogError("TestGetUserInventory error: " + error);
			}
		);

		yield return new WaitWhile(() => busy);
	}

}
