using System;
using UnityEngine;

namespace CommandPattern
{
    public abstract class Command
    {
        public GameObject target { get; set; }

        public Command(GameObject target)
        {
            this.target = target;
        }
        public abstract void Execute();
        public abstract void Undo();
        
    }

    public class MoveRight : Command
    {
        public MoveRight(GameObject target) : base(target)
        {
            this.target = target;
        }

        public override void Execute()
        {
            
           target.transform.position+=Vector3.right;
        }

        public override void Undo()
        {
            target.transform.position-=Vector3.right;
        }
        
       
    }
    
    public class MoveLeft : Command
    {
        public MoveLeft(GameObject target) : base(target)
        {
            this.target = target;
        }

        public override void Execute()
        {
            
            target.transform.position+=Vector3.left;
        }

        public override void Undo()
        {
            target.transform.position-=Vector3.left;
        }
        
       
    }
    public class MoveUp : Command
    {
        public MoveUp(GameObject target) : base(target)
        {
            this.target = target;
        }

        public override void Execute()
        {
            
            target.transform.position+=Vector3.up;
        }

        public override void Undo()
        {
            target.transform.position-=Vector3.up;
        }
    }
    public class MoveDown : Command
    {
        public MoveDown(GameObject target) : base(target)
        {
            this.target = target;
        }

        public override void Execute()
        {
            
            target.transform.position+=Vector3.down;
        }

        public override void Undo()
        {
            target.transform.position-=Vector3.down;
        }
    }
}