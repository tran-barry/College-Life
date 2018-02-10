using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathMonsterController : MonoBehaviour {
	public enum OccilationFunction { Sine, Cosine};

	public void Start()
	{
		StartCoroutine (Oscillate (OccilationFunction.Cosine, 10f));
	}

	private IEnumerator Oscillate (OccilationFunction method, float scalar)
	{
		while (true)
		{
			if (method == OccilationFunction.Sine)
			{
				transform.position = new Vector3 (Mathf.Sin (Time.time) * scalar, transform.position.y, 0);
			}
			else if (method == OccilationFunction.Cosine)
			{
				transform.position = new Vector3 (Mathf.Cos (Time.time) * scalar, transform.position.y, 0);
			}
			yield return new WaitForEndOfFrame ();
		}
	}
}