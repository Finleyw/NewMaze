using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    //public Animator anim;

    public Transform[] points;

    //public int animNum=0;
    private NavMeshAgent nav;
    private int destPoint;
    // Start is called before the first frame update
    void Start()
    {
        
      nav = GetComponent<NavMeshAgent>();
      //anim = GetComponent<Animator>();
      //anim.SetInteger("Timehit",0);
      
  
    }

    void Update()
    {
        
        //anim.SetInteger("Timehit",animNum);
        /*if(animNum==8)
        {
        animNum=0;
        }*/
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
  	    GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
    /*void OnTriggerEnter(Collider other)
    {
        print(animNum);
        if(other.CompareTag("point"))
        {
            animNum++;
        }
    }*/

}
