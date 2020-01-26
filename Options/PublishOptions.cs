using CommandLine;

namespace DevBlog.AdminCli.Options
{
    [Verb("publish", HelpText = "Publish some content to the blog")]
    public class PublishOptions
    {   
        [Value(0, MetaName = "id", HelpText = "Content id")]
        public string Id { get; set; }

        [Value(1, MetaName = "title", HelpText = "Content title")]
        public string Title { get; set; }

        [Value(2, MetaName = "url", HelpText = "Content url")]
        public string Url { get; set; }

        [Option(Default = "markdown", HelpText = "Content format")]
        public string Format { get; set; }

        [Option(Default = false, HelpText = "Content hidden")]
        public bool Hidden { get; set; }
    }
}