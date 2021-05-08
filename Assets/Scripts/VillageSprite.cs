using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VillageSprite : MonoBehaviour
{
    public string sceneToLoad;
    public string destinationTile;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			//StartCoroutine(SceneTransitionManager.Instance.LoadScene(sceneToLoad, destinationTile));
			SceneManager.LoadScene(sceneToLoad);
		}
	}
}
