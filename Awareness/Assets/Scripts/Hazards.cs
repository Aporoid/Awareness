using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazards : MonoBehaviour
{
	private int LevelChange = 0;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && LevelChange == 0)
		{
			LevelChange++;
			SceneManager.LoadScene(0);
		}
		else if (collision.gameObject.CompareTag("Player") && LevelChange == 1)
		{
			LevelChange++;
			SceneManager.LoadScene(1);
		}
	}
}
