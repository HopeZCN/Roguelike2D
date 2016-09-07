using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float maxForce = 100.0f;
    public float maxJumpForce = 500.0f;
    float h = 0.0f;

    private bool isJumping;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawLine(this.transform.position, this.transform.Find("underCheck").position);
	
	}

    void FixedUpdate ()
    {
        h = Input.GetAxis("Horizontal");

        Rigidbody2D body = this.GetComponent<Rigidbody2D>();


        body.AddForce(h*maxForce*Vector2.right);

        isJumping = !Physics2D.Linecast(this.transform.position, this.transform.Find("underCheck").position, 1 << LayerMask.NameToLayer("wall"));

        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            body.AddForce(new Vector2(0, maxJumpForce));
        }

        if (body.velocity.y > 5)
        {
            body.velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 5);
        }

        if ((h < 0 && this.transform.localScale.x > 0) || (h > 0 && this.transform.localScale.x < 0)) 
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
        }
    }

}
