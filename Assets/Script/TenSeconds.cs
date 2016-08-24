using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TenSeconds : MonoBehaviour {
    [SerializeField]
    private float gameZikan = 10;
    private float timer;
    [SerializeField]
    private Text text;

    private bool isTouchStart = false;

	public Judge judge;

	// Use this for initialization
	void Start () {
        timer = gameZikan - 0.001f;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            isTouchStart = true;

        if (isTouchStart)
        {
            timer -= Time.deltaTime;
            if (timer < 0.0f)
            {
                text.text = "0";
				judge.JadgeGame();
                //リザルトに値を渡す場所

                SceneManager.LoadScene("Result");
            }
            float temp1 = timer * 100;
            int temp2 = (int)temp1;
            temp1 = temp2 / 100.0f;

            text.text = temp1.ToString();
        }
	}
}
