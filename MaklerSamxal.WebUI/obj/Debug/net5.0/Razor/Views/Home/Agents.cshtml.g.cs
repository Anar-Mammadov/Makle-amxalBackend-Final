#pragma checksum "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\Home\Agents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23d3c8a81f6fabf739096a3703563a91a77dc8ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Agents), @"mvc.1.0.view", @"/Views/Home/Agents.cshtml")]
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
#line 3 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\_ViewImports.cshtml"
using MaklerSamxal.WebUI.Models.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\_ViewImports.cshtml"
using MaklerSamxal.WebUI.Models.FormModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23d3c8a81f6fabf739096a3703563a91a77dc8ba", @"/Views/Home/Agents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14c17820444668951ef2abbccffe4c33f59389e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Agents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Agent>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-pagespeed-url-hash", new global::Microsoft.AspNetCore.Html.HtmlString("2941781182"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("pagespeed.CriticalImages.checkImageForCriticality(this);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""hero"" style=""        background-image: url(https://preview.colorlib.com/theme/warehouse/images/xhero_1.jpg.pagespeed.ic.aek8z5kvkt.webp);
        background-size: cover;
        height: 600px;
        background-attachment: fixed;""></div>




<!-- REAL ESTATE AGENTS -->

<section style=""margin-top: 100px;"" ;"" class=""site-section"" id=""agents-section"">
    <div class=""container"">
        <div class=""row mb-5"">
            <div class=""col-md-7 text-left"">
                <h2 class=""section-title mb-3"">Real Estate Agents</h2>
                <p class=""lead"">Lorem ipsum dolor sit amet consectetur adipisicing elit. Minus minima neque tempora reiciendis.</p>
            </div>
        </div>
        <div class=""row"">

");
#nullable restore
#line 22 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\Home\Agents.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-6 col-lg-4 mb-4\">\r\n                    <div class=\"team-member\">\r\n                        <figure>\r\n                            <ul class=\"social\">\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1052, "\"", 1073, 1);
#nullable restore
#line 28 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\Home\Agents.cshtml"
WriteAttributeValue("", 1059, item.Facebook, 1059, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"icon-facebook\"></span></a></li>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1159, "\"", 1179, 1);
#nullable restore
#line 29 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\Home\Agents.cshtml"
WriteAttributeValue("", 1166, item.Twitter, 1166, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"icon-twitter\"></span></a></li>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1264, "\"", 1285, 1);
#nullable restore
#line 30 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\Home\Agents.cshtml"
WriteAttributeValue("", 1271, item.Linkedin, 1271, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"icon-linkedin\"></span></a></li>\r\n                                <li><a");
            BeginWriteAttribute("href", " href=\"", 1371, "\"", 1393, 1);
#nullable restore
#line 31 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\Home\Agents.cshtml"
WriteAttributeValue("", 1378, item.Instagram, 1378, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"icon-instagram\"></span></a></li>\r\n                            </ul>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "23d3c8a81f6fabf739096a3703563a91a77dc8ba7857", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1515, "~/assets/images/", 1515, 16, true);
#nullable restore
#line 33 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\Home\Agents.cshtml"
AddHtmlAttributeValue("", 1531, item.ImagePath, 1531, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </figure>\r\n                        <div style=\"background-color:#37cfa2;\" class=\"p-3\">\r\n                            <h3 class=\"mb-2\">");
#nullable restore
#line 36 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\Home\Agents.cshtml"
                                        Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <span class=\"position\">");
#nullable restore
#line 37 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\Home\Agents.cshtml"
                                              Write(item.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 41 "C:\Users\RADEO\Desktop\kopya starbucks esl\ProjectFinal\MaklerSamxal.WebUI\Views\Home\Agents.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n           \r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Agent>> Html { get; private set; }
    }
}
#pragma warning restore 1591
