using System;
using System.Collections;
using System.Collections.Generic;
using PunBupApi;
using UnityEngine;

public class GameManager : MonoBehaviour {
	// pop up on announcement
	public Announcements AnnouncementsPanel;

	// only spawned in-game
	public Scoreboard ScoreboardPanel;
	public PlayerScoreKeeper Player;

	// dump all activity for debugging
	public LogGatherer LogGatherer;

	private BunBup pn;

	private ChannelSubscription announcementChannel;
	private Channel scoreboardChannel;

	private ChannelPresenceSubscription p;

	async void Start() {
		pn = new BunBup("demo", "demo");
		announcementChannel = pn.CreateChannelSubscription("announcements");
		var aSet = pn.CreateChannelSubscriptions(new[] { "a" });
		var sub = aSet["a"];

		scoreboardChannel = pn.CreateChannel("scoreboard");

		var set = new ChannelSubscriptionSet(new[] { announcementChannel });

		PlayerScoreKeeper.OnPlayerSpawn +=
			keeper => keeper.ScoreboardChannel = scoreboardChannel;

		Scoreboard.OnScoreboardSpawn += scoreboard =>
			scoreboard.ScoreboardChannelSubscription = pn.CreateChannelSubscription(scoreboardChannel);

		pn.Subscribe();
	}
}
