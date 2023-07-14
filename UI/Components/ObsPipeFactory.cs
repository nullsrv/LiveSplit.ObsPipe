using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;

[assembly: ComponentFactory(typeof(ObsPipeFactory))]

namespace LiveSplit.UI.Components
{
    public class ObsPipeFactory : IComponentFactory
    {
        public string ComponentName => "OBS Pipe";

        public string Description => "Pipe LiveSplit to OBS";

        public ComponentCategory Category => ComponentCategory.Other;

        public IComponent Create(LiveSplitState state) => new ObsPipeComponent(state);

        public string UpdateName => ComponentName;

        public string XMLURL => "";

        public string UpdateURL => "";

        public Version Version => Version.Parse("0.1.0");
    }
}
