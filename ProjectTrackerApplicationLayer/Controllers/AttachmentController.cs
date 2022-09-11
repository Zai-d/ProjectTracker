using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTrackerBusinessLayer.Entities;
using ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories;
using System.Collections.Generic;
using System.IO;

namespace ProjectTrackerApplicationLayer.Controllers
{
    [Authorize]

    public class AttachmentController : Controller
    {

        private readonly IAttachmentRepository attachmentRepo;
        public AttachmentController(IAttachmentRepository attachmentRepo)
        {
            this.attachmentRepo = attachmentRepo;
        }
        //To open any attachment in database
        [Authorize]
        public FileResult OpenFile(int attachmentID)
        {
            var file = attachmentRepo.GetAttachment(attachmentID);
            Stream fileStream = new MemoryStream(file.FileData);
            return new FileStreamResult(fileStream, file.FileType);
        }
    }
}
