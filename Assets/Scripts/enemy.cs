using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	// Use this for initialization
    public float enemySpeed = -5.0f;


	void Start () {
        Physics2D.IgnoreCollision(this.transform.gameObject.GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>());
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {

	}
    void FixedUpdate() {
        Collider2D zhuang = Physics2D.OverlapPoint(this.transform.Find("frontCheck").position, 1 << LayerMask.NameToLayer("wall"));
        if (zhuang != null)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x * -1, this.GetComponent<Rigidbody2D>().velocity.y);

        }

    }

}