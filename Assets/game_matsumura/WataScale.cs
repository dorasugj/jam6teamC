using UnityEngine;
using System.Collections;

public class WataScale : MonoBehaviour {
    [SerializeField]
    private Spin spin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int cnt = spin.spinCount;
        transform.localScale = Vector3.one * cnt / 2;
	}
}
