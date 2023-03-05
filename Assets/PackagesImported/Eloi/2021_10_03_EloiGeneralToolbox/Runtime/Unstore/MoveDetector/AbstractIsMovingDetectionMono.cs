using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public abstract class AbstractIsMovingDetectionMono :MonoBehaviour, IAbstractIsMovingDetection
    {
        public abstract void IsMoving(out bool moving);
        public bool IsMoving() { IsMoving(out bool m); return m; }
        public bool IsNotMoving() { return !IsMoving(); }
        public  void IsNotMoving(out bool moving)
        => moving = !IsMoving();

        
    }
}

public interface IAbstractIsMovingDetection
{
    public bool IsMoving();
    public void IsMoving(out bool moving);
    public bool IsNotMoving();
    public void IsNotMoving(out bool moving);
}
public interface IAbstractIsNotMovingTimeDetection
{
    public void GetNotMovingTimer(out float notMovingInSeconds);
}

public abstract class AbstractIsMovingDetection :  IAbstractIsMovingDetection
{
    public abstract void IsMoving(out bool moving);
    public bool IsMoving() { IsMoving(out bool m); return m; }
    public bool IsNotMoving() { return !IsMoving(); }
    public void IsNotMoving(out bool moving)
    => moving = !IsMoving();
}