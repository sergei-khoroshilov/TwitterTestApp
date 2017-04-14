namespace TwitterTestApp
{
    public class TwitterConfig
    {
        public readonly string ConsumerKey;
        public readonly string ConsumerSecret;

        public TwitterConfig (string consumerKey, string consumerSecret)
        {
            this.ConsumerKey = consumerKey;
            this.ConsumerSecret = consumerSecret;
        }
    }
}