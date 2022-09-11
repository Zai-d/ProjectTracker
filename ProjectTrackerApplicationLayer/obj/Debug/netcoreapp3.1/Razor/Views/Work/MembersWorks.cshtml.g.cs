#pragma checksum "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbb803f0c2071b35fd48f6c8754ea30fd419ecb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Work_MembersWorks), @"mvc.1.0.view", @"/Views/Work/MembersWorks.cshtml")]
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
#line 1 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
using ProjectTrackerBusinessLayer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbb803f0c2071b35fd48f6c8754ea30fd419ecb3", @"/Views/Work/MembersWorks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae45f8fcb605fa49163b96301f655d63630b83ac", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Work_MembersWorks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Work>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1 class=\"text-center\">");
#nullable restore
#line 9 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
                   Write(ViewBag.Mission.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<br />\r\n\r\n<h5 class=\"text-danger mx-3\">Last date to submit work:");
#nullable restore
#line 12 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
                                                 Write(ViewBag.Mission.Sprint.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h5>\r\n\r\n<hr />\r\n");
            WriteLiteral("<div class=\"row mx-3\">\r\n");
#nullable restore
#line 30 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
      
		//var workThatisAprroved = @Model.Where(x => x.StatusID == 2).ToList().Count;
		//var totalWork = Model.Count();
		//var missionCompleted = Model.Where(x => x.Mission.StatusID == 4 || x.Mission.StatusID == 5).ToList();
		if (@ViewBag.StatusesChecker)
		{



#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<a class=\"btn bg-gradient-primary text-white\"");
            BeginWriteAttribute("href", " href=\"", 934, "\"", 983, 2);
            WriteAttributeValue("", 941, "/Work/AddWork?MissionID=", 941, 24, true);
#nullable restore
#line 38 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
WriteAttributeValue("", 965, ViewBag.missionID, 965, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Add work</a>\r\n");
#nullable restore
#line 39 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"


		}
		else
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<a class=\"btn bg-primary text-white disabled\">Add work</a>\r\n");
#nullable restore
#line 45 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
		}

	

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
<br />
<div class=""row justify-content-center"">
	<div class="" col-12"">
		<div class=""card mx-3 shadow mb-4"">

			<div class=""card-body"">
				<div class=""table-responsive"">
					<table class=""table table-bordered table-hover cell-border"" id=""WorkTable"" width=""100%"" cellspacing=""0"">
						<thead>
							<tr class=""font-weight-bolder"">
								<th>
									Work Title
								</th>
								<th>
									Work Description
								</th>
								<th>
									Status
								</th>
								<th>
									Attachment Submitted
								</th>
								<th>
									Team Leader Note
								</th>
								<th>
									Action
								</th>
							</tr>
						</thead>
						<tbody>
");
#nullable restore
#line 80 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
                              
								foreach (var work in Model)
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<td> ");
#nullable restore
#line 84 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
                                                    Write(work.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<td> ");
#nullable restore
#line 85 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
                                                    Write(work.WorkDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<td>");
#nullable restore
#line 86 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
                                                   Write(work.Status.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<ul>\r\n");
#nullable restore
#line 89 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
                                                             foreach (var attach in work.Attachments)
												{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<li><a");
            BeginWriteAttribute("href", " href=\"", 2143, "\"", 2204, 2);
            WriteAttributeValue("", 2150, "/Attachment/OpenFile?attachmentID=", 2150, 34, true);
#nullable restore
#line 91 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
WriteAttributeValue("", 2184, attach.AttachmentID, 2184, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"> ");
#nullable restore
#line 91 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
                                                                                                                                                 Write(attach.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 92 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
												}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t</ul>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<td>");
#nullable restore
#line 95 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
                                                   Write(work.TeamLeaderNote);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 96 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
                                                     if (work.StatusID != 4 && work.StatusID != 5 && work.StatusID != 2 && ViewBag.StatusesChecker)
										{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t<td><a class=\"btn btn-outline-info\"");
            BeginWriteAttribute("href", " href=\"", 2522, "\"", 2589, 4);
            WriteAttributeValue("", 2529, "/Work/EditWork?workID=", 2529, 22, true);
#nullable restore
#line 98 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
WriteAttributeValue("", 2551, work.WorkID, 2551, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2563, "&missionID=", 2563, 11, true);
#nullable restore
#line 98 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
WriteAttributeValue("", 2574, work.MissionID, 2574, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a></td>\r\n");
#nullable restore
#line 99 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
										}
										else
										{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t\t<td><a data-toggle=\"tooltip\" title=\"Can\'t edit check mission/work status\" class=\"btn btn-outline-info disabled\">Edit</a></td>\r\n");
#nullable restore
#line 103 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
										}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 105 "D:\Downloads (D)\Programming course\Technical\Final Project\ProjectTracker\ProjectTrackerApplicationLayer\Views\Work\MembersWorks.cshtml"
								}
							

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t</tbody>\r\n\t\t\t\t\t</table>\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n\r\n</div>\r\n");
            WriteLiteral("<script>\r\n\t$(document).ready(function () {\r\n\t\t$(\'[data-toggle=\"tooltip\"]\').tooltip();\r\n\t});\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Work>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591