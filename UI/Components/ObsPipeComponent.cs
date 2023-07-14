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
using Continental.eCAL.Core;
using LiveSplit.ObsPipe;

namespace LiveSplit.UI.Components
{
    public class ObsPipeComponent : LogicComponent, IDeactivatableComponent
    {
        public override string ComponentName => "OBS Pipe";
        public string TaskName => "obs-pipe-publisher";
        public bool Activated { get; set; }
        private LiveSplitState State { get; set; }
        private ObsPipeSettings Settings { get; set; }

        static ObsPipeComponent()
        {
            ModuleInitializer.Run();
        }
        public ObsPipeComponent(LiveSplitState state)
        {
            Activated = true;

            State = state;
            Settings = new ObsPipeSettings();

            if (!StartPublisher())
            {
            }
            else
            {
                var ppe = State.Form as IPostPaintEvent;
                if (ppe == null)
                {
                }
                else
                {
                    ppe.RegisterEventHandler(OnPostPaint);
                }
            }
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

        private bool StartPublisher()
        {
            Util.Initialize(TaskName);
            if (Util.Ok() != true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void StopPublisher()
        {
            Util.Terminate();
        }

        private void OnPostPaint(object sender, PostPaintEventArgs e)
        {
        }
    }
}
