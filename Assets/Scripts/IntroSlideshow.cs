using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSlideshow : MonoBehaviour
{
	public Image image;

	private int currentImage;

	public float timer = 4.0f;
	public float timerRemaining = 4.0f;
	public bool timerIsRunning = true;

	public Sprite[] images;

	// Start is called before the first frame update
	void Start()
	{
		currentImage = 0;
		timerRemaining = timer;
		timerIsRunning = true;
		image.sprite = images[currentImage];
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			ShowNextImage();
		}

		CheckTimer();
	}

	private void CheckTimer()
	{
		if (!timerIsRunning)
		{
			return;
		}

		if (timerRemaining > 0)
		{
			timerRemaining -= Time.deltaTime;
		}
		else
		{
			ShowNextImage();
		}
	}


	private void ShowNextImage()
	{
		if (++currentImage >= images.Length)
		{
			SceneManager.LoadScene(1);
			return;
		}

		timerRemaining = timer;
		image.sprite = images[currentImage];
	}

}
