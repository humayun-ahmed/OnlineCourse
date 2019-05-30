// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountHistoryConfiguration.cs" company="SS">
//   Copyright © SS. All rights reserved.
// </copyright>
// <summary>
//   The account history configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using OnlineCourse.Repository.Models;

namespace OnlineCourse.Repository.EtConfiguration
{
	/// <summary>
    ///     The account history configuration.
    /// </summary>
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CourseConfiguration" /> class.
        /// </summary>
        public CourseConfiguration()
        {
            this.Property(x => x.LastUpdated).IsRequired();
            this.Property(x => x.MaxParticipants).IsRequired();
            this.Property(u => u.CourseGuid)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            this.Property(x => x.Name).IsRequired().HasMaxLength(200);
            this.Property(x => x.Teacher).IsOptional().HasMaxLength(1000);
        }
    }
}