using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public STATE Name;
    protected EVENT Stage;
    protected State NextState;
    protected GameObject Npc;
    public Transform Player;

    public enum STATE
    {
        Idle, Patrol, Pursue, Attack, Rest,
    }

    public enum EVENT
    {
        Enter, Update, Exit
    }

    public State(Transform  player, GameObject npc)
    {
        Player = player;
        Stage = EVENT.Enter;
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
    public Idle( Transform player, GameObject npc)
        : base(player, npc)
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
        Stage = EVENT.Update;
    }
}

public class Patrol : State
{
    public Patrol( Transform player, GameObject npc)
        : base(player, npc)
    {
        Name = STATE.Patrol;
    }
    

    
    public override void Update()
    {
        base.Update();
        Stage = EVENT.Update;
    }
}

public class Pursue : State
{
    public Pursue( Transform player, GameObject npc)
        : base(player, npc)
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
    public Attack( Transform player, GameObject npc)
        : base(player, npc)
    {
        Name = STATE.Patrol;
    }

    public override void Update()
    {
        base.Update();
        Stage = EVENT.Update;
    }
}
