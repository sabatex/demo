using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage.TagHelpers
{
    public class EsyTableTagHelper:TagHelper
    {
        public IEnumerable<object> Items { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.Attributes.Add("class", "table");
            output.Content.AppendHtml("<thead>");
            output.Content.AppendHtml("<tr>");
            var itemType = Items.First().GetType();
            foreach (var t in itemType.GetProperties())
            {
                output.Content.AppendHtml("<th>");
                output.Content.Append(t.Name);
                output.Content.AppendHtml("</th>");
            }
            output.Content.AppendHtml("</tr>");
            output.Content.AppendHtml("</thead>");

            output.Content.AppendHtml("<tbody>");
            foreach (var l in Items)
            {
                output.Content.AppendHtml("<tr>");
                foreach (var t in itemType.GetProperties())
                {
                    output.Content.AppendHtml("<td>");
                    output.Content.Append(t.GetValue(l).ToString());
                    output.Content.AppendHtml("</td>");
                }
            
                output.Content.AppendHtml("</tr>");
            }
            output.Content.AppendHtml("</tbody>");
        }
    }
}
