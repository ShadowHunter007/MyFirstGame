using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 1f;
    public Transform player;
    bool enteredRadius = false;
    bool playerIsIn = false;

    void Update ()
    {
        float distance = Vector2.Distance(player.position, transform.position);

        if (distance <= radius)
        {
            enteredRadius = true;
        }
        else if(distance >= radius && playerIsIn)
        {
            Debug.Log(transform.name + ": Player has left!");
            playerIsIn = false;
            enteredRadius = false;
        }

        if (enteredRadius && !playerIsIn)
        {
            Debug.Log(transform.name + ": Player has entered!");
            playerIsIn = true;
            Interact();
        }
	}

    public virtual void Interact()
    {
        //this method is meant to be overwritten
        Debug.Log("Interacting with" + transform.name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
