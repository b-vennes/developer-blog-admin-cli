using CommandLine;

namespace DevBlog.AdminCli.Options
{
    [Verb("update", HelpText = "Update blog content")]
    public class UpdateOptions
    {   
        [Value(0, MetaName = "id", HelpText = "Content id")]
        public string Id { get; set; }

        [Value(1, MetaName = "title", HelpText = "Updated content title")]
        public string Title { get; set; }

        [Value(2, MetaName = "url", HelpText = "Updated content url")]
        public string Url { get; set; }

        [Value(3, MetaName = "summary", HelpText = "Updated content summary")]
        public string Summary { get; set; }

        [Value(4, MetaName = "imageUrl", HelpText = "Updated content image URL")]
        public string ImageUrl { get; set; }

        [Option(Default = "markdown", HelpText = "Updated content format")]
        public string Format { get; set; }

        [Option(Default = false, HelpText = "Update content hidden")]
        public bool Hidden { get; set; }
    }
}