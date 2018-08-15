using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FamilyPhotosWithIdentity.Data.Migrations
{
    public partial class GithubRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    content_type = table.Column<string>(nullable: true),
                    insecure_ssl = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Last_Response",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Last_Response", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sender",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    avatar_url = table.Column<string>(nullable: true),
                    events_url = table.Column<string>(nullable: true),
                    followers_url = table.Column<string>(nullable: true),
                    following_url = table.Column<string>(nullable: true),
                    gists_url = table.Column<string>(nullable: true),
                    gravatar_id = table.Column<string>(nullable: true),
                    html_url = table.Column<string>(nullable: true),
                    login = table.Column<string>(nullable: true),
                    node_id = table.Column<string>(nullable: true),
                    organizations_url = table.Column<string>(nullable: true),
                    received_events_url = table.Column<string>(nullable: true),
                    repos_url = table.Column<string>(nullable: true),
                    site_admin = table.Column<bool>(nullable: false),
                    starred_url = table.Column<string>(nullable: true),
                    subscriptions_url = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Hook",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventsInDb = table.Column<string>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    configid = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    last_responseid = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    ping_url = table.Column<string>(nullable: true),
                    test_url = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: false),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hook", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hook_Config_configid",
                        column: x => x.configid,
                        principalTable: "Config",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hook_Last_Response_last_responseid",
                        column: x => x.last_responseid,
                        principalTable: "Last_Response",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GithubRequests",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    action = table.Column<string>(nullable: true),
                    hook_id = table.Column<int>(nullable: false),
                    hookid = table.Column<int>(nullable: true),
                    issueid = table.Column<int>(nullable: true),
                    repositoryid = table.Column<int>(nullable: true),
                    senderid = table.Column<int>(nullable: true),
                    zen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GithubRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_GithubRequests_Hook_hookid",
                        column: x => x.hookid,
                        principalTable: "Hook",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GithubRequests_Sender_senderid",
                        column: x => x.senderid,
                        principalTable: "Sender",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Issueid = table.Column<int>(nullable: true),
                    _default = table.Column<bool>(nullable: false),
                    color = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    node_id = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Issueid = table.Column<int>(nullable: true),
                    avatar_url = table.Column<string>(nullable: true),
                    events_url = table.Column<string>(nullable: true),
                    followers_url = table.Column<string>(nullable: true),
                    following_url = table.Column<string>(nullable: true),
                    gists_url = table.Column<string>(nullable: true),
                    gravatar_id = table.Column<string>(nullable: true),
                    html_url = table.Column<string>(nullable: true),
                    login = table.Column<string>(nullable: true),
                    node_id = table.Column<string>(nullable: true),
                    organizations_url = table.Column<string>(nullable: true),
                    received_events_url = table.Column<string>(nullable: true),
                    repos_url = table.Column<string>(nullable: true),
                    site_admin = table.Column<bool>(nullable: false),
                    starred_url = table.Column<string>(nullable: true),
                    subscriptions_url = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Milestone",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    creatorid = table.Column<int>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    html_url = table.Column<string>(nullable: true),
                    labels_url = table.Column<string>(nullable: true),
                    node_id = table.Column<string>(nullable: true),
                    number = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestone", x => x.id);
                    table.ForeignKey(
                        name: "FK_Milestone_User_creatorid",
                        column: x => x.creatorid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Repository",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    _private = table.Column<bool>(nullable: false),
                    archive_url = table.Column<string>(nullable: true),
                    archived = table.Column<bool>(nullable: false),
                    assignees_url = table.Column<string>(nullable: true),
                    blobs_url = table.Column<string>(nullable: true),
                    branches_url = table.Column<string>(nullable: true),
                    clone_url = table.Column<string>(nullable: true),
                    collaborators_url = table.Column<string>(nullable: true),
                    comments_url = table.Column<string>(nullable: true),
                    commits_url = table.Column<string>(nullable: true),
                    compare_url = table.Column<string>(nullable: true),
                    contents_url = table.Column<string>(nullable: true),
                    contributors_url = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    default_branch = table.Column<string>(nullable: true),
                    deployments_url = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    downloads_url = table.Column<string>(nullable: true),
                    events_url = table.Column<string>(nullable: true),
                    fork = table.Column<bool>(nullable: false),
                    forks = table.Column<int>(nullable: false),
                    forks_count = table.Column<int>(nullable: false),
                    forks_url = table.Column<string>(nullable: true),
                    full_name = table.Column<string>(nullable: true),
                    git_commits_url = table.Column<string>(nullable: true),
                    git_refs_url = table.Column<string>(nullable: true),
                    git_tags_url = table.Column<string>(nullable: true),
                    git_url = table.Column<string>(nullable: true),
                    has_downloads = table.Column<bool>(nullable: false),
                    has_issues = table.Column<bool>(nullable: false),
                    has_pages = table.Column<bool>(nullable: false),
                    has_projects = table.Column<bool>(nullable: false),
                    has_wiki = table.Column<bool>(nullable: false),
                    homepage = table.Column<string>(nullable: true),
                    hooks_url = table.Column<string>(nullable: true),
                    html_url = table.Column<string>(nullable: true),
                    issue_comment_url = table.Column<string>(nullable: true),
                    issue_events_url = table.Column<string>(nullable: true),
                    issues_url = table.Column<string>(nullable: true),
                    keys_url = table.Column<string>(nullable: true),
                    labels_url = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true),
                    languages_url = table.Column<string>(nullable: true),
                    license = table.Column<string>(nullable: true),
                    merges_url = table.Column<string>(nullable: true),
                    milestones_url = table.Column<string>(nullable: true),
                    mirror_url = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    node_id = table.Column<string>(nullable: true),
                    notifications_url = table.Column<string>(nullable: true),
                    open_issues = table.Column<int>(nullable: false),
                    open_issues_count = table.Column<int>(nullable: false),
                    ownerid = table.Column<int>(nullable: true),
                    pulls_url = table.Column<string>(nullable: true),
                    pushed_at = table.Column<DateTime>(nullable: false),
                    releases_url = table.Column<string>(nullable: true),
                    size = table.Column<int>(nullable: false),
                    ssh_url = table.Column<string>(nullable: true),
                    stargazers_count = table.Column<int>(nullable: false),
                    stargazers_url = table.Column<string>(nullable: true),
                    statuses_url = table.Column<string>(nullable: true),
                    subscribers_url = table.Column<string>(nullable: true),
                    subscription_url = table.Column<string>(nullable: true),
                    svn_url = table.Column<string>(nullable: true),
                    tags_url = table.Column<string>(nullable: true),
                    teams_url = table.Column<string>(nullable: true),
                    trees_url = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    watchers = table.Column<int>(nullable: false),
                    watchers_count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repository", x => x.id);
                    table.ForeignKey(
                        name: "FK_Repository_User_ownerid",
                        column: x => x.ownerid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    assigneeid = table.Column<int>(nullable: true),
                    author_association = table.Column<string>(nullable: true),
                    body = table.Column<string>(nullable: true),
                    closed_at = table.Column<DateTime>(nullable: false),
                    comments = table.Column<int>(nullable: false),
                    comments_url = table.Column<string>(nullable: true),
                    created_at = table.Column<DateTime>(nullable: false),
                    events_url = table.Column<string>(nullable: true),
                    html_url = table.Column<string>(nullable: true),
                    labels_url = table.Column<string>(nullable: true),
                    locked = table.Column<bool>(nullable: false),
                    milestoneid = table.Column<int>(nullable: true),
                    node_id = table.Column<string>(nullable: true),
                    number = table.Column<int>(nullable: false),
                    repository_url = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    updated_at = table.Column<DateTime>(nullable: false),
                    url = table.Column<string>(nullable: true),
                    userid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.id);
                    table.ForeignKey(
                        name: "FK_Issue_User_assigneeid",
                        column: x => x.assigneeid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issue_Milestone_milestoneid",
                        column: x => x.milestoneid,
                        principalTable: "Milestone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issue_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GithubRequests_hookid",
                table: "GithubRequests",
                column: "hookid");

            migrationBuilder.CreateIndex(
                name: "IX_GithubRequests_issueid",
                table: "GithubRequests",
                column: "issueid");

            migrationBuilder.CreateIndex(
                name: "IX_GithubRequests_repositoryid",
                table: "GithubRequests",
                column: "repositoryid");

            migrationBuilder.CreateIndex(
                name: "IX_GithubRequests_senderid",
                table: "GithubRequests",
                column: "senderid");

            migrationBuilder.CreateIndex(
                name: "IX_Hook_configid",
                table: "Hook",
                column: "configid");

            migrationBuilder.CreateIndex(
                name: "IX_Hook_last_responseid",
                table: "Hook",
                column: "last_responseid");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_assigneeid",
                table: "Issue",
                column: "assigneeid");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_milestoneid",
                table: "Issue",
                column: "milestoneid");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_userid",
                table: "Issue",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Label_Issueid",
                table: "Label",
                column: "Issueid");

            migrationBuilder.CreateIndex(
                name: "IX_Milestone_creatorid",
                table: "Milestone",
                column: "creatorid");

            migrationBuilder.CreateIndex(
                name: "IX_Repository_ownerid",
                table: "Repository",
                column: "ownerid");

            migrationBuilder.CreateIndex(
                name: "IX_User_Issueid",
                table: "User",
                column: "Issueid");

            migrationBuilder.AddForeignKey(
                name: "FK_GithubRequests_Issue_issueid",
                table: "GithubRequests",
                column: "issueid",
                principalTable: "Issue",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GithubRequests_Repository_repositoryid",
                table: "GithubRequests",
                column: "repositoryid",
                principalTable: "Repository",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Label_Issue_Issueid",
                table: "Label",
                column: "Issueid",
                principalTable: "Issue",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Issue_Issueid",
                table: "User",
                column: "Issueid",
                principalTable: "Issue",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Issue_Issueid",
                table: "User");

            migrationBuilder.DropTable(
                name: "GithubRequests");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Hook");

            migrationBuilder.DropTable(
                name: "Repository");

            migrationBuilder.DropTable(
                name: "Sender");

            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "Last_Response");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "Milestone");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
