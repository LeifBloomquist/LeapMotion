using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;
using System.Threading;

namespace LeapMIDI
{
  public class MIDIHandler
  {
    // Singleton
    private MIDIHandler() {}
    static MIDIHandler() {}
    private static MIDIHandler _instance = new MIDIHandler();
    public static MIDIHandler Instance { get { return _instance; } }

    private OutputDevice outDevice = null;
    private SynchronizationContext context;
    private Boolean connected = false;

    public Boolean InitializeMIDI()
    {
      connected = false;

      int devices = OutputDevice.DeviceCount;

      if (devices == 0)
      {
        MessageBox.Show("No MIDI output devices available.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      else
      {
        try
        {
          context = SynchronizationContext.Current;

          for (int i = 0; i < devices; i++)
          {
            MidiOutCaps caps = OutputDevice.GetDeviceCapabilities(i);
            if (caps.name == "Generator")
            {
              ConnectMIDI(i);
              return true;
            }
          }

          MessageBox.Show("Generator device not found!", "MIDI Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
          return false;
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "MIDI Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
          return false;
        }
      }
    }

    private void ConnectMIDI(int selected)
    {
      if (outDevice != null)
      {
        outDevice.Close();
      }

      outDevice = new OutputDevice(selected);
      outDevice.Reset();
      connected = true;
    }

    public void SendMIDI(ChannelCommand command, int channel, int data1, int data2)
    {
      if (!connected) return;

      ChannelMessage cm = new ChannelMessage(command, channel, data1, data2);
      outDevice.Send(cm);
    }

    public void SendMMCCommand(byte command)
    {
      byte[] MMC = new byte[6];

      MMC[0] = 0xF0;
      MMC[1] = 0x7F;
      MMC[2] = 0x7F;
      MMC[3] = 0x06;
      MMC[4] = command;
      MMC[5] = 0xF7;

      SysExMessage sysex = new SysExMessage(MMC);
      outDevice.Send(sysex);
    }

    public int ValueToMIDI(float val, float low, float high)
    {
       // Bound
      if (val > high) val=high;
      if (val < low) val=low;
       
      // Change zero-offset
      val = val-low;

      // Scale between 0.0 and 1.0    (0.5 would be halfway)
      float temp = (float)val / ((float)high - (float)low);

      // Map to a 7-bit value

      int cc = (int)(temp * 127f);

      if (cc < 0) cc = 0;
      if (cc > 127) cc = 127;

      return cc;
    }   
  }
}

