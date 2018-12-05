using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace aspnet_html5_validation
{
  [HtmlTargetElement("input", Attributes = "asp-for")]
  [HtmlTargetElement("textarea", Attributes = "asp-for")]
  public class RequiredTagHelper : TagHelper
  {
//    public override int Order { get; } = int.MaxValue;
    
    [HtmlAttributeName("asp-for")]
    public ModelExpression For { get; set; }
    
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
      base.Process(context, output);
      
      if (context.AllAttributes["required"] == null) 
      {
        var isRequired = IsRequired(For.ModelExplorer.Metadata.ValidatorMetadata);

        
        
        if (isRequired)
        {
          //output.Attributes.Add("required", "required");
          
          var attr = new TagHelperAttribute("required", string.Empty, HtmlAttributeValueStyle.Minimized);

          output.Attributes.Add(attr);

          
        }

        foreach (var attribute in output.Attributes)
        {
          if (attribute.Name == "data-val")
          {
            output.Attributes.Remove(attribute);
            break;
            
          }
        }
        
        
        
        // tagBuilder.MergeAttribute("required", string.Empty);

        foreach (var attribute in output.Attributes)
        {
          if (attribute.Name == "data-val-required")
          {
//            var builder = new TagBuilder("input");
//            builder.MergeAttribute("required", string.Empty);
            
            output.Attributes.Remove(attribute);
            break;
            
          }
        }

      }
      
    }
    
    private static bool IsRequired(IReadOnlyList<object> validatorMetadata)
    {
      for (var i = 0; i < validatorMetadata.Count; i++)
      {
        if (validatorMetadata[i] is RequiredAttribute requiredAttribute)
        {
          return true;
        }
        
      }
      
      return false;
      
    }
    
  }
  
}