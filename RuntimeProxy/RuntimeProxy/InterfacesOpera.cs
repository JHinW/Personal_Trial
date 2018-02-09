using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RuntimeProxy
{
    public class InterfacesOpera
    {
        public  IEnumerable<Type> GetInterfaces(Type type, params Type[] exceptInterfaces)
        {
            var hashSet = new HashSet<Type>(exceptInterfaces);
            foreach (var interfaceType in type.GetTypeInfo().GetInterfaces().Distinct())
            {
                if (!interfaceType.GetTypeInfo().IsVisible)
                {
                    continue;
                }
                if (!hashSet.Contains(interfaceType))
                {
                    if (interfaceType.GetTypeInfo().ContainsGenericParameters && type.GetTypeInfo().ContainsGenericParameters)
                    {
                        if (!hashSet.Contains(interfaceType.GetGenericTypeDefinition()))
                            yield return interfaceType;
                    }
                    else
                    {
                        yield return interfaceType;
                    }
                }
            }
        }
    }
}
