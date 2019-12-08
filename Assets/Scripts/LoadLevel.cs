using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour {

	public string levelname = "enter level name";
	public void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Application.LoadLevel (levelname);
		}
	}
}