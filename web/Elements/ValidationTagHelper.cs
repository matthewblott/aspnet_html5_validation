using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace aspnet_html5_validation
{
  [HtmlTargetElement("input", Attributes = "asp-for")]
  [HtmlTargetElement("textarea", Attributes = "asp-for")]
  [HtmlTargetElement("select", Attributes = "asp-for")]
  public class ValidationTagHelper : TagHelper
  {
    [HtmlAttributeName("asp-for")]
    public ModelExpression For { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);

//      var metadata = For.ModelExplorer.Metadata.ValidatorMetadata;
      var defaultMetadata = For.ModelExplorer.Metadata as DefaultModelMetadata;
      var attributes = defaultMetadata?.Attributes.Attributes;

      const string required = nameof(required);
      const string minlength = nameof(minlength);
      const string maxlength = nameof(maxlength);

      var minLengthAdded = false;
      var maxLengthAdded = false;

      for (var i = 0; i < attributes?.Count; i++)
      {
        switch (attributes[i])
        {
          case EditableAttribute attribute:
            if (!attribute.AllowEdit)
            {
              output.Attributes.Add(new TagHelperAttribute("readonly", string.Empty, HtmlAttributeValueStyle.Minimized));
            }
            
            break;
          
          case RequiredAttribute attribute:
            output.Attributes.Add(new TagHelperAttribute(required, string.Empty, HtmlAttributeValueStyle.Minimized));
            break;
          
          case DisplayAttribute attribute:
            break;
          
          case StringLengthAttribute attribute:
            if (attribute.MinimumLength > 0 && context.AllAttributes[minlength] == null && !minLengthAdded)
            {
              output.Attributes.Add(new TagHelperAttribute(minlength, attribute.MinimumLength));
              minLengthAdded = true;
            }
            
            if (attribute.MaximumLength > 0 && context.AllAttributes[maxlength] == null && !maxLengthAdded)
            {
              output.Attributes.Add(new TagHelperAttribute(maxlength, attribute.MaximumLength));
              maxLengthAdded = true;
            }
            
            break;
          
          case MinLengthAttribute attribute:
            if (attribute.Length > 0 && context.AllAttributes[minlength] == null && !minLengthAdded)
            {
              output.Attributes.Add(new TagHelperAttribute(minlength, attribute.Length));
              minLengthAdded = true;
            }
            
            break;

          case MaxLengthAttribute attribute:
            if (attribute.Length > 0 && context.AllAttributes[maxlength] == null && !maxLengthAdded)
            {
              output.Attributes.Add(new TagHelperAttribute(maxlength, attribute.Length));
              maxLengthAdded = true;
            }
            
            break;

          
        }
        
      }
      
      void RemoveDataValAttribute(string attributeName)
      {
        foreach (var attribute in output.Attributes)
        {
          if (attribute.Name == attributeName)
          {
            output.Attributes.Remove(attribute);
            break;
          }
        }
      }
      
      RemoveDataValAttribute("data-val");
      RemoveDataValAttribute("data-val-required");
      RemoveDataValAttribute("data-val-length");
      RemoveDataValAttribute("data-val-length-min");
      RemoveDataValAttribute("data-val-length-max");
      RemoveDataValAttribute("data-val-maxlength-max");
      RemoveDataValAttribute("data-val-maxlength");
      RemoveDataValAttribute("data-val-minlength-min");
      RemoveDataValAttribute("data-val-minlength");

      if (string.IsNullOrWhiteSpace(output.Attributes["value"].Value.ToString()))
      {
        output.Attributes.Remove(output.Attributes["value"]);
      }
      
    }
    
  }
  
}