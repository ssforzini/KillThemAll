using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	private int life;
	private int defense;
	private float velocity;
    private int atack;
    private int selfScore;
	private NavMeshAgent agent;
	private Transform target;
	private RespawnManager rm;
    private GameObject pl;
    private Player player;

	void Awake(){
	}

	void Start(){
		rm = GameObject.Find("RespawnManager").GetComponent<RespawnManager> ();
        pl = GameObject.Find("Player");
        player = pl.GetComponent<Player>();
        target = pl.transform;
		agent = GetComponent<NavMeshAgent> ();
		agent.speed = velocity;
		agent.acceleration = velocity - 20f;
	}

	// Update is called once per frame
	void Update () {
		agent.SetDestination (target.position);
	}

	protected int getLife(){ return life; }
	protected void setLife(int _life){ life = _life; }

	protected float getVelocity(){ return velocity; }
	protected void setVelocity(float _velocity){ velocity = _velocity; }

	protected int getDefense(){ return defense; }
	protected void setDefense(int _defense){ defense = _defense; }

    protected int getSelfScore() { return selfScore; }
    protected void setSelfScore(int _selfScore) { selfScore = _selfScore; }

    public int getAtack() { return atack; }
    protected void setAtack(int _atack) { atack = _atack; }

    public void takeLife(int damage){
		life -= damage;
		if(life <= 0){
            player.addScore(selfScore);
			rm.enemyCountDecrease ();
			Destroy (gameObject);
		}
	}
}
