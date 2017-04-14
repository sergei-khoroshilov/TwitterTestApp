using TwitterTestApp.Mappers;

namespace TwitterTestApp
{
    public class ObjectMapperConfig
    {
        public static ObjectMapper Create()
        {
            var objectMapper = new ObjectMapper();

            var userMapper = new UserMapper();
            var imageMapper = new ImageMapper();
            var twitMapper = new TwitMapper(userMapper, imageMapper);

            objectMapper.AddMapper(userMapper);
            objectMapper.AddMapper(imageMapper);
            objectMapper.AddMapper(twitMapper);

            return objectMapper;
        }
    }
}
