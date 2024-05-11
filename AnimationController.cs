using Graphic3D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic3D
{
    public class AnimationController
    {
        private Animation Animation;

        public AnimationController(Animation animation)
        {
            Animation = animation;
        }

        public void Update(float elapsedTime)
        {
            if (Animation == null) return;

            List<Models.Action> actionsToRemove = new List<Models.Action>();

            foreach (var action in Animation.Actions)
            {
                if (action.Update(elapsedTime))
                {
                    actionsToRemove.Add(action);
                }
            }

            
            foreach (var action in actionsToRemove)
            {
                Animation.RemoveAction(action);
            }

            
            if (Animation.Actions.Count == 0)
            {
                Animation = null;
            }
        }
    }
}
