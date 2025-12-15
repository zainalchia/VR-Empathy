using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageFader : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] float time;
	[SerializeField] float opacity;
	float timer = -1;
	Color startingColor;

	private void Update()
	{
		if (timer <= 0) return;

		Color color = image.color;
		timer -= Time.deltaTime;
		if(timer <= 0)
			color.a = opacity;
		else

            color.a = Mathf.Lerp(opacity, startingColor.a, timer / time);

        image.color = color;


	}

	// public functions
	public void Activate(float targetOpacity)
	{
		opacity = targetOpacity;
		timer = time;
		startingColor = image.color;
	}
}
