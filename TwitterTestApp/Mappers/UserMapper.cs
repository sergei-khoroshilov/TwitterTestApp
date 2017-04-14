namespace TwitterTestApp.Mappers
{
    public class UserMapper : IMapper<LinqToTwitter.User, Models.User>
    {
        public Models.User Map(LinqToTwitter.User source)
        {
            return new Models.User()
            {
                Name = source.Name
            };
        }
    }
}
