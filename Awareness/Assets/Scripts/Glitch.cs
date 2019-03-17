using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
	private AudioSource audioSource;
	private bool checkIfGlitched = true;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && checkIfGlitched == true)
		{
			audioSource.Play();
			checkIfGlitched = false;
		}
		else if (collision.gameObject.CompareTag("Player") && checkIfGlitched == false)
		{

		}
	}
}
