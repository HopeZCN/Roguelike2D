using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreCollision(this.transform.gameObject.GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
