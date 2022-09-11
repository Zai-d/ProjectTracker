using Microsoft.AspNetCore.Http;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public interface IAttachmentRepository
    {
        public void AddWorksAttachments(List<IFormFile> files, int workID);
        public Attachment GetAttachment(int attachmentID);
        public List<Attachment> GetAttachments(int workID);
        public void DeleteAttachments(List<int> attachmentIDs, int workID);
    }
}
