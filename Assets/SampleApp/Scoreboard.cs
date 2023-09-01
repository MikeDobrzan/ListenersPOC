using System.Collections;
using System.Collections.Generic;
using PunBupApi;
using UnityEngine;

public class Scoreboard : MonoBehaviour {
	public static event System.Action<Scoreboard> OnScoreboardSpawn;
	public ChannelSubscription ScoreboardChannelSubscription;

	void Start() {
		OnScoreboardSpawn?.Invoke(this);
		ScoreboardChannelSubscription.onMessage += s => { Debug.Log("Display score"); };
		ScoreboardChannelSubscription.Subscribe();
	}

	void OnDestroy() {
		ScoreboardChannelSubscription.Unsubscribe();
	}
}