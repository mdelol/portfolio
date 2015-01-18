using System.Collections.Generic;
using System.Linq;
using DataLayer.Repositories;
using Models.Achievments;
using Models.Achievments.AchievmentProperties;

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

            var propertyTypes = PropertyTypesRepository.GetInstance().GetNoTrackingObjects().Where(x => (x.ApplicableToTypes & type) == type);
            foreach (var achievmentPropertyType in propertyTypes)
            {
                result.Properties.Add(new AchievmentProperty { Type = achievmentPropertyType, TypeId = achievmentPropertyType .AchievmentPropertyTypeId});
            }
            return result;
        }
    }
}