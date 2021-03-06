﻿using System.Web;
using System.Web.Optimization;

namespace Sinbin.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/register").Include(
                        "~/Scripts/photo-upload.js",
                        "~/Scripts/register.js"));

            bundles.Add(new ScriptBundle("~/bundles/photo").Include(
                        "~/Scripts/picture.js",
                        "~/Scripts/photo-upload.js"));

            bundles.Add(new ScriptBundle("~/bundles/navigation").Include(
                        "~/Scripts/navbar.js",
                        "~/Scripts/navbar-layout.js",
                        "~/Scripts/location-manager.js",
                        "~/Scripts/menu-icon.js",
                        "~/Scripts/footbar.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-toggle.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/feed").Include(
                      "~/Scripts/feed.js",
                      "~/Scripts/feed-index.js"));

            bundles.Add(new ScriptBundle("~/bundles/settings").Include(
                      "~/Scripts/settings-menu.js"));

            bundles.Add(new ScriptBundle("~/bundles/loadImage").Include(
                      "~/Scripts/load-image.all.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-toggle.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/login").Include(
                      "~/Content/login.css"));

            bundles.Add(new StyleBundle("~/Content/feed").Include(
                      "~/Content/feed.css"));
					  
			bundles.Add(new StyleBundle("~/Content/register").Include(
                      "~/Content/register.css",
                      "~/Content/photo-upload.css"));

            bundles.Add(new StyleBundle("~/Content/picture").Include(
                      "~/Content/picture.css",
                      "~/Content/photo-upload.css"));

            bundles.Add(new StyleBundle("~/Content/navbar").Include(
                      "~/Content/navbar-layout.css"));

            bundles.Add(new StyleBundle("~/Content/menu").Include(
                      "~/Content/menu.css"));

            bundles.Add(new StyleBundle("~/Content/info").Include(
                      "~/Content/info.css"));
        }
    }
}
