using CommandLine;

namespace DevBlog.AdminCli.Options
{
    [Verb("delete", HelpText = "Delete blog content")]
    public class DeleteOptions
    {
        [Value(0, MetaName = "id", HelpText = "Content id")]
        public string Id { get; set; }
    }
}