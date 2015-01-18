using Models.Achievments.AchievmentProperties;

namespace Models.Commands.Filters
{
    public abstract class TypeFilter:BaseFilter
    {
          public virtual AchievmentPropertyType Type { get; set; }
          public int TypeId { get; set; }

    }
}