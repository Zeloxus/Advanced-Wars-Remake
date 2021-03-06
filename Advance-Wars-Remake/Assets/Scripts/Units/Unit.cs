﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Unit : MonoBehaviour {
    protected int team;
    protected int health;
    protected int level;
    protected int movement;
    protected int ammo;
    protected int cost;
    protected int fuel;
    protected int maxRange;
    protected int minRange;
    protected bool attack2;
    protected bool direct;
    protected bool hasActed;
  protected MovementType mvmtType;

	void Awake()
	{

	}

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setHealth(int x)
    {
        health = x;
    }
    public int getHealth()
    {
        return health;
    }
    public void setMovement(int x)
    {
        movement = x;
    }
    public int getMovement()
    {
        return movement;
    }
    public void setAmmo(int x)
    {
        ammo = x;
    }
    public int getAmmo()
    {
        return ammo;
    }
    public void setCost(int x)
    {
       cost = x;
    }
    public bool isDirect() {
      return direct;
    }
    public int getCost()
    {
        return cost;
    }
    public void setFuel(int x)
    {
        fuel = x;
    }
    public int getFuel()
    {
        return fuel;
    }
    public void setLevel(int x)
    {
        level = x;
    }
    public int getLevel()
    {
        return level;
    }
	public bool acted()
	{
		return hasActed;
	}

	public void setActed(bool x) {
		hasActed=x;
	}

	public Unit.MovementType getMovementType() {
		return mvmtType;
	}

	public void setMovementType(Unit.MovementType x) {
		mvmtType=x;
	}

  public int getMoves()
  {
      return Math.Min(movement,fuel);
  }

    public void move(List<Tile> path) {
      Vector3 offset;
      Vector3 startingPos;
      float scalar=1f;
      for(int i = 1; i<path.Count; i++) {
        offset = new Vector3(path[i].gameObject.transform.position.x-path[i-1].gameObject.transform.position.x,path[i].gameObject.transform.position.y-path[i-1].gameObject.transform.position.y,0f);
        startingPos = new Vector3(path[i-1].gameObject.transform.position.x,path[i-1].gameObject.transform.position.y,this.gameObject.transform.position.z);
        for(float j = 0; j<=1; j+=scalar) {
          this.gameObject.transform.position=startingPos+offset*j;
        }
      }
      path[0].setUnit(null);
      path[path.Count-1].setUnit(this);
    }



	public enum MovementType {
		Infantry, Mech, TireA, TireB, Tank,
		Air, Ship, Transport,
	}

}
