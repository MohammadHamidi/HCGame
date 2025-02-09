using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class CommandExecutor : MonoBehaviour
    {
        public List<Command> commands = new List<Command>();
        public GameObject target;
        private void Start()
        {
        
        }



        public void AddMoveRight()
        {
            commands.Add(new MoveRight(target));
        }
        public void AddMoveLeft()
        {
            commands.Add(new MoveLeft(target));
        }
        public void AddMoveUp()
        {
            commands.Add(new MoveUp(target));
        }
        public void AddMoveDown()
        {
            commands.Add(new MoveDown(target));
        }
        public void Execute()
        {
            StartCoroutine(ExecuteCoroutine());
        }

        private IEnumerator ExecuteCoroutine()
        {
            foreach (var command in commands)
            {
                command.Execute();
                yield return new WaitForSeconds(0.8f);
            }    
        }
        private IEnumerator UndoCoroutine()
        {
            for (var i=commands.Count-1;i>=0;i--)
            {
                commands[i].Undo();
                yield return new WaitForSeconds(0.8f);
            }    
        }
        public void Undo()
        {
            StartCoroutine(UndoCoroutine());
        }

    }
}