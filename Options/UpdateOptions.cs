using CommandLine;

namespace DevBlog.AdminCli.Options
{
    [Verb("update", HelpText = "Update blog content")]
    public class UpdateOptions
    {   
        [Value(0, MetaName = "id", HelpText = "Content id")]
        public string Id { get; set; }

        [Value(1, MetaName = "passcode", HelpText = "Authorization passcode")]
        public string Passcode { get; set; }

        [Option(Default = null, HelpText = "Updated content title")]
        public string Title { get; set; }

        [Option(Default = null, HelpText = "Updated content url")]
        public string Url { get; set; }

        [Option(Default = null, HelpText = "Updated content summary")]
        public string Summary { get; set; }

        [Option(Default = null, HelpText = "Updated content image URL")]
        public string ImageUrl { get; set; }

        [Option(Default = null, HelpText = "Updated content format")]
        public string Format { get; set; }

        [Option(Default = false, HelpText = "Update content hidden")]
        public bool Hidden { get; set; }
    }
}