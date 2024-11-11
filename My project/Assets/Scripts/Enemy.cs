using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    private CharacterController enController;
    private Animator enAnim;
    
    [Header("Info")]
    public float enSpeed = 6.0f;
	public float enTurnSpeed = 300.0f;
    public float gravity = 20.0f;

    /*[Header("Pathing")]
    public List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    private bool moving = true;
    private bool foMoving = true;*/

    [Header("Roboto")]
    public GameObject playerBody;
    public LayerMask playerLayer;
    public float visionRadius;
    public bool playerInvision;
    public Vector3 spawnPoint;
    void Start () {		
        enController = GetComponent <CharacterController>();	
        enAnim = gameObject.GetComponentInChildren<Animator>();
        playerBody = GameObject.Find("Player");
        spawnPoint = transform.position;
    }

    void Update(){
        playerInvision = Physics.CheckSphere(transform.position,visionRadius,playerLayer);
        
        if(!playerInvision){
            Idle();
        }else{
            Chase();
        }
    }

    /*private void Walk(){
        if(waypoints.Count == 0) return;

        Transform targetWaypont = waypoints[currentWaypointIndex];
        Vector3 directionToWaypoint = (targetWaypont.position - transform.position).normalized;
        Vector3 moveVector = directionToWaypoint * enSpeed * Time.deltaTime;

        enController.Move(moveVector);

        Vector3 lookDirection = new Vector3(directionToWaypoint.x,0,directionToWaypoint.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime * enTurnSpeed);

        enAnim.SetInteger ("AnimationPar", 1);

        if(Vector3.Distance(transform.position, targetWaypont.position) < 0.1f){
            if(foMoving){
                currentWaypointIndex++;
                if(currentWaypointIndex >= waypoints.Count){
                    currentWaypointIndex = waypoints.Count - 1;
                    foMoving = false;
                }
            }else{
                currentWaypointIndex--;
                if(currentWaypointIndex < 0){
                    currentWaypointIndex = 0;
                    foMoving = true;
                }
            }
        }

    }*/

    void Idle(){
        float disV = 0;
        disV = Vector3.Distance(spawnPoint,transform.position);

        if(disV >= 1){
            Vector3 directionToSpawn = (spawnPoint - transform.position).normalized;
            Vector3 moveVector = directionToSpawn * enSpeed * Time.deltaTime;
            enController.Move(moveVector);
            Vector3 lookDirection = new Vector3(directionToSpawn.x,0,directionToSpawn.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime * enTurnSpeed);
            enAnim.SetInteger ("AnimationPar", 1);
        }else{
            enAnim.SetInteger ("AnimationPar", 0);
        }
    }

    void Chase(){
        Vector3 directionToPlayer = (playerBody.transform.position - transform.position).normalized;
        Vector3 moveVector = directionToPlayer * enSpeed * Time.deltaTime;

        enController.Move(moveVector);

        Vector3 lookDirection = new Vector3(directionToPlayer.x, 0, directionToPlayer.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), Time.deltaTime * enTurnSpeed);

        enAnim.SetInteger ("AnimationPar", 1);
    }
}
