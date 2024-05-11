using OpenTK;
using System.Collections.Generic;

namespace Graphic3D.Models
{
    public class Action
    {
        public float Duration;
        public bool IsCompleted;
        public Vector3 PositionOffset { get; set; }
        public Vector3 RotationAngle { get; set; }
        public Vector3 ScaleFactor { get; set; }
        protected Action(float duration, Vector3 positionOffset = default, Vector3 rotationAngle = default, Vector3 scaleFactor = default)
        {
            Duration = duration;
            IsCompleted = false;
            PositionOffset = positionOffset;
            RotationAngle = rotationAngle;
            ScaleFactor = scaleFactor;
        }


        public bool Update(float elapsedTime)
        {
            float timeSinceStart = 0;
            if (timeSinceStart <= Duration)
            {
                Finish();
                return true; 
            }
            return false; 
        }

        public void ApplyTransformation(IObject targetObject)
        {
            if (targetObject != null)
            {
                targetObject.Translate(PositionOffset.X, PositionOffset.Y, PositionOffset.Z);
                targetObject.Rotate(RotationAngle.X, RotationAngle.Y, RotationAngle.Z);
                targetObject.Scale(ScaleFactor.X, ScaleFactor.Y, ScaleFactor.Z);
            }
        }

        protected virtual void Finish()
        {
            IsCompleted = true;
        }
    }
}
