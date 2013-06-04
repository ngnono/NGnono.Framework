using NGnono.Framework.Extension;

namespace NGnono.Framework.Mapping
{
    public static class MemberInfoExtensions
    {
        public static MappingAttribute GetAttribute(this System.Reflection.MemberInfo member)
        {
            MappingAttribute[] attributes = member.GetCustomAttributes<MappingAttribute>();

            MappingAttribute attribute = null;
            if (attributes.Length != 0)
                attribute = attributes[0];

            return attribute;
        }
    }
}
