using System.Collections.Generic;

namespace Graphic3D.Models
{
    public class Animation
    {
        public List<Action> Actions { get; set; } 

        public Animation(){
            Actions = new List<Action>();
        }

        public Animation(List<Action> actions)
        {
            Actions = actions;
        }
        public void AddAction(Action action)
        {
            Actions?.Add(action);
        }

        public void RemoveAction(Action action)
        {
            Actions?.Remove(action);
        }
    }
}
