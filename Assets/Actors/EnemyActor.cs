﻿using UnityEngine;
using System.Collections;

public class EnemyActor : Actor
{

	public override Action GetAction()
	{
		PlayerActor target = FindObjectOfType<PlayerActor>();
		AStar a = GetAStar(BoardPosition, target.BoardPosition);
		a.findPath();
		if (a.solution.Count > 1)
		{
			AStarNode2D node = (AStarNode2D) a.solution[1];
			Direction direction = Direction.GetDirection(node.x - BoardPosition.xPosition, node.y - BoardPosition.yPosition);
			return GetAttackAction(direction);
		}
		return GetComponent<RestAction>();
	}

	private AStar GetAStar(BoardPosition from, BoardPosition to)
	{
		return new AStar(new BoardManagerAStarCost(to), from.xPosition, from.yPosition, to.xPosition, to.yPosition);
    }

}
