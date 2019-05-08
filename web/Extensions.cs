using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace aspnet_html5_validation
{
  public static class Extensions
  {
    public static HtmlString DisplayColumnNameFor<TModel, TClass, TProperty>(
      this IHtmlHelper<TModel> helper,
      IEnumerable<TClass> model, Expression<Func<TClass, TProperty>> expression)
    {
      if (helper == null)
        throw new ArgumentNullException(nameof (helper));
      
      if (expression == null)
        throw new ArgumentNullException(nameof (expression));
      
      var text = ExpressionHelper.GetExpressionText(expression);
      var fieldName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(text);
      var type = typeof(TClass);
      var metadata = helper.MetadataProvider.GetMetadataForType(type);

      var q =
        from p in metadata.Properties
        where p.Name == fieldName
        select p;

      var displayName = q.FirstOrDefault()?.DisplayName;
      
      return new HtmlString(displayName);
      
    }
    
  }

}