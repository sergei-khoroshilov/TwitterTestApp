namespace TwitterTestApp
{
    public class TwitterSearchConfig
    {
        public readonly string HashTag;
        public readonly int TwitsCount;

        public TwitterSearchConfig(string hashTag, int twitsCount)
        {
            this.HashTag = hashTag;
            this.TwitsCount = twitsCount;
        }
    }
}
