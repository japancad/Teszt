﻿// <auto-generated />
using FamilyPhotosWithIdentity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FamilyPhotosWithIdentity.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180815221017_GithubRequest")]
    partial class GithubRequest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<string>("UrlCode")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UrlCode")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Config", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("content_type");

                    b.Property<string>("insecure_ssl");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.ToTable("Config");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.GithubRequest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("action");

                    b.Property<int>("hook_id");

                    b.Property<int?>("hookid");

                    b.Property<int?>("issueid");

                    b.Property<int?>("repositoryid");

                    b.Property<int?>("senderid");

                    b.Property<string>("zen");

                    b.HasKey("id");

                    b.HasIndex("hookid");

                    b.HasIndex("issueid");

                    b.HasIndex("repositoryid");

                    b.HasIndex("senderid");

                    b.ToTable("GithubRequests");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Hook", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventsInDb");

                    b.Property<bool>("active");

                    b.Property<int?>("configid");

                    b.Property<DateTime>("created_at");

                    b.Property<int?>("last_responseid");

                    b.Property<string>("name");

                    b.Property<string>("ping_url");

                    b.Property<string>("test_url");

                    b.Property<string>("type");

                    b.Property<DateTime>("updated_at");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.HasIndex("configid");

                    b.HasIndex("last_responseid");

                    b.ToTable("Hook");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Issue", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("assigneeid");

                    b.Property<string>("author_association");

                    b.Property<string>("body");

                    b.Property<DateTime>("closed_at");

                    b.Property<int>("comments");

                    b.Property<string>("comments_url");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("events_url");

                    b.Property<string>("html_url");

                    b.Property<string>("labels_url");

                    b.Property<bool>("locked");

                    b.Property<int?>("milestoneid");

                    b.Property<string>("node_id");

                    b.Property<int>("number");

                    b.Property<string>("repository_url");

                    b.Property<string>("state");

                    b.Property<string>("title");

                    b.Property<DateTime>("updated_at");

                    b.Property<string>("url");

                    b.Property<int?>("userid");

                    b.HasKey("id");

                    b.HasIndex("assigneeid");

                    b.HasIndex("milestoneid");

                    b.HasIndex("userid");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Label", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Issueid");

                    b.Property<bool>("_default");

                    b.Property<string>("color");

                    b.Property<string>("name");

                    b.Property<string>("node_id");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.HasIndex("Issueid");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Last_Response", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("code");

                    b.Property<string>("message");

                    b.Property<string>("status");

                    b.HasKey("id");

                    b.ToTable("Last_Response");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Milestone", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("creatorid");

                    b.Property<string>("description");

                    b.Property<string>("html_url");

                    b.Property<string>("labels_url");

                    b.Property<string>("node_id");

                    b.Property<int>("number");

                    b.Property<string>("title");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.HasIndex("creatorid");

                    b.ToTable("Milestone");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Repository", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("_private");

                    b.Property<string>("archive_url");

                    b.Property<bool>("archived");

                    b.Property<string>("assignees_url");

                    b.Property<string>("blobs_url");

                    b.Property<string>("branches_url");

                    b.Property<string>("clone_url");

                    b.Property<string>("collaborators_url");

                    b.Property<string>("comments_url");

                    b.Property<string>("commits_url");

                    b.Property<string>("compare_url");

                    b.Property<string>("contents_url");

                    b.Property<string>("contributors_url");

                    b.Property<DateTime>("created_at");

                    b.Property<string>("default_branch");

                    b.Property<string>("deployments_url");

                    b.Property<string>("description");

                    b.Property<string>("downloads_url");

                    b.Property<string>("events_url");

                    b.Property<bool>("fork");

                    b.Property<int>("forks");

                    b.Property<int>("forks_count");

                    b.Property<string>("forks_url");

                    b.Property<string>("full_name");

                    b.Property<string>("git_commits_url");

                    b.Property<string>("git_refs_url");

                    b.Property<string>("git_tags_url");

                    b.Property<string>("git_url");

                    b.Property<bool>("has_downloads");

                    b.Property<bool>("has_issues");

                    b.Property<bool>("has_pages");

                    b.Property<bool>("has_projects");

                    b.Property<bool>("has_wiki");

                    b.Property<string>("homepage");

                    b.Property<string>("hooks_url");

                    b.Property<string>("html_url");

                    b.Property<string>("issue_comment_url");

                    b.Property<string>("issue_events_url");

                    b.Property<string>("issues_url");

                    b.Property<string>("keys_url");

                    b.Property<string>("labels_url");

                    b.Property<string>("language");

                    b.Property<string>("languages_url");

                    b.Property<string>("license");

                    b.Property<string>("merges_url");

                    b.Property<string>("milestones_url");

                    b.Property<string>("mirror_url");

                    b.Property<string>("name");

                    b.Property<string>("node_id");

                    b.Property<string>("notifications_url");

                    b.Property<int>("open_issues");

                    b.Property<int>("open_issues_count");

                    b.Property<int?>("ownerid");

                    b.Property<string>("pulls_url");

                    b.Property<DateTime>("pushed_at");

                    b.Property<string>("releases_url");

                    b.Property<int>("size");

                    b.Property<string>("ssh_url");

                    b.Property<int>("stargazers_count");

                    b.Property<string>("stargazers_url");

                    b.Property<string>("statuses_url");

                    b.Property<string>("subscribers_url");

                    b.Property<string>("subscription_url");

                    b.Property<string>("svn_url");

                    b.Property<string>("tags_url");

                    b.Property<string>("teams_url");

                    b.Property<string>("trees_url");

                    b.Property<DateTime>("updated_at");

                    b.Property<string>("url");

                    b.Property<int>("watchers");

                    b.Property<int>("watchers_count");

                    b.HasKey("id");

                    b.HasIndex("ownerid");

                    b.ToTable("Repository");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Sender", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("avatar_url");

                    b.Property<string>("events_url");

                    b.Property<string>("followers_url");

                    b.Property<string>("following_url");

                    b.Property<string>("gists_url");

                    b.Property<string>("gravatar_id");

                    b.Property<string>("html_url");

                    b.Property<string>("login");

                    b.Property<string>("node_id");

                    b.Property<string>("organizations_url");

                    b.Property<string>("received_events_url");

                    b.Property<string>("repos_url");

                    b.Property<bool>("site_admin");

                    b.Property<string>("starred_url");

                    b.Property<string>("subscriptions_url");

                    b.Property<string>("type");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.ToTable("Sender");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Issueid");

                    b.Property<string>("avatar_url");

                    b.Property<string>("events_url");

                    b.Property<string>("followers_url");

                    b.Property<string>("following_url");

                    b.Property<string>("gists_url");

                    b.Property<string>("gravatar_id");

                    b.Property<string>("html_url");

                    b.Property<string>("login");

                    b.Property<string>("node_id");

                    b.Property<string>("organizations_url");

                    b.Property<string>("received_events_url");

                    b.Property<string>("repos_url");

                    b.Property<bool>("site_admin");

                    b.Property<string>("starred_url");

                    b.Property<string>("subscriptions_url");

                    b.Property<string>("type");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.HasIndex("Issueid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.GithubRequest", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.Hook", "hook")
                        .WithMany()
                        .HasForeignKey("hookid");

                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.Issue", "issue")
                        .WithMany()
                        .HasForeignKey("issueid");

                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.Repository", "repository")
                        .WithMany()
                        .HasForeignKey("repositoryid");

                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.Sender", "sender")
                        .WithMany()
                        .HasForeignKey("senderid");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Hook", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.Config", "config")
                        .WithMany()
                        .HasForeignKey("configid");

                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.Last_Response", "last_response")
                        .WithMany()
                        .HasForeignKey("last_responseid");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Issue", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.User", "assignee")
                        .WithMany()
                        .HasForeignKey("assigneeid");

                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.Milestone", "milestone")
                        .WithMany()
                        .HasForeignKey("milestoneid");

                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Label", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.Issue")
                        .WithMany("labels")
                        .HasForeignKey("Issueid");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Milestone", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.User", "creator")
                        .WithMany()
                        .HasForeignKey("creatorid");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.Repository", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.User", "owner")
                        .WithMany()
                        .HasForeignKey("ownerid");
                });

            modelBuilder.Entity("FamilyPhotosWithIdentity.Models.Github.User", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.Github.Issue")
                        .WithMany("assignees")
                        .HasForeignKey("Issueid");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FamilyPhotosWithIdentity.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FamilyPhotosWithIdentity.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
