using System.Collections.Generic;
using System.Linq;
using Achievments;
using Achievments.AchievmentProperties;
using DataLayer.Repositories;

namespace DataLayer
{
    public static class AchievmentsFactory
    {
        public static Achievment GetEmptyAchievment(AchievmentType type)
        {
            var result = new Achievment()
            {
                Type = type,
                Name = "Достижение"
            };

            result.Properties=new List<AchievmentProperty>();
            result.EnumProperties=new List<EnumProperty>();

            var propertyTypes = PropertyTypesRepository.GetInstance().GetObjects().Where(x => (x.ApplicableToTypes & type) == type);
            foreach (var achievmentPropertyType in propertyTypes)
            {
                result.Properties.Add(new AchievmentProperty{Type = achievmentPropertyType});
            }
            return result;
        }
    }
}