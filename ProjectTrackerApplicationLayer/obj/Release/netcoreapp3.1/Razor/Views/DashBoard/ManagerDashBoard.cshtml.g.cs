#pragma checksum "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1ceac82001a3a91c335d217621d4099c6a1d0fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DashBoard_ManagerDashBoard), @"mvc.1.0.view", @"/Views/DashBoard/ManagerDashBoard.cshtml")]
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
#line 1 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\_ViewImports.cshtml"
using ProjectTrackerApplicationLayer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\_ViewImports.cshtml"
using ProjectTrackerApplicationLayer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
using ProjectTrackerBusinessLayer.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1ceac82001a3a91c335d217621d4099c6a1d0fe", @"/Views/DashBoard/ManagerDashBoard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae45f8fcb605fa49163b96301f655d63630b83ac", @"/Views/_ViewImports.cshtml")]
    public class Views_DashBoard_ManagerDashBoard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<h2 class=""text-center text-gray-800"">Users  <i class=""fa-solid  fa-users""></i> </h2>
<br />
<div class=""row"">

    <!-- Team Leader Count -->
    <div class=""col-xl-4 col-md-6 mb-4"">
        <div class=""card border-left-info shadow h-100 py-2"">
            <div class=""card-body"">
                <div class=""row no-gutters align-items-center"">
                    <div class=""col mr-2"">
                        <div class=""lead text-center font-weight-bold text-info text-uppercase mb-1"">
                            Team Leaders
                        </div>
                        <br />
                        <div class=""h5 mb-0 font-weight-bold text-center text-dark"">");
#nullable restore
#line 16 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
                                                                               Write(ViewBag.LeadersCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                    <div class=""col-auto"">
                        <i class=""fa-solid fa-2x fa-user-group text-info""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Team Member Count -->
    <div class=""col-xl-4 col-md-6 mb-4"">
        <div class=""card border-left-info shadow h-100 py-2"">
            <div class=""card-body"">
                <div class=""row no-gutters align-items-center"">
                    <div class=""col mr-2"">
                        <div class=""lead text-center font-weight-bold text-info text-uppercase mb-1"">
                            Team Members Senior
                        </div>
                        <br />
                        <div class=""h5 mb-0 font-weight-bold text-center text-dark"">");
#nullable restore
#line 36 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
                                                                               Write(ViewBag.SeniorsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                    <div class=""col-auto"">
                        <i class=""fa-solid fa-2x fa-user-group text-info""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""col-xl-4 col-md-6 mb-4"">
        <div class=""card border-left-info shadow h-100 py-2"">
            <div class=""card-body"">
                <div class=""row no-gutters align-items-center"">
                    <div class=""col mr-2"">
                        <div class=""lead text-center font-weight-bolder text-info text-uppercase mb-1"">
                            Team Members Junior
                        </div>
                        <br />
                        <div class=""h5 mb-0 font-weight-bold text-center text-dark"">");
#nullable restore
#line 55 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
                                                                               Write(ViewBag.JuniorsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    </div>
                    <div class=""col-auto"">
                        <i class=""fa-solid fa-2x fa-user-group text-info""></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<br />
<h2 class=""text-center text-gray-800"">Projects <i class=""fa-solid fa-folder-closed""></i></h2>
<br />
<div class=""row"">
    <div class=""col-lg-3 ""></div>
    <div class=""col-lg-6 mb-4"">
        <div class=""card shadow-lg mb-4"">
            <div class=""card-header py-3"">
                <h6 class=""m-0 font-weight-bold text-info"">Projects</h6>
            </div>
            <div class=""card-body"">
");
#nullable restore
#line 76 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
                 foreach (var project in (List<Project>)ViewBag.Projects)
                {

                    var sprints = project.Sprints;
                    double completedSprints = 0;
                    double percentage = 0;
                    if (sprints.Count != 0)
                    {
                        foreach (var sprint in sprints)
                        {
                            if (sprint.StatusID == 4)
                            {
                                completedSprints++;
                            }
                        }
                        percentage = (completedSprints / (double)sprints.Count) * 100;
                        percentage = Math.Round(percentage, 2);
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <h4 class=\"small font-weight-bold\">\r\n                        <a class=\"text-dark\"");
            BeginWriteAttribute("href", " href=\"", 4013, "\"", 4074, 2);
            WriteAttributeValue("", 4020, "/Sprint/AllSprintsManager?projectID=", 4020, 36, true);
#nullable restore
#line 95 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
WriteAttributeValue("", 4056, project.ProjectID, 4056, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
#nullable restore
#line 96 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
                   Write(project.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n                        </a>\r\n                        <span class=\"float-right\">");
#nullable restore
#line 98 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
                                             Write(percentage);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n                    </h4>\r\n                    <div class=\"progress mb-4\">\r\n                        <div class=\"progress-bar bg-info\" role=\"progressbar\"");
            BeginWriteAttribute("style", " style=\"", 4371, "\"", 4398, 3);
            WriteAttributeValue("", 4379, "width:", 4379, 6, true);
#nullable restore
#line 101 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
WriteAttributeValue(" ", 4385, percentage, 4386, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4397, "%", 4397, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("aria-valuenow", "\r\n                         aria-valuenow=\"", 4399, "\"", 4452, 1);
#nullable restore
#line 102 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
WriteAttributeValue("", 4441, percentage, 4441, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-valuemin=\"0\" aria-valuemax=\"100\"></div>\r\n                    </div>\r\n");
#nullable restore
#line 104 "C:\ProjectTracker\ProjectTrackerApplicationLayer\Views\DashBoard\ManagerDashBoard.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
