using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer.enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			spriteRenderer.enabled = true;
		}
	}
}
