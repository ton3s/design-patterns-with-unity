using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoupledCommand
{
    protected UnitController receiver;

    public CoupledCommand(UnitController receiver)
    {
        this.receiver = receiver;
    }

    public abstract void Execute();
    public abstract void Undo();
}

public class MoveCommand : CoupledCommand
{
    private Vector3 _startingPos;
    private Vector3 _endingPos;

    public MoveCommand(UnitController receiver, Direction direction) : base(receiver)
    {
        this._endingPos = Utilities.TargetPosition(direction, receiver.transform);
    }

    public override void Execute()
    {
        _startingPos = receiver.transform.position;
        receiver.Move(_endingPos);
    }

    public override void Undo()
    {
        receiver.Move(_startingPos);
    }
}