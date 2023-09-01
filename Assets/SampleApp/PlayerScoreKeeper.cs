using System.Collections;
using System.Collections.Generic;
using PunBupApi;
using UnityEngine;

public class PlayerScoreKeeper : MonoBehaviour {

	public static event System.Action<PlayerScoreKeeper> OnPlayerSpawn;
	public Channel ScoreboardChannel;

	void Start() {
		OnPlayerSpawn?.Invoke(this);
	}

	void AddScore() {
		ScoreboardChannel.Publish("+1");
	}

	void OnDestroy() {

	}
}