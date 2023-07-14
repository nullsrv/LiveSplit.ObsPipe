using LiveSplit.Model;
using LiveSplit.Options;
using System.Windows.Forms;
using System.Xml;
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace LiveSplit.UI.Components
{
    public class ObsPipeComponent : LogicComponent, IDeactivatableComponent
    {
        public override string ComponentName => "OBS Pipe";
        public bool Activated { get; set; }
        private LiveSplitState State { get; set; }
        private ObsPipeSettings Settings { get; set; }
        public ObsPipeComponent(LiveSplitState state)
        {
            Activated = true;

            State = state;
            Settings = new ObsPipeSettings();
        }

        public override void Dispose()
        {
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            return Settings;
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public override void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public int GetSettingsHashCode() => Settings.GetSettingsHashCode();
    }
}
