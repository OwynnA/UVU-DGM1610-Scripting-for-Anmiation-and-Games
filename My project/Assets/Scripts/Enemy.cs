using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    //enemy stats
    public int curHp, maxHp, scoreTogive;
    //movement
    public float moveSpeed, attackRange, ypathOffset;
    //coordiantes for a path
    private List<Vector3> path;
    //enemy weapon
    //private Weapon weapon;
    //target to follow
    private GameObject target;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().gameObject;
        GameObject.Find("Player");
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
        curHp = maxHp;
    }

    void UpdatePath()
    {
        //calculate path to target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);
        path = navMeshPath.corners.ToList();
    }
    void ChaseTarget()
    {
        if(path.Count == 0)
        {
            return;
        }
        //move towards closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, ypathOffset, 0), moveSpeed * Time.deltaTime);
        if(transform.position == path[0] + new Vector3(0, ypathOffset, 0))
        {
            path.RemoveAt(0);
        }
    }
    public void TakeDamage(int damage)
    {
        curHp -= damage;
        if(curHp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        //look at the target
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;
        //calculate the distance between this enemy and the player
        float distance = Vector3.Distance(transform.position, target.transform.position);
        //if within attack range, shoot player
        if(distance <= attackRange)
        {
            player.TakeDamage(1);
        }
        else
        {
            ChaseTarget();
        }
    }
}
