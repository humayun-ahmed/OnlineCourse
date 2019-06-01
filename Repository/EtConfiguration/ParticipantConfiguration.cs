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
    public class ParticipantConfiguration : EntityTypeConfiguration<Participant>
    {
		/// <summary>
		///     Initializes a new instance of the <see cref="ParticipantConfiguration" /> class.
		/// </summary>
		public ParticipantConfiguration()
        {
           this.Property(x => x.Name).IsRequired().HasMaxLength(200);
           this.HasRequired(c => c.Course).WithMany(c => c.Participants).HasForeignKey(c => c.CourseId);
		}
    }
}