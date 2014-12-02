using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achievments.AchievmentProperties
{
    public class EnumProperty
    {
        public int EnumPropertyId { get; set; }

        public EnumPropertyTypeValue SelectedValue { get; set; }

        public EnumPropertyType Type { get; set; }

        public Achievment Achievment { get; set; }
    }
}
