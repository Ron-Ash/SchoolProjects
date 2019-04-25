﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGenerator : MonoBehaviour {

	public int width;
	public int height;

	public string seed;
	public bool useRandomSeed;

	[Range(0, 100)]
	public int randomFillPercent;

	int[,] map;

	void Start()
	{
		GenerateMap();
	}


	void GenerateMap()
	{
		map = new int[width, height];
		RandomFillMap();

		for(int i = 0; i<5; i++)
		{
			SmoothMap();
		}
	}

	void RandomFillMap()
	{
		if(useRandomSeed)
		{
			seed = Time.time.ToString();
		}

		System.Random pseudoRandom = new System.Random(seed.GetHashCode());
		for(int x = 0; x  < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				if(x == 0 || x == width-1 || y == 0 || y == height-1)
				{
					map[x,y] = 1;
				}
				else
				{
					map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent)? 1: 0;	
				}
				
			}
		}
	}
	void SmoothMap()
	{
		for(int x = 0; x  < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				int neigbourWallTiles = GetSuroundingWallCount(x,y);

				if(neigbourWallTiles>4)
				{
					map[x,y] = 1;
				}
				else if(neigbourWallTiles<4)
				{
					map[x,y] = 0;
				}
			}
		}
	}

	int GetSuroundingWallCount(int gridX, int gridY)
	{
		int wallCount = 0;
		for(int neighbourX = gridX-1; neighbourX <= gridX+1; neighbourX++)
		{
			for(int neighbourY = gridY-1; neighbourY <= gridY+1; neighbourY++)
			{
				if(neighbourX >=0 && neighbourX<width && neighbourY >= 0 && neighbourY<height)
				{
					if(neighbourX != gridX || neighbourY != gridY)
					{
						wallCount += map[neighbourX,neighbourY];
					}
				}
				else
				{
					wallCount++;
				}
			}
		}
		return wallCount;
	}

	void OnDrawGizmos()
	{
		if(map != null)
		{
			for(int x = 0; x  < width; x++)
			{
				for(int y = 0; y < height; y++)
				{
					Gizmos.color = (map[x,y]== 1)?Color.black: Color.white;
					Vector3 pos = new Vector3(-width/2 + x + 0.5f, -height/2 + y + 0.5f, 25);
					Gizmos.DrawCube(pos,Vector3.one);
				}
			}
		}
	}


}