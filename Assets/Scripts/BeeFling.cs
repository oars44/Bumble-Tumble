using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeFling : MonoBehaviour {

    public float maxstretch = 1.5f;
    public LineRenderer left;
    public LineRenderer right;
    public LayerMask ToIgnore;
    public bool ignore = true;
    public SpriteRenderer tether;
    public GameObject deathMenu;
    public GameObject opMenu;
    public string side = "down";
    public float combo = 0;
    public string lastTouched = "";
    public Text display;
    public AudioClip pickup;
    public AudioClip stretch;
    public AudioClip release;

    private AudioSource source;
    public Transform anchor;
    private Rigidbody2D rb;
    public SpringJoint2D spring;
    public bool OnTether = true;
    bool ClickedOn = false;
    public Ray mouseRay;
    public Ray anchorToBee;
    private Animator anim;
    private float maxstretchsqr;
    Vector3 prevVelocity;
    private Vector3 touchOrigin = -Vector2.one;

    void Awake()
    {
        spring = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anchor = spring.connectedBody.transform;
        source = GetComponent<AudioSource>();
    }

	void Start ()
    {
        LineSetUp();
        mouseRay = new Ray(anchor.transform.position, Vector3.zero);
        anchorToBee = new Ray(anchor.transform.position, Vector3.zero);
        maxstretchsqr = maxstretch * maxstretch;
        
	}
	
	void Update ()
    {

        rb.velocity = 10 * rb.velocity.normalized;
        source.volume = GameMonitor.Instance.volume;

        if(GameMonitor.Instance.score > 0 )
        {
            display.text = "Score: " + GameMonitor.Instance.score.ToString();
        }
 
        if(Input.touchCount > 0 && Input.touches[0].position.y > 50 && Input.touches[0].position.x < 650 && !opMenu.activeSelf)
        {

            Touch myTouch = Input.touches[0];

            if(myTouch.phase == TouchPhase.Began)
            {
                spring.enabled = false;
                ClickedOn = true;
                touchOrigin = myTouch.position;

                source.clip = stretch;
                source.Play();
            }

            if(myTouch.phase == TouchPhase.Ended)
            {
                spring.enabled = true;
                rb.isKinematic = false;
                ClickedOn = false;

            }
        }

        if(OnTether)
        {
            combo = 0;
        }

		if(ClickedOn)
        {
            Dragged();
            anim.SetBool("PulledBack", true);
        }

        if(spring != null)
        {
            if(!rb.isKinematic && prevVelocity.sqrMagnitude > rb.velocity.sqrMagnitude)
            {
                Destroy(spring);
                rb.velocity = prevVelocity;
                tether.enabled = true;

                anim.SetBool("PulledBack", false);
                anim.SetBool("Flying", true);
                OnTether = false;

                source.clip = release;
                source.Play();
            }

            if(!ClickedOn)
            {
                prevVelocity = rb.velocity;
            }

            renderUpdate();
        }
        else
        {
            left.enabled = false;
            right.enabled = false;
        }

	}

    private void OnMouseDown()
    {
        spring.enabled = false;
        ClickedOn = true;

        source.clip = stretch;
        source.Play();

    }

    private void OnMouseUp()
    {
        spring.enabled = true;
        rb.isKinematic = false;
        ClickedOn = false;

    }

    public void LineSetUp()
    {
        left.enabled = true;
        right.enabled = true;

        left.SetPosition(0, left.transform.position);
        right.SetPosition(0, right.transform.position);

        left.sortingLayerName = "Foreground";
        right.sortingLayerName = "Foreground";

        left.sortingOrder = 7;
        right.sortingOrder = 7;
    }

    void Dragged()
    {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
        Vector2 anchortomouse = mousePoint - anchor.transform.position;
        Vector2 touchmove = mousePoint - touchOrigin;

        if(anchortomouse.sqrMagnitude > maxstretchsqr)
        {
            mouseRay.direction = anchortomouse;
            mousePoint = mouseRay.GetPoint(maxstretch);
        }

        if(mousePoint.y > anchor.position.y - .25f && side == "down" )
        {
            mousePoint.y = anchor.position.y - .25f;
        }

        if(mousePoint.y < anchor.position.y + .25f && side == "up")
        {
            mousePoint.y = anchor.position.y + .25f;
        }

        if(mousePoint.x > 2.4)
        {
            mousePoint.x = 2.4f;
        }

        if(mousePoint.x < -2.4)
        {
            mousePoint.x = -2.4f;
        }

        mousePoint.z = 0;
        transform.position = mousePoint;
    }

    void renderUpdate()
    {
        Vector2 beetoanchor = transform.position - anchor.transform.position;
        anchorToBee.direction = beetoanchor;

        Vector3 holdpoint = anchorToBee.GetPoint(beetoanchor.magnitude);

        left.SetPosition(1, holdpoint);
        right.SetPosition(1, holdpoint);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lastTouched = collision.gameObject.name;
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "pickup" && !OnTether)
        {


            source.clip = pickup;
            source.Play();
        }
    }

    public void Die()
    {
        deathMenu.SetActive(true);
    }
}
