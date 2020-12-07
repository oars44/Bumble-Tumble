using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorController : MonoBehaviour {

    public GameObject bee;
    public LineRenderer left;
    public LineRenderer right;
    public SpriteRenderer tether;

    private Rigidbody2D rb;
    private Rigidbody2D beerb;
    private Animator anim;
    private SpringJoint2D spring;
    LayerMask ignore;
    bool hasjoint = false;

    private void Start()
    {
            anim = bee.GetComponent<Animator>();
            beerb = bee.GetComponent<Rigidbody2D>();
            rb = GetComponent<Rigidbody2D>();
            ignore = gameObject.layer;


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
            Vector3 contact = other.contacts[0].point;
            BeeFling fling = bee.GetComponent<BeeFling>();


        if(other.gameObject.name == "Bee" && fling.anchor != rb.transform)
        {

            tether.enabled = false;
            fling.tether = tether;

            if (fling.side == "down")
                fling.side = "up";
            else
                fling.side = "down";

            fling.ToIgnore = ignore;
            fling.ignore = true;

            beerb.velocity = Vector2.zero;
            beerb.angularVelocity = 0f;

            Vector2 newpos = new Vector2(contact.x, transform.position.y);
            transform.position = newpos;


            if (fling.spring == null)
            {
                Debug.Log("Adding joint");
                other.gameObject.AddComponent<SpringJoint2D>();
                spring = bee.GetComponent<SpringJoint2D>();
                hasjoint = true;
            }


            beerb.isKinematic = true;
            spring.connectedBody = rb;
            spring.frequency = 5;
            spring.autoConfigureDistance = false;
            spring.distance = .005f;
            anim.SetBool("Flying", false);
            fling.OnTether = true;
            fling.right = right;
            fling.left = left;
            fling.LineSetUp();

            fling.anchor = rb.transform;

            fling.mouseRay = new Ray(fling.anchor.transform.position, Vector3.zero);
            fling.anchorToBee = new Ray(fling.anchor.transform.position, Vector3.zero);

            fling.spring = spring;
        }
    }

   
}
