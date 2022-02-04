using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class State 
{
    public STATE Name;
    protected EVENT Stage;
    protected State NextState;
    protected GameObject Npc;
    public Transform Player;
    protected PlayerDetector Detector;

    public enum STATE
    {
        Idle, Patrol, Pursue, Attack, Rest,
    }

    public enum EVENT
    {
        Enter, Update, Exit
    }

    public State(Transform  player, GameObject npc, PlayerDetector detector)
    {
        Player = player;
        Stage = EVENT.Enter;
        Npc = npc;
        Detector = detector;
    }

    public virtual void Enter()
    {
        Stage = EVENT.Update;
    }
    public virtual void Update()
    {
        Stage = EVENT.Update;
    }
    public virtual void Exit()
    {
        Stage = EVENT.Exit;
    }
    
    public State Process()
    {
        switch (Stage)
        {
            case EVENT.Enter:
                Enter();
                break;
            case EVENT.Update:
                Update();
                break;
            case EVENT.Exit:
                Exit();
                return NextState;
        }
        return this;
    }
}


public class Idle : State
{
    public Idle( Transform player, GameObject npc, PlayerDetector detector)
        : base(player, npc, detector)
    {
        Name = STATE.Idle;
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    
    public override void Update()
    {
        base.Update();
       
    }
}

public class Patrol : State
{
    private int currentIndex = 0;
    private WaypointManager nodes;
    private List<SphereCollider> nodes2;
    private bool incDec = true;
    public Patrol( Transform player, GameObject npc, GameObject patrol, PlayerDetector detector)
        : base(player, npc, detector)
    {
        Name = STATE.Patrol;
        nodes = patrol.GetComponent<WaypointManager>();
        nodes2 = patrol.GetComponentsInChildren<SphereCollider>().ToList();

    }
    
    public override void Update()
    {
        base.Update();
        
        if (Detector.PlayerSpotted)
        {
            NextState = new Attack(Player, Npc, Detector);
            Stage = EVENT.Exit;
        }

        //    CheckForDistance();


        //    Npc.transform.position += Npc.transform.right * 1.0f * Time.deltaTime;


    //    RotateEnemy();


    }

    private void RotateEnemy()
    {
        var dot = Vector3.Dot(Npc.transform.forward, nodes2[currentIndex].transform.forward);
        if (dot < 0)
        {
            Npc.transform.Rotate(Vector3.up, 180);
        }
    }
    
    private void CheckForDistance()
    {
        if (Vector3.Distance(Npc.transform.position, nodes.GetPositionAtNode(currentIndex)) < 0.2f)
        {
            if (incDec)
            {
                if (currentIndex >= nodes.GetNodeCount())
                {
                    currentIndex--;
                    incDec = false;
                }
                else
                {
                    currentIndex++;
                }
            }
            else
            {
                if (currentIndex < 0)
                {
                    currentIndex++;
                    incDec = true;
                }
                else
                {
                    currentIndex--;
                }
            }
        }
    }
}

public class Pursue : State
{
    public Pursue( Transform player, GameObject npc, PlayerDetector detector)
        : base(player, npc, detector)
    {
        Name = STATE.Pursue;
    }

    public override void Update()
    {
        base.Update();
        Stage = EVENT.Update;
    }
}

public class Attack : State
{
    private Shoot_Enemy shooter;
    
    public Attack( Transform player, GameObject npc, PlayerDetector detector)
        : base(player, npc,detector)
    {
        Name = STATE.Patrol;
        shooter = Npc.GetComponentInChildren<Shoot_Enemy>();
    }

    public override void Update()
    {
        base.Update();

        if (Detector.PlayerSpotted)
        {
            shooter.Attack();
        }
    }
}
