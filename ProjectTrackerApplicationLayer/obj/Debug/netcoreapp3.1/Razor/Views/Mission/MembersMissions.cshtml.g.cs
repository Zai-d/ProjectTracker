#pragma checksum "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb1164add8718e01901709e024558f3c84094c90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Mission_MembersMissions), @"mvc.1.0.view", @"/Views/Mission/MembersMissions.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\_ViewImports.cshtml"
using ProjectTrackerApplicationLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\_ViewImports.cshtml"
using ProjectTrackerApplicationLayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
using ProjectTrackerBusinessLayer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb1164add8718e01901709e024558f3c84094c90", @"/Views/Mission/MembersMissions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae45f8fcb605fa49163b96301f655d63630b83ac", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Mission_MembersMissions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Mission>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1 class=\"text-center\">");
#nullable restore
#line 8 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                   Write(ViewBag.Sprint.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'s Missions</h1>\r\n<br />\r\n\r\n        <h5 class=\"text-danger mx-3\">Last date to submit work:");
#nullable restore
#line 11 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                                         Write(ViewBag.Sprint.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h5>
  
<hr />

<h3 class=""text-center"">My missions</h3>
<br />

<div class=""row justify-content-center"">
    <div class=""col-12"">
        <div class=""card shadow mb-4 mx-3"">
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered table-hover cell-border"" id=""MissionTable"" width=""100%"" cellspacing=""0"">
                        <thead>
                            <tr class=""font-weight-bolder"">
                                <th>
                                    Mission Title
                                </th>
                                <th>
                                    Mission Description
                                </th>

                                <th>
                                    Status
                                </th>
                                <th>
                                    Work Submitted
                                </th>
               ");
            WriteLiteral("                 <th>\r\n                                    Action\r\n                                </th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 45 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                              
                                foreach (var mission in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td> ");
#nullable restore
#line 49 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                        Write(mission.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td> ");
#nullable restore
#line 50 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                        Write(mission.MissionDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 51 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                       Write(mission.Status.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n                                            <ul>\r\n");
#nullable restore
#line 54 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                                 foreach (var work in mission.Works)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <li>");
#nullable restore
#line 56 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                                   Write(work.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 57 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"

                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </ul>\r\n                                        </td>\r\n");
#nullable restore
#line 61 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                         if(mission.Works.Any())
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td><a class=\"btn bg-gradient-primary text-white\"");
            BeginWriteAttribute("href", " href=\"", 2634, "\"", 2688, 2);
            WriteAttributeValue("", 2641, "/Work/MembersWorks?MissionID=", 2641, 29, true);
#nullable restore
#line 63 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
WriteAttributeValue("", 2670, mission.MissionID, 2670, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">View Works</a></td>\r\n");
#nullable restore
#line 64 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                        }
                                        else
                                        {
                                            if(mission.StatusID != 4 ||  mission.StatusID !=5 )
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td><a class=\"btn btn-outline-primary\"");
            BeginWriteAttribute("href", " href=\"", 3073, "\"", 3122, 2);
            WriteAttributeValue("", 3080, "/Work/AddWork?MissionID=", 3080, 24, true);
#nullable restore
#line 69 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
WriteAttributeValue("", 3104, mission.MissionID, 3104, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Add Works</a></td>\r\n");
#nullable restore
#line 70 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td><a class=\"btn btn-outline-primary text-white disabled\">Add Works</a></td>\r\n");
#nullable restore
#line 74 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                            }
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tr>\r\n");
#nullable restore
#line 77 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Mission\MembersMissions.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Mission>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
