using Microsoft.AspNetCore.Http;
using ProjectTrackerBusinessLayer.Data;
using ProjectTrackerBusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectTrackerBusinessLayer.Repositories.ProjectRelatedRepositories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly ApplicationDbContext context;
        public AttachmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddWorksAttachments(List<IFormFile> files, int workID)
        {
            List<Attachment> attachments = new List<Attachment>();

            foreach (var file in files)
            {
                
                Stream st = file.OpenReadStream();

                using BinaryReader br = new BinaryReader(st);
                var bytefile = br.ReadBytes((int)st.Length);


                attachments.Add(new Attachment()
                {
                    FileName = Path.GetFileName(file.FileName),
                    FileType = file.ContentType,
                    FileData = bytefile,
                    WorkID = workID,
                });
            }
            context.Attachments.AddRange(attachments);
            context.SaveChanges();
        }
        public Attachment GetAttachment(int attachmentID)
        {
            return context.Attachments.SingleOrDefault(x => x.AttachmentID==attachmentID);
        }
        public List<Attachment> GetAttachments(int workID)
        {
            return context.Attachments.Where(x => x.WorkID == workID).ToList();
        }
        public void DeleteAttachments(List<int> attachmentIDs, int workID)
        {
            var attachmentsForWork = context.Attachments.Where(x => x.WorkID == workID).ToList();

            if (attachmentIDs.Any())
            {
                foreach (var attachment in attachmentsForWork)
                {
                    if (!attachmentIDs.Contains(attachment.AttachmentID))
                    {
                        context.Attachments.Remove(attachment);
                        context.SaveChanges();
                    }
                }
            }
            else
            {
                foreach(var attachment in attachmentsForWork)
                {
                    context.Attachments.Remove(attachment);
                    context.SaveChanges();
                }

            }

        }

    }
}
