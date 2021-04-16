using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HTTP5101_Cumulative_Pt2_Natasha_Chambers.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}