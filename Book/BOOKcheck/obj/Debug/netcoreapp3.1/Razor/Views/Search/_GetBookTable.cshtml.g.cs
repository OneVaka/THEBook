#pragma checksum "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0673e82587735ebd22768bc08a0989d5552d1387"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search__GetBookTable), @"mvc.1.0.view", @"/Views/Search/_GetBookTable.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\projects\THEbook\Book\BOOKcheck\Views\_ViewImports.cshtml"
using BOOKcheck;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\projects\THEbook\Book\BOOKcheck\Views\_ViewImports.cshtml"
using BOOKcheck.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0673e82587735ebd22768bc08a0989d5552d1387", @"/Views/Search/_GetBookTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c682506871285f4d44246111552bd2a4ce05a9c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Search__GetBookTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<BOOKcheck.Storage.Entity.Book>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:black; font-weight:500"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<style>
    a{
        text-decoration:none;
    }
    a:hover{
        text-decoration:underline;
    }
</style>

<table style=""width: 100%"">
    <tr style="" height:max-content; border-bottom: 1px solid #ccc"">
        <th style=""width: 30%;padding-left: 15px"">Название</th>
        <th style=""width: 10%"">Жанр</th>
        <th style=""width: 10%"">Год</th>
        <th style=""width: 20%"">Автор</th>
        <th style=""width: 15%; text-align: center"">Пользовательский<br /> рейтинг</th>
        <th style=""width: 15%; text-align: center"">Мировой<br /> рейтинг</th>

    </tr>

");
#nullable restore
#line 23 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
     if (Model == null || Model.Count == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n            <td colspan=\"6\" style=\"font-size:18px; padding-left: 15px\">Ничего не было найдено!</td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 30 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 32 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
     foreach (var book in Model)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr style=\"height:max-content\">\r\n");
#nullable restore
#line 36 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
             if (book.Name != null)
            {   

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td style=\"padding-left: 15px\">\r\n                     ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0673e82587735ebd22768bc08a0989d5552d13875243", async() => {
#nullable restore
#line 39 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
                                                                                Write(book.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1099, "~/Book/", 1099, 7, true);
#nullable restore
#line 39 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
AddHtmlAttributeValue("", 1106, book.Id, 1106, 8, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" \r\n                </td>\r\n                <td>");
#nullable restore
#line 41 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
               Write(book.Genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 42 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
               Write(book.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 43 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
               Write(book.Author.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"text-align:center\">");
#nullable restore
#line 44 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
                                         Write(book.Rating.OurRating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"text-align: center\">");
#nullable restore
#line 45 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
                                          Write(book.Rating.WorldRating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 46 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 48 "E:\projects\THEbook\Book\BOOKcheck\Views\Search\_GetBookTable.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<BOOKcheck.Storage.Entity.Book>> Html { get; private set; }
    }
}
#pragma warning restore 1591
