using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore_Demos.Utility
{
    public class Bilal : TagHelper
    {
        public String Name { get; set; }
        public Bilal()
        {
            
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("id", "myid");
            output.Content.AppendHtml($"<h1>{Name}</h1>");
        }
    }

    public class MyConfiguration : TagHelper
    {
        private readonly IConfiguration _configuration;

        public String Name { get; set; }
        public MyConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("id", "myid");

            ProcessChildren(output, _configuration.GetSection("Logging").GetChildren());
            
        }
        private void ProcessChildren(TagHelperOutput output, IEnumerable<IConfigurationSection> configurations)
        {
            foreach (var child in configurations)
            {
                output.Content.AppendHtml($"<h2>Key:{child.Key},Value:{child.Value}</h2>");
                var subchild = child.GetChildren();
                if (subchild != null && subchild.Count() > 0)
                {
                    ProcessChildren(output, subchild);
                }
            }
        }
    }

    [HtmlTargetElement("bold")]
    [HtmlTargetElement(Attributes = "bold")]
    //[HtmlTargetElement("bold", Attributes = "bold")]
    public class bold : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("bold");
            output.PreContent.SetHtmlContent("<strong>");
            output.PostContent.SetHtmlContent("</strong>");
        }
    }
}

