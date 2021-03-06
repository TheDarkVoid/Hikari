using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;

namespace Hikari.Bootstrap
{
	public class NancyBootstrap : DefaultNancyBootstrapper
	{

		/*private byte[] favicon;

		protected override byte[] FavIcon
		{
			get { return favicon ?? (favicon = LoadFavIcon()); }
		}

		private byte[] LoadFavIcon()
		{
			var ico = Assembly.GetEntryAssembly().GetManifestResourceStream("Hikari.HikariWeb.res.img.Hikari.ico");
			favicon = new byte[ico.Length];
			ico.Read(favicon, 0, favicon.Length);
			return favicon;
		}*/

		protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
		{
			Conventions.ViewLocationConventions.Add((viewName, model, context) =>
			{
				return string.Concat(@"HikariWeb/", viewName);
			});
		}

#if DEBUG
		protected override IRootPathProvider RootPathProvider
		{
			get { return new RootProvider(); }
		}
#endif

		protected override void ConfigureConventions(NancyConventions nancyConventions)
		{
			nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("res", @"HikariWeb/res"));
		}
	}
}
