using Continental.eCAL.Core;
using Google.Protobuf;
using LiveSplit.Model;
using LiveSplit.ObsPipe;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using ObsPipeProto = global::ObsPipe.Proto;

namespace LiveSplit.UI.Components
{
    public class ObsPipeComponent : LogicComponent, IDeactivatableComponent
    {
        enum Status
        {
            Operational = 0,
            FailedToInitECAL,
            FailedToStartPublisher,
            FailedToRegisterPostPaintEvent,
            Stopped,
            Disposed,
        }

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
                    SetStatus(Status.FailedToRegisterPostPaintEvent);
                }
                else
                {
                    ppe.RegisterEventHandler(OnPostPaint);
                    SetStatus(Status.Operational);
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
            SetStatus(Status.Disposed);
        }

        public override void Update(
            IInvalidator    invalidator,
            LiveSplitState  state,
            float           width,
            float           height,
            LayoutMode      mode)
        {
        }

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
                SetStatus(Status.FailedToInitECAL);
                return false;
            }
            else
            {
                FramePublisher = new ProtobufPublisher<ObsPipeProto.Frame>(Settings.PipeName);
                FramePublisher.ShmEnableZeroCopy(Settings.ShmZeroCopyEnabled);
                FramePublisher.ShmSetBufferCount(Settings.ShmBufferCount);
                return true;
            }
        }

        private void StopPublisher()
        {
            Util.Terminate();
            SetStatus(Status.Stopped);
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
            if (Settings.ImageFormat == ObsPipe.ImageFormat.Raw)
            {
                var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                var bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
                var length = bitmapData.Stride * bitmapData.Height;

                var buffer = new byte[length];

                Marshal.Copy(bitmapData.Scan0, buffer, 0, length);
                bitmap.UnlockBits(bitmapData);

                return buffer.Length > 0 ? ByteString.CopyFrom(buffer) : ByteString.Empty;
            }
            else
            {
                var memoryStream = new MemoryStream();
                var format = ObsPipeHelpers.ImageFormatToSystem(Settings.ImageFormat);
                bitmap.Save(memoryStream, format);
                return memoryStream.Length > 0
                    ? ByteString.CopyFrom(memoryStream.ToArray())
                    : ByteString.Empty
                    ;
            }
        }

        private void SetStatus(Status status)
        {
            switch (status)
            {
                case Status.Operational:
                    Settings.Status = "Operational";
                    break;
                case Status.FailedToInitECAL:
                    Settings.Status = "Failed to initialize eCAL!";
                    break;
                case Status.FailedToStartPublisher:
                    Settings.Status = "Failed to start publisher!";
                    break;
                case Status.FailedToRegisterPostPaintEvent:
                    Settings.Status = "Failed to register post paint event!";
                    break;
                case Status.Stopped:
                    Settings.Status = "Stopped";
                    break;
                case Status.Disposed:
                    Settings.Status = "Disposed";
                    break;
            }
        }
    }
}
