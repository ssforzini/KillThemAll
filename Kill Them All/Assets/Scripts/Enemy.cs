using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	private int life;
	private int defense;
	private float velocity;
	private NavMeshAgent agent;
	private Transform target;

	void Awake(){
	}

	void Start(){
		target = GameObject.Find ("Player").transform;
		agent = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		agent.SetDestination (target.position);
	}

	protected int getLife(){ return life; }
	protected void setLife(int _life){ life = _life; }

	protected float getVelocity(){ return velocity; }
	protected void setVelocity(float _velocity){ velocity = _velocity; }

	protected float getDefense(){ return defense; }
	protected void setDefense(int _defense){ defense = _defense; }

	public void takeLife(int damage){
		life -= damage;
		if(life <= 0){
			Destroy (gameObject);
		}
	}
}
