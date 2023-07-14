using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public partial class ObsPipeSettings : UserControl
    {
        class ImageFormatItem
        {
            public ObsPipe.ImageFormat Value { get; set; }
            public string Name { get; set; }
        }

        public string PipeName { get; set; }
        public bool ShmZeroCopyEnabled { get; set; }
        public int ShmBufferCount { get; set; }
        public ObsPipe.ImageFormat ImageFormat { get; set; }
        public bool EnableCompression { get; set; }
        public string Status { get; set; }
        
        public ObsPipeSettings()
        {
            InitializeComponent();

            PipeName = "LiveSplit";
            ShmZeroCopyEnabled = false;
            ShmBufferCount = 1;
            Status = "Unknown";

            var items = new List<ImageFormatItem>
            {
                new ImageFormatItem { Value = ObsPipe.ImageFormat.Raw,  Name = "Raw" },
                new ImageFormatItem { Value = ObsPipe.ImageFormat.Bmp,  Name = "Bmp" },
                new ImageFormatItem { Value = ObsPipe.ImageFormat.Jpeg, Name = "Jpeg" },
                new ImageFormatItem { Value = ObsPipe.ImageFormat.Png,  Name = "Png" },
                new ImageFormatItem { Value = ObsPipe.ImageFormat.Tiff, Name = "Tiff" }
            };

            cbbImageFormat.DataSource = items;
            cbbImageFormat.DisplayMember = "Name";
            cbbImageFormat.ValueMember = "Value";
            
            tbPipeName.DataBindings.Add("Text", this, "PipeName");
            chkEnableZeroCopy.DataBindings.Add("Checked", this, "ShmZeroCopyEnabled", false, DataSourceUpdateMode.OnPropertyChanged);
            nudBufferCount.DataBindings.Add("Value", this, "ShmBufferCount");
            nudBufferCount.DataBindings.Add("Enabled", this, "ShmZeroCopyEnabled");
            cbbImageFormat.DataBindings.Add("SelectedValue", this, "ImageFormat", false, DataSourceUpdateMode.OnPropertyChanged);
            chkCompression.DataBindings.Add("Checked", this, "EnableCompression", false, DataSourceUpdateMode.OnPropertyChanged);
            txtStatusValue.DataBindings.Add("Text", this, "Status");
        }

        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;

            PipeName = SettingsHelper.ParseString(element["PipeName"], "LiveSplit");
            ShmZeroCopyEnabled = SettingsHelper.ParseBool(element["ShmZeroCopyEnabled"]);
            ShmBufferCount = SettingsHelper.ParseInt(element["ShmBufferCount"], 1);
            ImageFormat = SettingsHelper.ParseEnum<ObsPipe.ImageFormat>(element["ImageFormat"], ObsPipe.ImageFormat.Raw);
            EnableCompression = SettingsHelper.ParseBool(element["EnableCompression"]);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.6") ^
            SettingsHelper.CreateSetting(document, parent, "PipeName", PipeName) ^
            SettingsHelper.CreateSetting(document, parent, "ShmZeroCopyEnabled", ShmZeroCopyEnabled) ^
            SettingsHelper.CreateSetting(document, parent, "ShmBufferCount", ShmBufferCount) ^
            SettingsHelper.CreateSetting(document, parent, "EnableCompression", EnableCompression) ^
            SettingsHelper.CreateSetting<ObsPipe.ImageFormat>(document, parent, "ImageFormat", ImageFormat);
        }

        private void cbbImageFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = cbbImageFormat.SelectedValue;
            if (sel != null)
            {
                var format = (ObsPipe.ImageFormat)sel;
                if (format == ObsPipe.ImageFormat.Raw)
                {
                    chkCompression.Enabled = true;
                }
                else
                {
                    chkCompression.Enabled = false;
                }
            }
        }
    }
}
