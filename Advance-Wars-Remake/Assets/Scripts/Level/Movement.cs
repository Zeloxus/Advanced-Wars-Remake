﻿using System.Collections;
using System.Collections.Generic;
using System;
using Priority_Queue;

public class index : GenericPriorityQueueNode<int> {
public int i;

	public index(int id) {
		i=id;
	}
	/* Dont' remember why I added this in the first place, but I'll leave it for now
	public static bool operator == (index b, index c) {
     return  b==c;
  }

	//;
	public static bool operator != (index b, index c) {
     return  b!=c;
  }
	*/
}

//This struct is used in shortestPath()
struct dijkstraNode{
		public bool found;
		public int dist;
		public int previous; //index of previous node
}


public class Movement{
	//class is static, will be used by game.cs
	private static List<Tile> moveList;
	private static Unit currentUnit;
	private static Path currentPath;
	private static Dictionary<Tile.TileType, int> movementCosts;

	public static void updatePath(Tile t, Map m) {
			if(moveList.Contains(t)) {
				bool inside=false;
				for(int i = 0; i<currentPath.length(); ++i)
					if(t==currentPath.at(i).getValue()) {
						currentPath=currentPath.getUpTo(i);
						inside=true;
					}
				if(!inside) {
					if(UserMath.About(m.distance(t,currentPath.at(currentPath.length()-1).getValue()),1)&&currentPath.getCost()+movementCosts[t.getType()]<=currentUnit.getMoves())
						currentPath.insertTail(t,movementCosts[t.getType()]);
					else {
					/*
						try generating shortest path using a variation of Dijkstra's algorithm
						if such a path doesn't exist, try it for the 2nd most recent
							(base will work since t is in movelist)
							Notes: break as soon as the node is found (1 pair),
							we can't really afford the full runtime (I think)
					*/
						Path shortPath;
						Path tempPath;
						for(int i = currentPath.length()-1; i>=0 ;--i) {
							//Note that since t is in moveList, that currentPath will be set at some point
							//If runtime is too slow, we can just run it on the starting node
							tempPath=shortestPath(currentPath.at(i).getValue(),t,m);
								if(tempPath!=null) {
									shortPath=currentPath.getUpTo(i).merge(tempPath);
									shortPath.removeCycles();
									// shortest path doesn't contain at(i)
									if(shortPath.getCost()<=currentUnit.getMoves()) {
										currentPath=shortPath;
										i=-1; //equivalent to break;
									}
								}
								else
									UI.print("Shortest Path Error! Please let Kenneth know if you see this");
						}
					}
				}

				List<int> toHighlight= new List<int>();
				foreach(Tile x in currentPath.getTiles()) {
					toHighlight.Add(moveList.IndexOf(x));
				}
				UI.highlightPath(toHighlight);
			}
	}

	private static Path shortestPath(Tile a, Tile b, Map m) {
		//If runtime is too high, use a hash table to store indices
		dijkstraNode[] nodes= new dijkstraNode[moveList.Count];
		index[] indices = new index[moveList.Count];
		for(int i = 0; i<moveList.Count; ++i) {
			nodes[i].found=false;
			nodes[i].dist=999;
			nodes[i].previous=-1;
			indices[i]=new index(i);
		}
		int start = moveList.IndexOf(a);
		int end = moveList.IndexOf(b);
		//<index,weight>
		GenericPriorityQueue<index,int> queue = new GenericPriorityQueue<index,int>(moveList.Count);
		nodes[start].dist=0;
		for(int i = 0; i<moveList.Count;i++) {
			if(i==start)
				queue.Enqueue(indices[i],0);
			else
				queue.Enqueue(indices[i],999);
		}

		index tempi;
		int x,y,r;

		while(queue.Count!=0) {
		//for(int k = 0; k<queue.Count; k++) {
			tempi=queue.Dequeue();
			nodes[tempi.i].found=true;
			if(tempi.i==end)
				break;
			x=moveList[tempi.i].getX();
			y=moveList[tempi.i].getY();
			//ideally we shorten this; maybe do some sin/cos stuff in UserMath
			//east
			r=moveList.IndexOf(m.findTile(x+1,y));
			if(x<m.getMapWidth()-1&&r!=-1&&!nodes[r].found) {
				if(!nodes[r].found&&nodes[r].dist>movementCosts[moveList[r].getType()]+nodes[tempi.i].dist) {
					nodes[r].dist=movementCosts[moveList[r].getType()]+nodes[tempi.i].dist;
					nodes[r].previous=tempi.i;
					queue.UpdatePriority(indices[r],nodes[r].dist);
				}
			}
			//north
			r=moveList.IndexOf(m.findTile(x,y+1));
			if(r!=-1&&!nodes[r].found&&y<m.getMapHeight()-1) {
				if(!nodes[r].found&&nodes[r].dist>movementCosts[moveList[r].getType()]+nodes[tempi.i].dist) {
					nodes[r].dist=movementCosts[moveList[r].getType()]+nodes[tempi.i].dist;
					nodes[r].previous=tempi.i;
					queue.UpdatePriority(indices[r],nodes[r].dist);
				}
			}
			//west
			r=moveList.IndexOf(m.findTile(x-1,y));
			if(r!=-1&&!nodes[r].found&&x>0) {
				if(!nodes[r].found&&nodes[r].dist>movementCosts[moveList[r].getType()]+nodes[tempi.i].dist) {
					nodes[r].dist=movementCosts[moveList[r].getType()]+nodes[tempi.i].dist;
					nodes[r].previous=tempi.i;
					queue.UpdatePriority(indices[r],nodes[r].dist);
				}
			}
			//south
			r=moveList.IndexOf(m.findTile(x,y-1));
			if(r!=-1&&!nodes[r].found&&y>0) {
				if(!nodes[r].found&&nodes[r].dist>movementCosts[moveList[r].getType()]+nodes[tempi.i].dist) {
					nodes[r].dist=movementCosts[moveList[r].getType()]+nodes[tempi.i].dist;
					nodes[r].previous=tempi.i;
					queue.UpdatePriority(indices[r],nodes[r].dist);
				}
			}
		}//end of while-loop
		Path ret = new Path();
		if(nodes[end].previous==-1)
			return null;
		for(int i=end; i!=start;) {
			ret.insertHead(moveList[i],movementCosts[moveList[i].getType()]);
			i=nodes[i].previous;
		}
		//To impelement; high runtimes might result in reworking this algorithm
		return ret;
	}

	public static void addPossibleMoves(Tile currentTile, Unit u, Map currentMap, Team current) {
		setCurrentMovement(u);
		currentUnit = u;
		moveList= new List<Tile>();
		addPossibleMoves(currentTile, u.getMoves(), currentMap, current);
		UI.highlightMoves(moveList);
		currentPath = new Path();
		currentPath.insertHead(currentTile,0);
	}

	private static void addPossibleMoves(Tile currentTile, int moves, Map currentMap, Team current) {
		if(!moveList.Contains(currentTile))
		moveList.Add(currentTile);
		if(currentTile.getX()>0&&movementCosts[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]<=moves&&movementCosts[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()]>0) //check if leftmost
			if(!currentMap.findTile(currentTile.getX()-1,currentTile.getY()).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX()-1,currentTile.getY()),moves-movementCosts[currentMap.findTile(currentTile.getX()-1,currentTile.getY()).getType()], currentMap, current);
		if(currentTile.getX()<currentMap.getMapWidth()-1&&movementCosts[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()]<=moves&&movementCosts[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()]>0) //check rightmost
			if(currentMap.findTile(currentTile.getX()+1,currentTile.getY()).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX()+1,currentTile.getY()),moves-movementCosts[currentMap.findTile(currentTile.getX()+1,currentTile.getY()).getType()], currentMap, current);
		if(currentTile.getY()>0&&movementCosts[currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getType()]<=moves&&movementCosts[currentMap.findTile(currentTile.getY(),currentTile.getY()-1).getType()]>0) //check if bottom
			if(currentMap.findTile(currentTile.getX(),currentTile.getY()-1).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX(),currentTile.getY()-1),moves-movementCosts[currentMap.findTile(currentTile.getX(),currentTile.getY()-1).getType()], currentMap, current);
		if(currentTile.getY()<currentMap.getMapHeight()-1&&movementCosts[currentMap.findTile(currentTile.getX(),currentTile.getY()+1).getType()]<=moves&&movementCosts[currentMap.findTile(currentTile.getX(),currentTile.getY()+1).getType()]>0) //check top
			if(currentMap.findTile(currentTile.getX(),currentTile.getY()+1).containsUnit()||!current.contains(currentMap.findTile(currentTile.getX(),currentTile.getY()+1).getUnit()))
				addPossibleMoves(currentMap.findTile(currentTile.getX(),currentTile.getY()+1),moves-movementCosts[currentMap.findTile(currentTile.getX(),currentTile.getY()+1).getType()], currentMap, current);
	}

	public static void moveUnit() {
			List<Tile> pathToFollow = currentPath.getTiles();
			dehighlight();
			currentUnit.move(pathToFollow);
			currentUnit.setFuel(currentUnit.getFuel()-currentPath.getCost());
	}

	public static void dehighlight() {
		moveList.Clear();
		UI.dehighlightMoves();
	}

	public static Tile getEndTile() {
		return currentPath.getTiles()[currentPath.length()-1];
	}

	private static void setCurrentMovement(Unit u) {
		movementCosts=new Dictionary<Tile.TileType, int>();
		switch(u.getMovementType()) {
			case(Unit.MovementType.Infantry):
				movementCosts.Add(Tile.TileType.HQ,1);
				movementCosts.Add(Tile.TileType.City,1);
				movementCosts.Add(Tile.TileType.Factory,1);
				movementCosts.Add(Tile.TileType.Airport,1);
				movementCosts.Add(Tile.TileType.Seaport,1);
				movementCosts.Add(Tile.TileType.TempAir,1);
				movementCosts.Add(Tile.TileType.TempSea,1);
				movementCosts.Add(Tile.TileType.Plain,1);
				movementCosts.Add(Tile.TileType.River,2);
				movementCosts.Add(Tile.TileType.Road,1);
				movementCosts.Add(Tile.TileType.Wood,1);
				movementCosts.Add(Tile.TileType.Wasteland,1);
				movementCosts.Add(Tile.TileType.Ruins,1);
				movementCosts.Add(Tile.TileType.Mountain,2);
				movementCosts.Add(Tile.TileType.Beach,1);
				movementCosts.Add(Tile.TileType.Bridge,1);
				movementCosts.Add(Tile.TileType.Sea,0);
				movementCosts.Add(Tile.TileType.Reef,0);
				movementCosts.Add(Tile.TileType.RoughSea,0);
				movementCosts.Add(Tile.TileType.Mist,0);
				break;


			case(Unit.MovementType.Mech):
				movementCosts.Add(Tile.TileType.HQ,1);
				movementCosts.Add(Tile.TileType.City,1);
				movementCosts.Add(Tile.TileType.Factory,1);
				movementCosts.Add(Tile.TileType.Airport,1);
				movementCosts.Add(Tile.TileType.Seaport,1);
				movementCosts.Add(Tile.TileType.TempAir,1);
				movementCosts.Add(Tile.TileType.TempSea,1);
				movementCosts.Add(Tile.TileType.Plain,1);
				movementCosts.Add(Tile.TileType.River,1);
				movementCosts.Add(Tile.TileType.Road,1);
				movementCosts.Add(Tile.TileType.Wood,1);
				movementCosts.Add(Tile.TileType.Wasteland,1);
				movementCosts.Add(Tile.TileType.Ruins,1);
				movementCosts.Add(Tile.TileType.Mountain,1);
				movementCosts.Add(Tile.TileType.Beach,1);
				movementCosts.Add(Tile.TileType.Bridge,1);
				movementCosts.Add(Tile.TileType.Sea,0);
				movementCosts.Add(Tile.TileType.Reef,0);
				movementCosts.Add(Tile.TileType.RoughSea,0);
				movementCosts.Add(Tile.TileType.Mist,0);
				break;

			case(Unit.MovementType.TireA):
				movementCosts.Add(Tile.TileType.HQ,1);
				movementCosts.Add(Tile.TileType.City,1);
				movementCosts.Add(Tile.TileType.Factory,1);
				movementCosts.Add(Tile.TileType.Airport,1);
				movementCosts.Add(Tile.TileType.Seaport,1);
				movementCosts.Add(Tile.TileType.TempAir,1);
				movementCosts.Add(Tile.TileType.TempSea,1);
				movementCosts.Add(Tile.TileType.Plain,2);
				movementCosts.Add(Tile.TileType.River,0);
				movementCosts.Add(Tile.TileType.Road,1);
				movementCosts.Add(Tile.TileType.Wood,3);
				movementCosts.Add(Tile.TileType.Wasteland,3);
				movementCosts.Add(Tile.TileType.Ruins,2);
				movementCosts.Add(Tile.TileType.Mountain,0);
				movementCosts.Add(Tile.TileType.Beach,2);
				movementCosts.Add(Tile.TileType.Bridge,1);
				movementCosts.Add(Tile.TileType.Sea,0);
				movementCosts.Add(Tile.TileType.Reef,0);
				movementCosts.Add(Tile.TileType.RoughSea,0);
				movementCosts.Add(Tile.TileType.Mist,0);
				break;

			case(Unit.MovementType.TireB):
				movementCosts.Add(Tile.TileType.HQ,1);
				movementCosts.Add(Tile.TileType.City,1);
				movementCosts.Add(Tile.TileType.Factory,1);
				movementCosts.Add(Tile.TileType.Airport,1);
				movementCosts.Add(Tile.TileType.Seaport,1);
				movementCosts.Add(Tile.TileType.TempAir,1);
				movementCosts.Add(Tile.TileType.TempSea,1);
				movementCosts.Add(Tile.TileType.Plain,1);
				movementCosts.Add(Tile.TileType.River,0);
				movementCosts.Add(Tile.TileType.Road,1);
				movementCosts.Add(Tile.TileType.Wood,3);
				movementCosts.Add(Tile.TileType.Wasteland,3);
				movementCosts.Add(Tile.TileType.Ruins,1);
				movementCosts.Add(Tile.TileType.Mountain,0);
				movementCosts.Add(Tile.TileType.Beach,2);
				movementCosts.Add(Tile.TileType.Bridge,1);
				movementCosts.Add(Tile.TileType.Sea,0);
				movementCosts.Add(Tile.TileType.Reef,0);
				movementCosts.Add(Tile.TileType.RoughSea,0);
				movementCosts.Add(Tile.TileType.Mist,0);
				break;

			case(Unit.MovementType.Tank):
				movementCosts.Add(Tile.TileType.HQ,1);
				movementCosts.Add(Tile.TileType.City,1);
				movementCosts.Add(Tile.TileType.Factory,1);
				movementCosts.Add(Tile.TileType.Airport,1);
				movementCosts.Add(Tile.TileType.Seaport,1);
				movementCosts.Add(Tile.TileType.TempAir,1);
				movementCosts.Add(Tile.TileType.TempSea,1);
				movementCosts.Add(Tile.TileType.Plain,1);
				movementCosts.Add(Tile.TileType.River,0);
				movementCosts.Add(Tile.TileType.Road,1);
				movementCosts.Add(Tile.TileType.Wood,2);
				movementCosts.Add(Tile.TileType.Wasteland,2);
				movementCosts.Add(Tile.TileType.Ruins,1);
				movementCosts.Add(Tile.TileType.Mountain,0);
				movementCosts.Add(Tile.TileType.Beach,1);
				movementCosts.Add(Tile.TileType.Bridge,1);
				movementCosts.Add(Tile.TileType.Sea,0);
				movementCosts.Add(Tile.TileType.Reef,0);
				movementCosts.Add(Tile.TileType.RoughSea,0);
				movementCosts.Add(Tile.TileType.Mist,0);
				break;

			case(Unit.MovementType.Air):
				movementCosts.Add(Tile.TileType.HQ,1);
				movementCosts.Add(Tile.TileType.City,1);
				movementCosts.Add(Tile.TileType.Factory,1);
				movementCosts.Add(Tile.TileType.Airport,1);
				movementCosts.Add(Tile.TileType.Seaport,1);
				movementCosts.Add(Tile.TileType.TempAir,1);
				movementCosts.Add(Tile.TileType.TempSea,1);
				movementCosts.Add(Tile.TileType.Plain,1);
				movementCosts.Add(Tile.TileType.River,1);
				movementCosts.Add(Tile.TileType.Road,1);
				movementCosts.Add(Tile.TileType.Wood,1);
				movementCosts.Add(Tile.TileType.Wasteland,1);
				movementCosts.Add(Tile.TileType.Ruins,1);
				movementCosts.Add(Tile.TileType.Mountain,1);
				movementCosts.Add(Tile.TileType.Beach,1);
				movementCosts.Add(Tile.TileType.Bridge,1);
				movementCosts.Add(Tile.TileType.Sea,1);
				movementCosts.Add(Tile.TileType.Reef,1);
				movementCosts.Add(Tile.TileType.RoughSea,1);
				movementCosts.Add(Tile.TileType.Mist,1);
				break;

			case(Unit.MovementType.Ship):
				movementCosts.Add(Tile.TileType.HQ,0);
				movementCosts.Add(Tile.TileType.City,0);
				movementCosts.Add(Tile.TileType.Factory,0);
				movementCosts.Add(Tile.TileType.Airport,0);
				movementCosts.Add(Tile.TileType.Seaport,1);
				movementCosts.Add(Tile.TileType.TempAir,0);
				movementCosts.Add(Tile.TileType.TempSea,1);
				movementCosts.Add(Tile.TileType.Plain,0);
				movementCosts.Add(Tile.TileType.River,0);
				movementCosts.Add(Tile.TileType.Road,0);
				movementCosts.Add(Tile.TileType.Wood,0);
				movementCosts.Add(Tile.TileType.Wasteland,0);
				movementCosts.Add(Tile.TileType.Ruins,0);
				movementCosts.Add(Tile.TileType.Mountain,0);
				movementCosts.Add(Tile.TileType.Beach,0);
				movementCosts.Add(Tile.TileType.Bridge,1);
				movementCosts.Add(Tile.TileType.Sea,1);
				movementCosts.Add(Tile.TileType.Reef,2);
				movementCosts.Add(Tile.TileType.RoughSea,2);
				movementCosts.Add(Tile.TileType.Mist,1);
				break;

			case(Unit.MovementType.Transport):
				movementCosts.Add(Tile.TileType.HQ,0);
				movementCosts.Add(Tile.TileType.City,0);
				movementCosts.Add(Tile.TileType.Factory,0);
				movementCosts.Add(Tile.TileType.Airport,0);
				movementCosts.Add(Tile.TileType.Seaport,1);
				movementCosts.Add(Tile.TileType.TempAir,0);
				movementCosts.Add(Tile.TileType.TempSea,1);
				movementCosts.Add(Tile.TileType.Plain,0);
				movementCosts.Add(Tile.TileType.River,0);
				movementCosts.Add(Tile.TileType.Road,0);
				movementCosts.Add(Tile.TileType.Wood,0);
				movementCosts.Add(Tile.TileType.Wasteland,0);
				movementCosts.Add(Tile.TileType.Ruins,0);
				movementCosts.Add(Tile.TileType.Mountain,0);
				movementCosts.Add(Tile.TileType.Beach,1);
				movementCosts.Add(Tile.TileType.Bridge,1);
				movementCosts.Add(Tile.TileType.Sea,1);
				movementCosts.Add(Tile.TileType.Reef,2);
				movementCosts.Add(Tile.TileType.RoughSea,2);
				movementCosts.Add(Tile.TileType.Mist,1);
				break;
		}
	}
}
