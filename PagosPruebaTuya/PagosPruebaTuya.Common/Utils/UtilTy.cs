using AutoMapper;
using Newtonsoft.Json;

namespace PagosPruebaTuya.Common.Utils
{
    public static class UtilTy
    {
        public static T? Deserialize<T>(this string jsonString) where T : class
        {
            jsonString = jsonString.TrimStart('\"');
            jsonString = jsonString.TrimEnd('\"');

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static string Serialize<T>(this T obj) where T : class
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static TNew Clone<TOriginal, TNew>(this TOriginal objOriginal)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TOriginal, TNew>();   
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<TNew>(objOriginal);
        }

        public static IEnumerable<TNew> Clone<TOriginal, TNew>(this IEnumerable<TOriginal> objOriginal)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TOriginal, TNew>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<TNew>>(objOriginal);
        }
    }
}
