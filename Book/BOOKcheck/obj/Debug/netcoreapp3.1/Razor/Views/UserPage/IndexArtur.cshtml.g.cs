#pragma checksum "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a68310a29e4db45ad20a2bc992530d1e6b345ad5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserPage_IndexArtur), @"mvc.1.0.view", @"/Views/UserPage/IndexArtur.cshtml")]
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
#line 1 "E:\gitte\THEBook\Book\BOOKcheck\Views\_ViewImports.cshtml"
using BOOKcheck;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\gitte\THEBook\Book\BOOKcheck\Views\_ViewImports.cshtml"
using BOOKcheck.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a68310a29e4db45ad20a2bc992530d1e6b345ad5", @"/Views/UserPage/IndexArtur.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c682506871285f4d44246111552bd2a4ce05a9c2", @"/Views/_ViewImports.cshtml")]
    public class Views_UserPage_IndexArtur : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<BOOKcheck.Storage.Lib.UserLiber>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <h1>LIBER</h1>

    <table>
        <tr>
            <th>номер</th>
            <th>название</th>
            <th>жанр</th>
            <th>год</th>
            <th>рейтинг наш</th>
            <th>рейтинг мировой</th>
            <th>автор</th>
        </tr>
");
#nullable restore
#line 15 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
         foreach (var userLiber in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
             foreach (var end in userLiber.EndRead)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 20 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
               Write(end.Book.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
               Write(end.Book.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
               Write(end.Book.Genre.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
               Write(end.Book.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
               Write(end.Book.Rating.OurRating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
               Write(end.Book.Rating.WorldRating);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
               Write(end.Book.Author.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 28 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "E:\gitte\THEBook\Book\BOOKcheck\Views\UserPage\IndexArtur.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<BOOKcheck.Storage.Lib.UserLiber>> Html { get; private set; }
    }
}
#pragma warning restore 1591
