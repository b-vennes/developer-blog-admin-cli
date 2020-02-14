using CommandLine;

namespace DevBlog.AdminCli.Options
{
    [Verb("publish", HelpText = "Publish some content to the blog")]
    public class PublishOptions
    {   
        [Value(0, MetaName = "id", HelpText = "Content id")]
        public string Id { get; set; }

        [Option(HelpText = "Content title")]
        public string Title { get; set; }

        [Option(HelpText = "Content url")]
        public string Url { get; set; }

        [Option(HelpText = "Content summary")]
        public string Summary { get; set; }

        [Option(HelpText = "Content image URL")]
        public string ImageUrl { get; set; }

        [Option(Default = "markdown", HelpText = "Content format")]
        public string Format { get; set; }

        [Option(Default = false, HelpText = "Content hidden")]
        public bool Hidden { get; set; }
    }
}