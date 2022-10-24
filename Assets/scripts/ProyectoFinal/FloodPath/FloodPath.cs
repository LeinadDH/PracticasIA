using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodPath : MonoBehaviour
{
    private Queue<Block> _frontier;
    private Dictionary<Block, Block> _comeFrom;
    private Map _map;
    //private MapManager _manager;

    void Start()
    {
        _map = this.gameObject.GetComponent<Map>();
        _frontier = new Queue<Block>();
        _comeFrom = new Dictionary<Block, Block>();
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            getPath();
        }
    }

    public void getPath()
    {
        _frontier.Enqueue(_map.Start);
        _comeFrom[_map.Start] = null;
        while(_frontier.Count > 0)
        {
            Block current = _frontier.Dequeue();
            GetNeighbours(current);
        }
        printPath();
    }

    private void GetNeighbours(Block current)
    {
        if (checkLimits(current.X + 1, current.Y)) addNext(current, current.X + 1, current.Y);
        if (checkLimits(current.X - 1, current.Y)) addNext(current, current.X - 1, current.Y);
        if (checkLimits(current.X, current.Y + 1)) addNext(current, current.X, current.Y + 1);
        if (checkLimits(current.X, current.Y - 1)) addNext(current, current.X, current.Y - 1);
    }

    private bool checkLimits(int x, int y)
    {
        if(x >= 0 && x < _map.Height && y >= 0 && y < _map.Width)
        {
            return true;
        }
        return false;
    }

    private void addNext(Block current, int x, int y)
    {
        Block Next = _map.BlockMap[x, y];
        if (!_comeFrom.ContainsValue(Next))
        {
            _frontier.Enqueue(Next);
            _comeFrom[Next] = current;
        }
    }

    private void printPath()
    {
        Block previous;
        previous = _comeFrom[_map.Goal];
        while (previous != _map.Start)
        {
            previous = _comeFrom[previous];
            previous.Render.color = Color.red;
        }

        if(previous == _map.Start)
        {
            previous.Render.color = Color.blue;
        }
    }
}
