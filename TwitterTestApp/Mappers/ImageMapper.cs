using LinqToTwitter;
using System.Linq;
using TwitterTestApp.Models;

namespace TwitterTestApp.Mappers
{
    public class ImageMapper : IMapper<MediaEntity, Image>
    {
        public Image Map(MediaEntity source)
        {
            var image = new Image()
            {
                Url = source.MediaUrl
            };

            var sizes = source.Sizes.FirstOrDefault(s => s.Type == "small");
            if (sizes != null)
            {
                image.Height = sizes.Height;
                image.Width = sizes.Width;
            }

            return image;
        }
    }
}
