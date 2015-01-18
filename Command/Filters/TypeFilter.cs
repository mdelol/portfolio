using Achievments.AchievmentProperties;

namespace Commands.Filters
{
    public abstract class TypeFilter:BaseFilter
    {
          public virtual AchievmentPropertyType Type { get; set; }
    }
}