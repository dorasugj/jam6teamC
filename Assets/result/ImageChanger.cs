using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageChanger : MonoBehaviour {


	public Sprite sprite01;
	public Sprite sprite02;
	public Sprite sprite03;
	public Sprite sprite04;
	public Sprite sprite05;

	private Image image;

	private int result;

	// Use this for initialization
	void Start () {

		image = GameObject.Find(gameObject.name).GetComponent<Image>();
		result = PlayerPrefs.GetInt("Result");
	}
	
	// Update is called once per frame
	void Update () {
		switch (result/*結果*/)
		{
			case 1:
				image.sprite = sprite01;
				break;
			case 2:
				image.sprite = sprite02;
				break;
			case 3:
				image.sprite = sprite03;
				break;
			case 4:
				image.sprite = sprite04;
				break;
			case 5:
				image.sprite = sprite05;
				break;
			default:
				image.sprite = sprite05;
				break;
		}
	}
}
