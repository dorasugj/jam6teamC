using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    public int spinCount = 0;
    private float oneSpinTimer = 0.0f;

	public Judge judge;
    //配列と列挙型に変更
    //private bool inRightBottom = false;
    //private bool inRightTop = false;
    //private bool inLeftTop = false;
    //private bool inLeftBottom = false;

    [SerializeField]
    private bool[] passCorner = new bool[4];

    enum FourCorner
    {
        RightBottom,
        RightTop,
        LeftTop,
        LeftBottom
    }
    
	// Use this for initialization
	void Start () {
        PassCornerReset();
        //Debug.Log((int)FourCorner.RightBottom);
        //Debug.Log((int)FourCorner.RightTop);
        //Debug.Log((int)FourCorner.LeftTop);
        //Debug.Log((int)FourCorner.LeftBottom);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            var mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos.z = 0.0f;
            transform.position = mousePos;

            oneSpinTimer += Time.deltaTime;
        }
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "RightBottom")
        {
            int cornerNum = (int)FourCorner.RightBottom;

            //一周してたら
            if (OneSpinCheck())
            {
                SendOneSpin();
                passCorner[cornerNum] = true;
            }

            if (passCorner[cornerNum])
                return;

            if(passCorner[(cornerNum+3)%4]||AllFalseCheck())
                passCorner[cornerNum] = true;
        }
        else if (col.tag == "RightTop")
        {
            int cornerNum = (int)FourCorner.RightTop;
            if (OneSpinCheck())
            {
                SendOneSpin();
                passCorner[cornerNum] = true;
            }

            if (passCorner[cornerNum])
                return;

            if (passCorner[(cornerNum + 3) % 4] || AllFalseCheck())
                passCorner[cornerNum] = true;
        }
        else if (col.tag == "LeftTop")
        {
            int cornerNum = (int)FourCorner.LeftTop;
            if (OneSpinCheck())
            {
                SendOneSpin();
                passCorner[cornerNum] = true; 
            }

            if (passCorner[cornerNum])
                return;

            if (passCorner[(cornerNum + 3) % 4] || AllFalseCheck())
                passCorner[cornerNum] = true;
        }
        else if (col.tag == "LeftBottom")
        {
            int cornerNum = (int)FourCorner.LeftBottom;
            if (OneSpinCheck())
            {
                SendOneSpin();
                passCorner[cornerNum] = true;
            }

            if (passCorner[cornerNum])
                return;

            if (passCorner[(cornerNum + 3) % 4] || AllFalseCheck())
                passCorner[cornerNum] = true;
        }
    }

    //全てfalseならtrueを返す
    bool AllFalseCheck()
    {
        for (int i = 0; i < 4; i++)
        {
            if (passCorner[i])
                return false;
        }

        return true;
    }

    //一周したかのチェック
    bool OneSpinCheck()
    {
        
        for (int i = 0; i < 4; i++)
        {
            //通ってない箇所があったらfalse
            if (!passCorner[i])
            {
                return false;
            }
                
        }
        //Debug.Log("関数:OneSpinCheck");
        return true;
        //return passCorner[0] & passCorner[1] & passCorner[2] & passCorner[3];
    }

    //一周したときに呼ばれる
    void SendOneSpin()
    {
        //Debug.Log("関数:SendOneSpin");
        spinCount++;
        if (spinCount < 11)
        {
            Debug.Log(spinCount);
            Debug.Log(oneSpinTimer);

            //ここで送ります
            //(spinCount,oneSpinTimer)
			judge.JudgeStart(spinCount, oneSpinTimer);
            oneSpinTimer = 0.0f;
            
            PassCornerReset();
        }
        
    }

    //passCornerを全てfalseに
    void PassCornerReset()
    {
        //Debug.Log("関数:PassCornerReset");
        for (int i = 0; i < 4; i++)
        {
            passCorner[i] = false;
        }
    }
}
