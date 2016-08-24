using UnityEngine;
using System.Collections;

public class Judge : MonoBehaviour {

	private int judge = 0;
	private float[] judgeTime = new float[] { 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f, 0.7f };
	private int[] jadgeResult = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	//private int[] jadgeResult = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
	//private int[] jadgeResult = new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 };
	//private int[] jadgeResult = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };
	//private int[] jadgeResult = new int[] { 0, 0, 0, 0, 0, 0, 2, 2, 2, 1 };
	//private int[] jadgeResult = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
	private int judgeCounter_01 = 0;
	private int judgeCounter_02 = 0;
	private int judgeCounter_03 = 0;
	// Use this for initialization

	public StarEffect effect;
	void Start () {
		judge = 0;
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	public void JudgeStart(int count , float time)
	{
		if (judge < count/*回転数*/)
		{
			// 回転が絶妙なタイミング
			if ((judgeTime[judge] <= time/*回転にかかった時間*/ + 0.2f) &&
				(judgeTime[judge] >= time/*回転にかかった時間*/ - 0.2f))
			{
				Debug.Log("絶妙");
				jadgeResult[judge] = 1;
				effect.PlayStar();
			}
			// 回転が早い
			else if (judgeTime[judge] < time/*回転にかかった時間*/ - 0.2f)
			{
				Debug.Log("早い");
				jadgeResult[judge] = 2;
			}
			// 回転が遅い
			else if (judgeTime[judge] > time/*回転にかかった時間*/ + 0.2f)
			{
				Debug.Log("遅い");
				jadgeResult[judge] = 3;
			}
			judge++;
		}
	}


	public void JadgeGame()
	{
		for(int i = 0;i<10;i++)
		{
			if(jadgeResult[i] == 1)
			{
				judgeCounter_01++;
			}
			else if(jadgeResult[i] == 2)
			{
				judgeCounter_02++;
			}
			else if(jadgeResult[i] == 3)
			{
				judgeCounter_03++;
			}
			
		}

		// パーフェクトタイミング
		if(judgeCounter_01 == 10)
		{
			Debug.Log("パーフェクト");
			PlayerPrefs.SetInt("Result", 1);
		}
		// グッドタイミング
		else if (judgeCounter_01 > 7)
		{
			Debug.Log("グッド");
			PlayerPrefs.SetInt("Result", 2);
		}
		// 普通
		else if (judgeCounter_01 > 4)
		{
			Debug.Log("普通");
			PlayerPrefs.SetInt("Result", 3);
		}
		// 悪い
		else
		{
			Debug.Log("悪い");
			// 早い
			if (judgeCounter_02 > judgeCounter_03)
			{
				PlayerPrefs.SetInt("Result", 4);
			}
			// 遅い
			else{
				PlayerPrefs.SetInt("Result", 5);
			}
		}
	}
}
