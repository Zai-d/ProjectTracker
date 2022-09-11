using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using ProjectTrackerBusinessLayer.Entities;
using System.Collections.Generic;
using System.Text;

namespace ProjectTrackerBusinessLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<TeamManager> TeamManagers { get; set; }
        public DbSet<TeamLeader> TeamLeaders { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<UsersProjects> UsersProjects { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // THE PROJECT RELATION WITH THE USER
            builder.Entity<User>()
                .HasMany(u => u.UsersProjects)
                .WithOne(up => up.User).HasForeignKey(up => up.UserID);
            builder.Entity<Project>()
                .HasMany(p => p.UsersProjects)
                .WithOne(up => up.Project).HasForeignKey(up => up.ProjectID);
            builder.Entity<UsersProjects>().HasKey(up => new { up.ProjectID, up.UserID });

            // THE USERS POSITION(RANK)
            builder.Entity<User>().
                HasOne(u => u.Position)
                .WithMany(p => p.Users).HasForeignKey(u => u.PositionID);

            //// Each TEAM LEADER's sprints
            //builder.Entity<TeamLeader>()
            //    .HasMany(TL => TL.Sprints)
            //    .WithOne(S => S.TeamLeader).HasForeignKey(S => S.TeamLeaderID);

            //// Each TEAM LEADER's missions
            //builder.Entity<TeamLeader>()
            //    .HasMany(TL => TL.Missions)
            //    .WithOne(M => M.TeamLeader).HasForeignKey(M => M.TeamLeaderID);

            //// TEAM MEMBER's works
            //builder.Entity<TeamMember>()
            //    .HasMany(TM => TM.Works)
            //    .WithOne(W => W.TeamMember).HasForeignKey(W => W.TeamMemberID);

            //// the *TEAM MEMBER* missions
            //builder.Entity<TeamMember>()
            //    .HasMany(TM => TM.Missions)
            //    .WithOne(M => M.TeamMember).HasForeignKey(M => M.TeamMemberID);

            // The SPRINTS in a PROJECT
            builder.Entity<Project>()
                .HasMany(P => P.Sprints)
                .WithOne(S => S.Project).HasForeignKey(S => S.ProjectID);

            // Project Status
            builder.Entity<Project>()
                .HasOne(P => P.Status)
                .WithMany(St => St.Projects).HasForeignKey(P => P.StatusID);

            // Many missions in a sprint
            builder.Entity<Sprint>()
                .HasMany(S => S.Missions)
                .WithOne(M => M.Sprint).HasForeignKey(M => M.SprintID);

            // Sprint Status
            builder.Entity<Sprint>()
                .HasOne(S => S.Status)
                .WithMany(St => St.Sprints).HasForeignKey(S => S.StatusID);

            //Many works in a mission
            builder.Entity<Mission>()
                .HasMany(M => M.Works)
                .WithOne(W => W.Mission).HasForeignKey(W => W.MissionID);

            // Work Status
            builder.Entity<Work>()
                .HasOne(W => W.Status)
                .WithMany(St => St.Works).HasForeignKey(W => W.StatusID);

            //Mission Status
            builder.Entity<Mission>()
                .HasOne(M => M.Status)
                .WithMany(St => St.Missions).HasForeignKey(M => M.StatusID);

            //Attachments with work
            builder.Entity<Work>()
                .HasMany(w =>  w.Attachments)
                .WithOne(Att => Att.Work).HasForeignKey(Att => Att.WorkID);
            builder.Entity<Activity>()
                .HasOne(x => x.Status)
                .WithMany(x => x.Activities).HasForeignKey(x => x.StatusID);











            base.OnModelCreating(builder);

        }
    }
}
