using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Leap;

namespace LeapUniJoysticle
{
  class myHand
  {
    public float posX { get; private set; }
    public float posY { get; private set; }
    public float posZ { get; private set; }

    public float velX { get; private set; }
    public float velY { get; private set; }
    public float velZ { get; private set; }

    public float pinch { get; private set; }

    public bool isLeft { get;  private set; }
    public bool isRight { get; private set; }

    public string info { get;  private set; }

    public myHand()
    {
       
    }
    
    internal void Update(Hand hand)
    {
      info = "Hand (" + (isLeft ? "Left" : "Right") +")\n";  
      info += "Position X:" + hand.PalmPosition.x + "\n";
      info += "Position Y:" + hand.PalmPosition.y + "\n";
      info += "Position Z:" + hand.PalmPosition.z + "\n\n";

      info += "Velocity X:" + hand.PalmVelocity.x + "\n";
      info += "Velocity Y:" + hand.PalmVelocity.y + "\n";
      info += "Velocity Z:" + hand.PalmVelocity.z + "\n";

      info += "Pinch:" + hand.PinchStrength + "\n";

      posX = hand.PalmPosition.x;
      posY = hand.PalmPosition.y;
      posZ = hand.PalmPosition.z;

      velX = hand.PalmVelocity.x;
      velY = hand.PalmVelocity.y;
      velZ = hand.PalmVelocity.z;

      pinch = hand.PinchStrength;

      isLeft = hand.IsLeft;
      isRight = hand.IsRight;
    }       
  }


  class LeapStuff
  {
    public string info { get; private set; }
    public int numHands { get; private set; }

    private Controller controller = new Controller();
    public myHand[] hands = new myHand[2];

    public LeapStuff()
    {
      //controller.EnableGesture(Gesture.GestureType.;
      hands[0] = new myHand();
      hands[1] = new myHand();
    }

    internal void Update()
    {
      Frame frame = controller.Frame();

      info = "Connected: " + controller.IsConnected + "\n" +
              "Frame ID: " + frame.Id + "\n" +
              "Hands: " + frame.Hands.Count + "\n" +
              "Fingers: " + frame.Fingers.Count + "\n\n";

      numHands = frame.Hands.Count;

      switch (numHands)
      {
        case 0: return;

        case 1: 
          hands[0].Update(frame.Hands[0]);          // If only one hand, it is always Hand 0 
          break;

         case 2: 
          hands[0].Update(frame.Hands.Leftmost);   // If two hands, left is always 0 and right is always 1
          hands[1].Update(frame.Hands.Rightmost);  // (workaround for situation when right hand is seen first)
          break;

        default:   // Just in case...
          return;
      }
    }
  }
}
