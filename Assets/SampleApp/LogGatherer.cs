using System.Collections;
using System.Collections.Generic;
using PunBupApi;
using UnityEngine;

public class LogGatherer : MonoBehaviour {
	public IBunBupEventEmitter Sink;

	void Start() {
		Sink.onMessage += SaveLogsToDrive;
	}

	void SaveLogsToDrive(string s) {
		// Something here
	}

	// Update is called once per frame
	void Update() {
	}
}