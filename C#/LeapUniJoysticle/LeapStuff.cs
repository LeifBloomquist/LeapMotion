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

    public string info { get;  private set; }
    public int which { get; private set; }

    

    internal void Update(int which, Hand hand)
    {
      this.which = which;

      info = "Hand #" + which  + "\n";  
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
    }       
  }


  class LeapStuff
  {
    public string info { get; private set; }

    private Controller controller = new Controller();
    public myHand[] hands = null;

    public LeapStuff()
    {
      //controller.EnableGesture(Gesture.GestureType.;
    }

    internal void Update()
    {
      Frame frame = controller.Frame();

      frame.Hands.Rightmost

      info = "Connected: " + controller.IsConnected + "\n" +
              "Frame ID: " + frame.Id + "\n" +
              "Hands: " + frame.Hands.Count + "\n" +
              "Fingers: " + frame.Fingers.Count + "\n\n";

      hands = new myHand[frame.Hands.Count];

      for (int hand = 0; hand < frame.Hands.Count; hand++)
      {
        myHand current = new myHand();
        current.Update(hand, frame.Hands[hand]);
        hands[hand] = current;
      }
    }
  }
}
