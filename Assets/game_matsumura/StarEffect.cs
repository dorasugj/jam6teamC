using UnityEngine;
using System.Collections;

public class StarEffect : MonoBehaviour {
    private bool isPlay = false;
    private float starTimer = 0.0f;
    [SerializeField]
    private float effectTime;
    private float first;
    private float second;
    private float third;
    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        first = effectTime / 4.0f;
        second = effectTime / 2.0f;
        third = effectTime / 1.5f;

        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
            PlayStar();

        if (isPlay)
        {
            starTimer += Time.deltaTime;
            if (starTimer < first)
            {

            }
            else if (starTimer < second)
            {
                transform.position = (Vector3.up + Vector3.right) / 2.0f;
            }
            else if (starTimer < third)
            {
                transform.position = Vector3.zero;
            }
            else if (starTimer < effectTime)
            {
                transform.position = (Vector3.up + Vector3.right) / 2.0f;
            }
            if (starTimer > effectTime)
            {
                isPlay = false;
                sprite.enabled = false;
            }
        }
	
	}

    public void PlayStar()
    {
        if (isPlay)
            return;
        isPlay = true;
        starTimer = 0.0f;
        transform.position = Vector3.zero;
        sprite.enabled = true;
    }
}
