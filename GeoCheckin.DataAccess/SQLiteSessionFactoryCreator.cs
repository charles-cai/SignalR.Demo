using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Automapping;
using System.IO;
using System.Configuration;

namespace GeoCheckin.DataAccess
{
	public class SQLiteSessionFactoryCreator : NHQS.ISessionFactoryCreator
	{
		public NHibernate.ISessionFactory Create()
		{
			bool createDb = true;

            string filepath = AppDomain.CurrentDomain.BaseDirectory + "GeoSignalr.db";

            createDb = !File.Exists(filepath);

			return Fluently
				.Configure()
				.Database(
					SQLiteConfiguration
						.Standard
						.ShowSql()
						.FormatSql()
                        .UsingFile(filepath)
					)
				.Mappings(m => m.AutoMappings.Add(
					AutoMap
                        .AssemblyOf<GeoCheckin.Domain.GeoCheckin>()
					))
				.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, createDb))
				.BuildSessionFactory()
				;
		}
	}
}
