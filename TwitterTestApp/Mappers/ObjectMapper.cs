using System;
using System.Collections.Generic;

namespace TwitterTestApp.Mappers
{
    public class ObjectMapper
    {
        private readonly Dictionary<KeyValuePair<Type, Type>, object> mappers = new Dictionary<KeyValuePair<Type, Type>, object>();

        public void AddMapper<TSource, TDest>(IMapper<TSource, TDest> mapper)
        {
            var key = new KeyValuePair<Type, Type>(typeof(TSource), typeof(TDest));

            if (mappers.ContainsKey(key))
            {
                throw new Exception(string.Format("Attemp to add duplicate mappings for type {0} and {1}", typeof(TSource), typeof(TDest)));
            }

            mappers.Add(key, mapper);
        }

        public TDest Map<TSource, TDest> (TSource source)
        {
            var key = new KeyValuePair<Type, Type>(typeof(TSource), typeof(TDest));

            object value;
            if (!mappers.TryGetValue(key, out value))
            {
                throw new Exception(string.Format("Cannot find mapper for types {0} and {1}", typeof(TSource), typeof(TDest)));
            }

            var mapper = (IMapper<TSource, TDest>)value;

            return mapper.Map(source);
        }
    }
}
