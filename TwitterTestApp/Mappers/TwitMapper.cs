using LinqToTwitter;
using System.Collections.Generic;
using System.Linq;
using TwitterTestApp.Models;

namespace TwitterTestApp.Mappers
{
    public class TwitMapper : IMapper<Status, Twit>
    {
        private readonly UserMapper userMapper;
        private readonly ImageMapper imageMapper;

        public TwitMapper(UserMapper userMapper, ImageMapper imageMapper)
        {
            this.userMapper = userMapper;
            this.imageMapper = imageMapper;
        }

        public Twit Map(Status source)
        {
            var twit = new Twit()
            {
                Author = userMapper.Map(source.User),
                Text = source.Text,
                CreateAt = source.CreatedAt,
                Tags = source.Entities.HashTagEntities?.Select(te => "#" + te.Tag).ToList(),
                Images = new List<Models.Image>()
            };

            foreach (var me in source.ExtendedEntities.MediaEntities?.Where(e => e.Type == "photo"))
            {
                var image = imageMapper.Map(me);
                twit.Images.Add(image);
            }

            return twit;
        }
    }
}
