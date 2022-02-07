using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    private List<SphereCollider> nodes;
    void Start()
    {
        GetComponentsInChildren<MeshFilter>().Select(x => x.mesh = null).ToList();
        nodes = GetComponentsInChildren<SphereCollider>().ToList();
    }

    public Vector3 GetPositionAtNode(int index)
    {
        if (index > 0 && index < nodes.Count)
        {
            return nodes[index].transform.position;
        }
        
        return Vector3.zero;
    }

    public int GetNodeCount() => nodes.Count;

}
