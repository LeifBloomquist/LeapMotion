using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Leap;

namespace LeapTestWithForm1
{
    class LeapStuff
    {
        private Controller controller = new Controller();

        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public float velX { get; private set; }
        public float velY { get; private set; }
        public float velZ { get; private set; }

        public float pinch { get; private set; }

        public LeapStuff()
        {
            //controller.EnableGesture(Gesture.GestureType.;
        }

        internal string GetInfo()
        {
            Frame frame = controller.Frame();

            string temp = "Connected: " + controller.IsConnected + "\n" +
                          "Frame ID: " + frame.Id + "\n" +
                          "Hands: " + frame.Hands.Count + "\n" +
                          "Fingers: " + frame.Fingers.Count + "\n\n";

            if (frame.Hands.Count == 1)
            {
                temp += "Hand #1 Position X:" + frame.Hands[0].PalmPosition.x + "\n";
                temp += "Hand #1 Position Y:" + frame.Hands[0].PalmPosition.y + "\n";
                temp += "Hand #1 Position Z:" + frame.Hands[0].PalmPosition.z + "\n\n";

                temp += "Hand #1 Velocity X:" + frame.Hands[0].PalmVelocity.x + "\n";
                temp += "Hand #1 Velocity Y:" + frame.Hands[0].PalmVelocity.y + "\n";
                temp += "Hand #1 Velocity Z:" + frame.Hands[0].PalmVelocity.z + "\n";

                temp += "Hand #1 Pinch:" + frame.Hands[0].PinchStrength + "\n";

                X = frame.Hands[0].PalmPosition.x;
                Y = frame.Hands[0].PalmPosition.y;
                Z = frame.Hands[0].PalmPosition.z;

                velX = frame.Hands[0].PalmVelocity.x;
                velY = frame.Hands[0].PalmVelocity.y;
                velZ = frame.Hands[0].PalmVelocity.z;

                pinch = frame.Hands[0].PinchStrength;
            }
            else
            {
                velX = 0;
                velY = 0;
                velZ = 0;
                pinch = 0;
            }

            return temp;
        }
    }
}
