using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class NavMesh2DGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public float tileResolution = 1f;
    public TileBase[] walkableTiles; // Array to specify walkable tiles
    public TileBase[] obstacleTiles; // Array to specify obstacle tiles
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 5f; // Speed at which enemies move

    private List<Vector3Int> path; // Path for the enemy to follow
    private int currentWaypointIndex = 0;

    private void Start()
    {
        GenerateNavMesh();
    }

    private void Update()
    {
        if (path != null && path.Count > 0)
        {
            Vector3 targetPosition = tilemap.GetCellCenterWorld(path[currentWaypointIndex]);

            // Move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the enemy has reached the current waypoint
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                currentWaypointIndex++;

                // Check if the enemy has reached the end of the path
                if (currentWaypointIndex >= path.Count)
                {
                    path = null; // Clear the path
                    currentWaypointIndex = 0;
                }
            }
        }
        else
        {
            // Calculate a new path to the player
            CalculatePathToPlayer();
        }
    }

    private void GenerateNavMesh()
    {
        // Your existing code for generating the navigation mesh
    }

    private void CalculatePathToPlayer()
    {
        // Convert enemy position and player position to grid coordinates
        Vector3Int startCell = tilemap.WorldToCell(transform.position);
        Vector3Int targetCell = tilemap.WorldToCell(player.position);

        // Perform A* pathfinding to find the shortest path
        path = AStarPathfinding(startCell, targetCell);
        currentWaypointIndex = 0;
    }

    private List<Vector3Int> AStarPathfinding(Vector3Int startCell, Vector3Int targetCell)
    {
        // Implementation of the A* algorithm goes here
        // You can find many examples and tutorials online for A* pathfinding in Unity
        // Make sure to take into account walkable and obstacle tiles
        // Return a list of grid coordinates representing the shortest path
        return new List<Vector3Int>();
    }

    private bool IsWalkable(TileBase tile)
    {
        // Check if the tile is in the walkable tiles array
        foreach (TileBase walkableTile in walkableTiles)
        {
            if (tile == walkableTile)
            {
                return true; // Tile is walkable
            }
        }

        // Check if the tile is in the obstacle tiles array
        foreach (TileBase obstacleTile in obstacleTiles)
        {
            if (tile == obstacleTile)
            {
                return false; // Tile is obstacle
            }
        }

        // If tile is not found in either array, assume it's walkable
        return true;
    }
}
