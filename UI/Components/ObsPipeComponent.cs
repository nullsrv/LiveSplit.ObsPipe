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
using Google.Protobuf;
using LiveSplit.ObsPipe;
using ObsPipeProto = global::ObsPipe.Proto;

namespace LiveSplit.UI.Components
{
    public class ObsPipeComponent : LogicComponent, IDeactivatableComponent
    {
        public override string ComponentName => "OBS Pipe";
        public string TaskName => "obs-pipe-publisher";
        public bool Activated { get; set; }
        private LiveSplitState State { get; set; }
        private ObsPipeSettings Settings { get; set; }
        private ProtobufPublisher<ObsPipeProto.Frame> FramePublisher { get; set; }
        static ObsPipeComponent()
        {
            //ModuleInitializer.Run();
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
            var ppe = State.Form as IPostPaintEvent;
            if (ppe != null)
            {
                ppe.UnregisterEventHandler(OnPostPaint);
            }
            StopPublisher();
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
                FramePublisher = new ProtobufPublisher<ObsPipeProto.Frame>("pipe0");
                return true;
            }
        }

        private void StopPublisher()
        {
            Util.Terminate();
        }

        private void OnPostPaint(object sender, PostPaintEventArgs e)
        {
            var bytes = PrepareData(e.Bitmap);

            var imageFormat = ObsPipe.ImageFormat.Raw;
            var pixelFormat = ObsPipeHelpers.PixelFormatFromSystem(e.Bitmap.PixelFormat);

            var frame = new ObsPipeProto.Frame
            {
                Id = e.FrameId,
                Rendered = ObsPipeHelpers.ToGoogleTimestamp(e.Rendered),
                Generated = ObsPipeHelpers.ToGoogleTimestamp(DateTime.UtcNow),
                Width = e.Bitmap.Width,
                Height = e.Bitmap.Height,
                Bpp = 32,
                ImageFormat = ObsPipeHelpers.ImageFormatToProto(imageFormat),
                PixelFormat = ObsPipeHelpers.PixelFormatToProto(pixelFormat),
                Compression = ObsPipeProto.Compression.None,
                Region = new ObsPipeProto.Rectangle
                {
                    X = 0,
                    Y = 0,
                    Width = e.Bitmap.Width,
                    Height = e.Bitmap.Height,
                },
                Buffer = bytes,

            };
            FramePublisher.Send(frame);
        }

        private ByteString PrepareData(Bitmap bitmap)
        {
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var length = bitmapData.Stride * bitmapData.Height;

            var buffer = new byte[length];

            Marshal.Copy(bitmapData.Scan0, buffer, 0, length);
            bitmap.UnlockBits(bitmapData);

            return buffer.Length > 0 ? ByteString.CopyFrom(buffer) : null;
        }
    }
}
